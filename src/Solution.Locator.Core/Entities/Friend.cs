using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Extensions;

namespace Solution.Locator.Core.Entitities
{
    public class Friend : Entity<int>
    {
        //public int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string NickName { get; set; }
        public virtual DateTime DateCreated { get; set; }


        [ForeignKey("IdFriend")]
        public virtual ICollection<Game> Games { get; set; }
    }

}
