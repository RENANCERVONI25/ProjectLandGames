using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Solution.Locator.Authorization;
using Solution.Locator.Controllers;
using Solution.Locator.Web.Models.Friends;
using Solution.Locator.Friends;
using Solution.Locator.Games;
using Solution.Locator.AtacchedGames;

namespace Solution.Locator.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class AtacchedController : LocatorControllerBase
    {
        private readonly IAtacchedAppService _atacchedAppService;

        public AtacchedController(IAtacchedAppService atacchedAppService, IGameAppService gameAppService)
        {
            _atacchedAppService = atacchedAppService;
        }
    }
}
