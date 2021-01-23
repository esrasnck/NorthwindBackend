using NorthwindBackend.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.CORE.Entities.Concrete
{
   public class UserOperationClaim:IEntity // kullanıcının rolleri operasyonları
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int OperationClaimId { get; set; }

    }
}
