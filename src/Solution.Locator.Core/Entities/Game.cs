using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Extensions;

namespace Solution.Locator.Core.Entitities
{
    public class Game : Entity<int>
    {
        public virtual string Name { get; set; }
        public virtual DateTime DateCreated { get; set; }

        [ForeignKey("Friend")]
        public virtual int? IdFriend { get; set; }

        [ForeignKey("IdFriend")]
        public virtual Friend Friend { get; set; }
    }
}
