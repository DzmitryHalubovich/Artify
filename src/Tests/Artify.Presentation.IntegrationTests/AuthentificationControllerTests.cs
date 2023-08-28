using Artify.Entities.DTO.Authorization;
using System.Net;
using System.Net.Http.Json;

namespace Artify.Presentation.IntegrationTests
{
    public class AuthentificationControllerTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public AuthentificationControllerTests(TestingWebAppFactory<Program> factory)
            => _httpClient = factory.CreateClient();

        [Fact]
        public async Task RegistrationUser_SendValidUser_SuccessRegistration()
        {
            var userForRegistration = new UserForRegistrationDto()
            {
                UserName = "TestName",
                Email = "testing@gmail.com",
                Password = "123456qwE",
                ConfirmPassword = "123456qwE"
            };

            var response = await _httpClient.PostAsJsonAsync("api/auth/registration", userForRegistration);

            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task RegistrationUser_SendEmptyUserName_FailRegistration()
        {
            var userForRegistration = new UserForRegistrationDto()
            {
                UserName = "",
                Email = "testing@gmail.com",
                Password = "123456qwE",
                ConfirmPassword = "123456qwE"
            };

            var response = await _httpClient.PostAsJsonAsync("api/auth/registration", userForRegistration);

            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Contains("Username is required", await response.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task RegistrationUser_SendEmptyEmail_FailRegistration()
        {
            var userForRegistration = new UserForRegistrationDto()
            {
                UserName = "TestName",
                Email = "",
                Password = "123456qwE",
                ConfirmPassword = "123456qwE"
            };

            var response = await _httpClient.PostAsJsonAsync("api/auth/registration", userForRegistration);

            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Contains("Email is required", await response.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task RegistrationUser_SendInvalidEmail_FailRegistration()
        {
            var userForRegistration = new UserForRegistrationDto()
            {
                UserName = "TestName",
                Email = "dsadsakfds",
                Password = "123456qwE",
                ConfirmPassword = "123456qwE"
            };

            var response = await _httpClient.PostAsJsonAsync("api/auth/registration", userForRegistration);

            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Contains("Email is invalid", await response.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task RegistrationUser_PasswordsDoNotMatch_FailRegistration()
        {
            var userForRegistration = new UserForRegistrationDto()
            {
                UserName = "TestName",
                Email = "testing@gmail.com",
                Password = "123456qwE",
                ConfirmPassword = "12384125hfU"
            };

            var response = await _httpClient.PostAsJsonAsync("api/auth/registration", userForRegistration);

            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Contains("The password and confirmation password do not match.", await response.Content.ReadAsStringAsync());
        }
        

        [Fact]
        public async Task RegistrationUser_UserNameIsTooLong_FailRegistration()
        {
            var userForRegistration = new UserForRegistrationDto()
            {
                UserName = "jbkvfidolfewasdertfcq", 
                Email = "testing@gmail.com",
                Password = "123456qwE",
                ConfirmPassword = "123456qwE"
            };

            var response = await _httpClient.PostAsJsonAsync("api/auth/registration", userForRegistration);

            Assert.Equal(21, userForRegistration.UserName.Length);
            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Contains("Username is too long. Max length is 20 symbols.", await response.Content.ReadAsStringAsync());
        }
    }
}
