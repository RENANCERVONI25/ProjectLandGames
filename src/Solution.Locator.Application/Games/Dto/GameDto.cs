using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Solution.Locator.Core.Entitities;
using Solution.Locator.Friend.Dto;

namespace Solution.Locator.Games.Dto
{
    [AutoMapFrom(typeof(Game))]
    public class GameDto : EntityDto<int>
    {
        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public virtual string Name { get; set; }

        public virtual DateTime DateCreated { get; set; }

        public virtual int? IdFriend { get; set; }

    }
}
