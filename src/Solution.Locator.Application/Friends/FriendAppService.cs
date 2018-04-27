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

namespace Solution.Locator.Friends
{
    public class FriendAppService : AsyncCrudAppService<Core.Entitities.Friend, FriendDto, int, PagedResultRequestDto, CreateFriendDto, FriendDto>, IFriendAppService
    {
        private readonly IRepository<Core.Entitities.Friend> _friendRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public FriendAppService(IUnitOfWorkManager unitOfWorkManager, IRepository<Core.Entitities.Friend> friendRepository) : base(friendRepository)
        {
            _friendRepository = friendRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public override async Task<FriendDto> Create(CreateFriendDto input)
        {
            var entity = ObjectMapper.Map<Core.Entitities.Friend>(input);

            entity.DateCreated = DateTime.Now;

            _friendRepository.Insert(entity);

            return MapToEntityDto(entity);
        }


        public async Task<ListResultDto<FriendDto>> GetAll()
        {
            var friends = await _friendRepository.GetAllListAsync();
            return new ListResultDto<FriendDto>(ObjectMapper.Map<List<FriendDto>>(friends));
        }

        public override async Task<FriendDto> Update(FriendDto input)
        {
            CheckUpdatePermission();

            var query = _friendRepository.GetAll();

            var entity = query.Include(u => u.Games).Where(i => i.Id == input.Id).FirstOrDefault();

            Set(input, entity);

            _friendRepository.Update(entity);

            return await Get(input);
        }

        private static void Set(FriendDto input, Core.Entitities.Friend entity)
        {
            entity.Name = input.Name;
            entity.NickName = input.NickName;
        }

        public override async Task Delete(EntityDto<int> input)
        {
            var query = _friendRepository.GetAll();

            var entity = query.Include(u => u.Games).Where(i => i.Id == input.Id).FirstOrDefault();

            if (entity.Games != null && entity.Games.Any())
                entity.Games = null;

            await _friendRepository.DeleteAsync(entity);
        }
    }
}
