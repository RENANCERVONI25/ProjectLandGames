using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Solution.Locator.Authorization;
using Solution.Locator.Controllers;
using Solution.Locator.Users;
using Solution.Locator.Web.Models.Users;
using Solution.Locator.Web.Models.Friends;
using Solution.Locator.Friends;
using System;
using Solution.Locator.Friend.Dto;
using Solution.Locator.Games;
using Solution.Locator.Web.Models.Games;

namespace Solution.Locator.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Roles)]
    public class GamesController : LocatorControllerBase
    {
        private readonly IGameAppService _gameAppService;

        public GamesController(IGameAppService gameAppService)
        {
            _gameAppService = gameAppService;
        }

        public async Task<ActionResult> Index()
        {
            var games = (await _gameAppService.GetAll(new PagedResultRequestDto { MaxResultCount = int.MaxValue })).Items; // Paging not implemented yet

            var model = new GameListViewModel
            {
                Games = games,
            };

            return View(model);
        }

        
        public async Task<ActionResult> EditGameModal(int gameId)
        {
            var game = await _gameAppService.Get(new EntityDto<int>(gameId));
            var model = new EditGameModalViewModel
            {
                Game = game,
            };
            return View("_EditGameModal", model);
        }
    }
}
