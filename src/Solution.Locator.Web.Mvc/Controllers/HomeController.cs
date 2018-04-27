using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Solution.Locator.Controllers;
using Solution.Locator.Friends;
using Solution.Locator.Games;
using System.Threading.Tasks;
using System.Linq;
using Solution.Locator.Home.Dto;

namespace Solution.Locator.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : LocatorControllerBase
    {
        private readonly IFriendAppService _friendAppService;
        private readonly IGameAppService _gameAppService;
        public HomeController(IFriendAppService friendAppService, IGameAppService gameAppService)
        {
            _friendAppService = friendAppService;
            _gameAppService = gameAppService;
        }


        public async Task<ActionResult> Index()
        {
            var friendsCount = (await _friendAppService.GetAll()).Items.Count;
            var games = (await _gameAppService.GetAll()).Items;
            var gamesBorrowed = games.Where(x => x.IdFriend != null && x.IdFriend != 0).Count();
            var gamesAvailableCount = games.Where(x => x.IdFriend == null || x.IdFriend == 0).Count();

            return View(new HomeDetails() { Friends = friendsCount, GamesAvailable = gamesAvailableCount, GamesBorrowed = gamesBorrowed });
        }
    }
}
