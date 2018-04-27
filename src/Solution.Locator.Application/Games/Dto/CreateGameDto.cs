using Abp.AutoMapper;
using Solution.Locator.Core.Entitities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Solution.Locator.Games.Dto
{
    [AutoMapTo(typeof(Game))]
    public class CreateGameDto
    {
        [Required]

        public string Name { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
