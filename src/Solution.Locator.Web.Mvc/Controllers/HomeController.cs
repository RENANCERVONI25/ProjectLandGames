using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Solution.Locator.Controllers;
using Solution.Locator.Friends;
using Solution.Locator.Games;
using System.Threading.Tasks;
using System.Linq;
using Solution.Locator.Home.Dto;
using System.Collections.Generic;

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
            var friends = (await _friendAppService.GetAll()).Items;
            var games = (await _gameAppService.GetAll()).Items;
            var gamesBorrowed = games.Where(x => x.IdFriend != null && x.IdFriend != 0).ToList();
            var gamesAvailableCount = games.Where(x => x.IdFriend == null || x.IdFriend == 0).Count();


            var friendsGames = friends.Where(x => x.Games.Any());

            Dictionary<string, string> dictionarygamesBorrew = new Dictionary<string, string>();
            foreach (var gameBorrowed in gamesBorrowed)
                dictionarygamesBorrew.Add(friends.Where(u => u.Id == gameBorrowed.IdFriend).FirstOrDefault().Name, gameBorrowed.Name);

            return View(new HomeDetails() { Friends = friends.Count, GamesAvailable = gamesAvailableCount, GamesBorrowed = dictionarygamesBorrew });
        }
    }
}
