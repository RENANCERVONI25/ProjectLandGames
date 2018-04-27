using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Solution.Locator.Authorization;
using Solution.Locator.Controllers;
using Solution.Locator.Web.Models.Friends;
using Solution.Locator.Friends;
using Solution.Locator.Games;

namespace Solution.Locator.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class FriendsController : LocatorControllerBase
    {
        private readonly IFriendAppService _friendAppService;
        private readonly IGameAppService _gameAppService;

        public FriendsController(IFriendAppService friendAppService, IGameAppService gameAppService)
        {
            _friendAppService = friendAppService;
            _gameAppService = gameAppService;
        }

        public async Task<ActionResult> Index()
        {
            var friends = (await _friendAppService.GetAll(new PagedResultRequestDto { MaxResultCount = int.MaxValue })).Items; // Paging not implemented yet

            var model = new FriendListViewModel
            {
                Friends = friends,
            };

            return View(model);
        }

        public async Task<ActionResult> AttachedGamesModal(int friendId)
        {
            var friend = await _friendAppService.Get(new EntityDto<int>(friendId));
            var gamesAvailable = await _gameAppService.GetGamesAvailable();
            var gamesBorrowed = await _gameAppService.GetGamesBorrow(friendId);
            var model = new AtacchedGamesViewModel
            {
                GamesAvailable = gamesAvailable,
                Friend = friend,
                GamesBorrowed = gamesBorrowed,
            };

            return View("_AttachedGamesModal", model);
        }

        public async Task<ActionResult> EditFriendModal(int friendId)
        {
            var friend = await _friendAppService.Get(new EntityDto<int>(friendId));
            var model = new EditFriendModalViewModel
            {
                Friend = friend,
            };
            return View("_EditFriendModal", model);
        }
    }
}
