using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User> Login(LoginUser loginUser)
        {
            var loginContent = new StringContent(
                JsonSerializer.Serialize(loginUser),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:44354/api/account/login", loginContent);

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            return JsonSerializer.Deserialize<User>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<User> Register(RegisterUser registerUser)
        {
            var registerContent = new StringContent(
                JsonSerializer.Serialize(registerUser),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:44354/api/account/register", registerContent);

            return JsonSerializer.Deserialize<User>(await response.Content.ReadAsStringAsync());
        }
    }
}
