using Abp.AutoMapper;
using Solution.Locator.Games.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Solution.Locator.Friend.Dto
{
    [AutoMapTo(typeof(Core.Entitities.Friend))]
    public class CreateFriendDto
    {
        [Required]

        public string Name { get; set; }
        [Required]

        public string NickName { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public virtual List<GameDto> Games { get; set; }
    }
}
