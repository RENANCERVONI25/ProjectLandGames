using System.Collections.Generic;
using Solution.Locator.Friend.Dto;
using Solution.Locator.Games.Dto;
using Solution.Locator.Roles.Dto;
using Solution.Locator.Users.Dto;

namespace Solution.Locator.Web.Models.Games
{
    public class GameListViewModel
    {
        public IReadOnlyList<GameDto> Games { get; set; }
    }
}
