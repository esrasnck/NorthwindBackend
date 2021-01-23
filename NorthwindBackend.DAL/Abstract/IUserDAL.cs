using NorthwindBackend.CORE.DataAccess;
using NorthwindBackend.CORE.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.DAL.Abstract
{
   public interface IUserDAL:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user); // kullanıcının sahip olduğu claimleri çekmek istiyorum. bu benim için bir join operasyonu olacak
    }
}
