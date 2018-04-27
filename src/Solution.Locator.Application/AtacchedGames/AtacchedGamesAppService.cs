using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Microsoft.EntityFrameworkCore;
using Solution.Locator.AtacchedGames.Dto;
using Solution.Locator.Core.Entitities;

namespace Solution.Locator.AtacchedGames
{
    public class AtacchedAppService : IAtacchedAppService
    {
        private readonly IRepository<Core.Entitities.Friend> _friendRepository;
        private readonly IRepository<Core.Entitities.Game> _gameRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public AtacchedAppService(IUnitOfWorkManager unitOfWorkManager, IRepository<Core.Entitities.Friend> friendRepository, IRepository<Core.Entitities.Game> gameRepository)
        {
            _friendRepository = friendRepository;
            _unitOfWorkManager = unitOfWorkManager;
            _gameRepository = gameRepository;
        }


        public async Task Atacched(AttachedGamesDto input)
        {
            var query = _friendRepository.GetAll();

            var friendEntity = query.Include(u => u.Games).Where(i => i.Id == input.IdFriend).FirstOrDefault();

            if (friendEntity.Games != null && friendEntity.Games.Any())
                friendEntity.Games.Clear();

            foreach (var game in input.Games)
            {
                var gameEntity = _gameRepository.Get(game);
                gameEntity.IdFriend = input.IdFriend;
                gameEntity.Friend = friendEntity;
                friendEntity.Games.Add(gameEntity);
            }

            _friendRepository.Update(friendEntity);
        }
    }
}
