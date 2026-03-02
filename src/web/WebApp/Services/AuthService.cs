using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Extensions;
using WebApp.Models;

namespace WebApp.Services
{
    public class AuthService : Service, IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient,
                           IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.AuthUrl);
            _httpClient = httpClient;
        }

        public async Task<User> Login(LoginUser loginUser)
        {
            var loginContent = GetContent(loginUser);

            var response = await _httpClient.PostAsync("/api/account/login", loginContent);

            if (!ProcessResponseErrors(response))
            {
                return new User
                {
                    ResponseResult = await DeserializeResponseObject<ResponseResult>(response)
                };
            }

            return await DeserializeResponseObject<User>(response);
        }

        public async Task<User> Register(RegisterUser registerUser)
        {
            var registerContent = GetContent(registerUser);

            var response = await _httpClient.PostAsync("/api/account/register", registerContent);

            if (!ProcessResponseErrors(response))
            {
                return new User
                {
                    ResponseResult = await DeserializeResponseObject<ResponseResult>(response)
                };
            }

            return await DeserializeResponseObject<User>(response);
        }
    }
}
