using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Microsoft.EntityFrameworkCore;
using Solution.Locator.Core;
using Solution.Locator.Core.Entitities;
using Solution.Locator.Friend.Dto;
using Solution.Locator.Games;
using Solution.Locator.Games.Dto;

namespace Solution.Locator.Friends
{
    public class GameAppService : AsyncCrudAppService<Core.Entitities.Game, GameDto, int, PagedResultRequestDto, CreateGameDto, GameDto>, IGameAppService
    {
        private readonly IRepository<Core.Entitities.Game> _gameRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public GameAppService(IUnitOfWorkManager unitOfWorkManager, IRepository<Core.Entitities.Game> gameRepository) : base(gameRepository)
        {
            _gameRepository = gameRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public override async Task<GameDto> Create(CreateGameDto input)
        {
            var entity = ObjectMapper.Map<Core.Entitities.Game>(input);

            entity.DateCreated = DateTime.Now;

            _gameRepository.Insert(entity);

            return MapToEntityDto(entity);
        }


        public override async Task<GameDto> Update(GameDto input)
        {
            CheckUpdatePermission();

            var query = _gameRepository.GetAll();

            var entity = query.Include(u => u.Friend).Where(i => i.Id == input.Id).FirstOrDefault();

            Set(input, entity);

            _gameRepository.Update(entity);

            return await Get(input);
        }


        private static void Set(GameDto input, Core.Entitities.Game entity)
        {
            entity.Name = input.Name;
        }

        public override async Task Delete(EntityDto<int> input)
        {
            var entity = _gameRepository.Get(input.Id);

            await _gameRepository.DeleteAsync(entity);
        }

        public async Task<ICollection<GameDto>> GetGamesAvailable()
        {
            ICollection<GameDto> gamesAvailable = new List<GameDto>();
            CheckUpdatePermission();

            var query = _gameRepository.GetAll();

            var list = query.Include(u => u.Friend).Where(i => i.IdFriend == null).ToList();

            foreach (var gameAvailable in list)
                gamesAvailable.Add(base.MapToEntityDto(gameAvailable));

            return gamesAvailable;
        }

        public async Task<ICollection<GameDto>> GetGamesBorrow(int friendId)
        {
            ICollection<GameDto> gamesBorrow = new List<GameDto>();
            CheckUpdatePermission();

            var query = _gameRepository.GetAll();

            var list = query.Include(u => u.Friend).Where(i => i.IdFriend == friendId).ToList();

            foreach (var gameAvailable in list)
                gamesBorrow.Add(base.MapToEntityDto(gameAvailable));

            return gamesBorrow;
        }

        public async Task<ListResultDto<GameDto>> GetAll()
        {
            var games = await _gameRepository.GetAllListAsync();
            return new ListResultDto<GameDto>(ObjectMapper.Map<List<GameDto>>(games));
        }
    }
}
