namespace Artify.WEB.Pages
{
    public partial class UpdateProfile
    {
        private AuthorProfileUpdateModel _profileUpdateDto = new AuthorProfileUpdateModel();

        [Inject]
        public IAuthorProfileService AuthorProfileService { get; set; }

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await SetUpProfile();
        }

        private async Task SetUpProfile()
        {
            var currentUser = await AuthenticationStateProvider.GetAuthenticationStateAsync();

            _profileUpdateDto.Name = currentUser.User.FindFirst("PublicName")!.Value;
            _profileUpdateDto.Profession = currentUser.User.FindFirst("Profession")!.Value;
            _profileUpdateDto.City = currentUser.User.FindFirst("City")!.Value;
            _profileUpdateDto.Country = currentUser.User.FindFirst("Country")!.Value;
            _profileUpdateDto.AvatarUrl = currentUser.User.FindFirst("AvatarUrl")!.Value;
        }

        private async Task Update()
        {
            await AuthorProfileService.UpdateAsync(_profileUpdateDto);
        }

        private void AssignImageUrl(string imgUrl) => _profileUpdateDto.AvatarUrl = imgUrl;
    }
}
