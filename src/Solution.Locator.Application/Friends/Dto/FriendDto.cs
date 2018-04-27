using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Solution.Locator.Games.Dto;

namespace Solution.Locator.Friend.Dto
{
    [AutoMap(typeof(Core.Entitities.Friend))]
    public class FriendDto : EntityDto<int>
    {
        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual string NickName { get; set; }
        [Required]
        public virtual DateTime DateCreated { get; set; }

        public virtual ICollection<GameDto> Games { get; set; }
    }
}
