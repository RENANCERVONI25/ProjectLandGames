using Microsoft.AspNetCore.Antiforgery;
using Solution.Locator.Controllers;

namespace Solution.Locator.Web.Host.Controllers
{
    public class AntiForgeryController : LocatorControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
