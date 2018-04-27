using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Solution.Locator.Controllers;

namespace Solution.Locator.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : LocatorControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
