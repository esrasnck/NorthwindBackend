using NorthwindBackend.BLL.Abstract;
using NorthwindBackend.DAL.Abstract;
using NorthwindBackend.CORE.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.BLL.Concrete
{
    public class UserManager : IUserService
    {
        IUserDAL _userDal;
        public UserManager(IUserDAL userDAL)
        {
            _userDal = userDAL;
        }
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByEmail(string email)
        {
            return _userDal.Get(x => x.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}
