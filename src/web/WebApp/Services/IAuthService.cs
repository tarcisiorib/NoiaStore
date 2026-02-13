using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IAuthService
    {
        Task<User> Login(LoginUser loginUser);
        Task<User> Register(RegisterUser registerUser);
    }
}
