using SocialNetWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetWork.Repository
{
    public interface IRepository
    {
        void AddUser(Users user);

        Users GetUsersById(long id);

        Users GetUsersByMailAndPassword(string mail, string password);
    }
}
