using System.Collections.Generic;
using Solution.Locator.Friend.Dto;
using Solution.Locator.Roles.Dto;
using Solution.Locator.Users.Dto;

namespace Solution.Locator.Web.Models.Friends
{
    public class FriendListViewModel
    {
        public IReadOnlyList<FriendDto> Friends { get; set; }
    }
}
