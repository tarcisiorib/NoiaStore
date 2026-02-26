using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("error/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var errorModel = new ErrorViewModel();

            if (id == 500)
            {
                errorModel.Message = "The server encountered an internal error!";
                errorModel.Title = "Internal Server Error";
                errorModel.ErrorCode = id;
            }
            else if (id == 404)
            {
                errorModel.Message = "The resource requested could not be found on this server!";
                errorModel.Title = "Page not found!";
                errorModel.ErrorCode = id;
            }
            else if (id == 403)
            {
                errorModel.Message = "Access to this resource on the server is denied!";
                errorModel.Title = "Forbidden!";
                errorModel.ErrorCode = id;
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", errorModel);
        }
    }
}
