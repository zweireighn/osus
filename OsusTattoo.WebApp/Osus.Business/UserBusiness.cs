using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osus.Core;
using Osus.Data;

namespace Osus.Business
{
    public class UserBusiness
    {
        UserData _userData;

        public UserBusiness() 
        {
            _userData = new UserData();
        }

        public bool StoreUser(User user) 
        {
            return _userData.SaveUser(user);
        }

        public User LoadUserByUserName(string userName)
        {
            return _userData.LoadUserByUserName(userName);
        }
    }
}
