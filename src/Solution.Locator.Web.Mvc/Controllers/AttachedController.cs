using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Solution.Locator.Authorization;
using Solution.Locator.Controllers;
using Solution.Locator.Web.Models.Friends;
using Solution.Locator.Friends;
using Solution.Locator.Games;
using Solution.Locator.AttachedGames;

namespace Solution.Locator.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Roles)]
    public class AttachedController : LocatorControllerBase
    {
        private readonly IAttachedAppService _attachedAppService;

        public AttachedController(IAttachedAppService attachedAppService, IGameAppService gameAppService)
        {
            _attachedAppService = attachedAppService;
        }
    }
}
