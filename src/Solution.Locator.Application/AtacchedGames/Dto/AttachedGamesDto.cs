using Abp.AutoMapper;
using Solution.Locator.Games.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Solution.Locator.AtacchedGames.Dto
{
    public class AttachedGamesDto
    {

        public virtual int IdFriend { get; set; }
        public virtual List<int> Games { get; set; }
    }
}
