using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Microsoft.EntityFrameworkCore;
using Solution.Locator.AttachedGames;
using Solution.Locator.AttachedGames.Dto;
using Solution.Locator.Core.Entitities;

namespace Solution.Locator.AttachedGames
{
    public class AttachedAppService : IAttachedAppService
    {
        private readonly IRepository<Core.Entitities.Friend> _friendRepository;
        private readonly IRepository<Core.Entitities.Game> _gameRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public AttachedAppService(IUnitOfWorkManager unitOfWorkManager, IRepository<Core.Entitities.Friend> friendRepository, IRepository<Core.Entitities.Game> gameRepository)
        {
            _friendRepository = friendRepository;
            _unitOfWorkManager = unitOfWorkManager;
            _gameRepository = gameRepository;
        }


        public async Task Attached(AttachedGamesDto input)
        {
            var query = _friendRepository.GetAll();

            var friendEntity = query.Include(u => u.Games).Where(i => i.Id == input.IdFriend).FirstOrDefault();

            if (friendEntity.Games != null && friendEntity.Games.Any())
                friendEntity.Games.Clear();

            input.Games.ForEach(x =>{
                SetGames(input, friendEntity, x);
            });

            //foreach (var game in input.Games)
            //{
            //    SetGames(input, friendEntity, game);
            //}

            _friendRepository.Update(friendEntity);
        }

        private void SetGames(AttachedGamesDto input, Core.Entitities.Friend friendEntity, int game)
        {
            var gameEntity = _gameRepository.Get(game);
            gameEntity.IdFriend = input.IdFriend;
            gameEntity.Friend = friendEntity;
            friendEntity.Games.Add(gameEntity);
        }
    }
}
