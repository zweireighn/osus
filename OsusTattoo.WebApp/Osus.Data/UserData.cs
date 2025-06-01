using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osus.Core;

namespace Osus.Data
{
    public class UserData
    {
        private OsusDbContext _db;

        public UserData()
        {
            _db = new OsusDbContext();
        }

        public bool SaveUser(User user)
        {
            bool isSuccess = false;

            try
            {
                _db.Users.Add(user);
                _db.SaveChanges();

                isSuccess = true;
            }
            catch (Exception ex)
            {
                isSuccess = false;
            }

            return isSuccess;
        }
    }
}
