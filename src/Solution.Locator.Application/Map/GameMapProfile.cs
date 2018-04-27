using AutoMapper;
using Solution.Locator.Core.Entitities;
using Solution.Locator.Games.Dto;
using Solution.Locator.Users.Dto;

namespace Solution.Locator.Map
{
    public class GameMapProfile : Profile
    {
        public GameMapProfile()
        {
            CreateMap<GameDto, Game>();
            CreateMap<CreateGameDto, Game>();
        }
    }
}
