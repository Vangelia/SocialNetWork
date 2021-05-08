using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetWork.Model;

namespace SocialNetWork.Repository
{
    public class RepositoryIm : IRepository
    {
        private Entities _dbContext;
        public void AddUser(Users user)
        {
            
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public RepositoryIm(Entities dbContext)
        {
            this._dbContext = dbContext;
        }

        public Users GetUsersById(long id)
        {
            return _dbContext.Users.SingleOrDefault(c => c.Id == id);
        }

        public Users GetUsersByMailAndPassword(string mail, string password)
        {
            if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(password))
                throw new NullReferenceException("Not correct");
            return _dbContext.Users.SingleOrDefault(c => c.Email == mail && c.Password == password);
        }
    }
}
