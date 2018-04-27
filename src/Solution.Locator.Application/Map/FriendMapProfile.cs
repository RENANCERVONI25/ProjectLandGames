using AutoMapper;
using Solution.Locator.Friend.Dto;

namespace Solution.Locator.Map
{
    public class FriendMapProfile : Profile
    {
        public FriendMapProfile()
        {
            CreateMap<FriendDto, Core.Entitities.Friend>();
            CreateMap<CreateFriendDto, Core.Entitities.Friend>();
        }
    }
}
