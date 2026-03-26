using Microsoft.AspNetCore.Mvc.Razor;
using System.Threading;

namespace WebApp.Extensions
{
    public static class RazorHelpers
    {
        public static string FormatCurrency(this RazorPage page, decimal price)
        {
            return price > 0 ? string.Format(Thread.CurrentThread.CurrentCulture, "{0:C}", price) : "Free";
        }

        public static string StockMessage(this RazorPage page, int quantity)
        {
            return quantity > 0 ? $"{quantity} available!" : "Out of stock";
        }
    }
}
