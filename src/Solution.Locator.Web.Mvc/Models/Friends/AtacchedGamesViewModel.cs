
using Solution.Locator.Friend.Dto;
using Solution.Locator.Games.Dto;
using System.Collections.Generic;

namespace Solution.Locator.Web.Models.Friends
{
    public class AtacchedGamesViewModel
    {
        public FriendDto Friend { get; set; }

        public ICollection<GameDto> GamesAvailable { get; set; }

        public ICollection<GameDto> GamesBorrowed { get; set; }

    }
}
