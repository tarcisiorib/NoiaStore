using Microsoft.AspNetCore.Mvc;

namespace WebApp.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        public IViewComponentResult InvokeAsync()
        {
            return View();
        }
    }
}
