namespace Artify.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private Author? _user;        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IRepositoryManager _repository;        private readonly UserManager<Author> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;


        public AuthenticationService(IRepositoryManager repository, IMapper mapper, UserManager<Author> userManager,
            IConfiguration configuration, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _repository=repository;
            _mapper=mapper;
            _userManager=userManager;
            _configuration=configuration;
            _roleManager=roleManager;
        }

        public async Task<TokenDto> CreateToken(bool populateExp)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);            var refreshToken = GenerateRefreshToken();            _user.RefreshToken = refreshToken;            if (populateExp)
            {
                _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            }

            await _userManager.UpdateAsync(_user);

            var Token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new TokenDto(Token, refreshToken);
        }

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            
            var authorRole = await _roleManager.FindByNameAsync("Author");

            userForRegistration.Roles!.Add(authorRole.Name);

            var user = _mapper.Map<Author>(userForRegistration);

            var result = await _userManager.CreateAsync(user,
            userForRegistration.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, userForRegistration.Roles);
                await _repository.AuthorProfile.CreateDefault(user);
                await _repository.SaveAsync();
            }

            _user = await _userManager.FindByNameAsync(userForRegistration.UserName);

            return result;        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            _user = await _userManager.FindByEmailAsync(userForAuth.Email);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user,
userForAuth.Password));

            return result;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }        private async Task<List<Claim>> GetClaims()
        {
            var userProfile = await _repository.AuthorProfile.GetByIdAsync(_user.Id, false);

            var claims = new List<Claim>
            {
                new Claim("AuthorId", _user.Id.ToString()),
                new Claim("PublicName", userProfile.Name),
                new Claim("Email", _user.Email),
                new Claim("Profession", userProfile.Profession),
                new Claim("City", userProfile.City),
                new Claim("Country", userProfile.Country),
                new Claim("AvatarUrl", userProfile.AvatarUrl),
                new Claim(ClaimTypes.Name, _user.UserName)
            };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials,
            List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);   
            }
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"))),
                ValidateLifetime = false,
                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, 
                out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, 
                StringComparison.InvariantCultureIgnoreCase))
            {
                throw new InvalidOperationException("Invalid token");
            }

            return principal;
        }

        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.Token);

            var user = await _userManager.FindByNameAsync(principal.Identity.Name);

            if (user == null || user.RefreshToken != tokenDto.RefreshToken ||
            user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new RefreshTokenBadRequest();

            _user = user;

            return await CreateToken(populateExp: false);
        }
    }
}
