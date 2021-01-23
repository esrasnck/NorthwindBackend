using NorthwindBackend.CORE.DataAccess.EntityFramework;
using NorthwindBackend.DAL.Abstract;
using NorthwindBackend.DAL.Concrete.EntityFramework.Contexts;
using NorthwindBackend.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System.Linq;
using NorthwindBackend.CORE.Entities.Concrete;

namespace NorthwindBackend.DAL.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDAL
    {
        public List<OperationClaim> GetClaims(User user)
        {
            // kullanıcı rollerini çekmek istiyorum.
            using (var context = new NorthwindContext())
            {
                // iki tabloyu join etmek gerekiyor !!

                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name =      operationClaim.Name };

                return result.ToList();
            }
           
        }
    }
}
