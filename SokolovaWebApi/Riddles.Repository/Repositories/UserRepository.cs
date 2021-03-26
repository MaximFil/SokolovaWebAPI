using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riddles.DAL;
using Riddles.DAL.Entities;

namespace Riddles.Repository.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationContext context;

        public UserRepository()
        {
            this.context = new ApplicationContext(ConnectionStringHelper.GetConnectionStringByName(ConnectionType.TestDB));
        }

        public IQueryable<User> GetUsers()
        {
            return context.Users;
        }

        public User GetUserByLoginAndPassword(string login, string password)
        {
            return GetUsers().FirstOrDefault(u => string.Equals(u.Name, login) && string.Equals(u.Password, password));
        }

        public User CreateUser(string login, string password)
        {
            try
            {
                var user = new User { Name = login, Password = password };
                context.Users.Add(user);
                context.SaveChanges();
                return context.Users.LastOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ChangeActivityOfUser(int userId, bool isActive)
        {
            try
            {
                var user = GetUsers().FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.IsActive = isActive;
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ChangeIsPlayingOfUser(int userId, bool isPlaying)
        {
            try
            {
                var user = GetUsers().FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.IsPlaying = isPlaying;
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
