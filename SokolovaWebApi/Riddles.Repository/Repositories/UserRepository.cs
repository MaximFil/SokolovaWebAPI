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
            this.context = new ApplicationContext(ConnectionStringHelper.GetConnectionStringByName(ConnectionType.RiddlesDB));
        }

        public IQueryable<User> GetUsers()
        {
            return context.Users;
        }

        public User GetUserByLoginAndPassword(string login, string password)
        {
            return GetUsers().FirstOrDefault(u => string.Equals(u.Name, login) && string.Equals(u.Password, password));
        }

        public User CreateUser(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return context.Users.FirstOrDefault(u => u.Name == user.Name);
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
                if (user != null && user.IsActive != isActive)
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
                if (user != null && user.IsPlaying != isPlaying)
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

        public void ChangeActivityByUserName(string userName, bool active)
        {
            try
            {
                var user = GetUsers().FirstOrDefault(u => u.Name == userName);
                if (user != null && user.IsActive != active)
                {
                    user.IsActive = active;
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //public string GetConnectionIdByUserName(string userName)
        //{
        //    try
        //    {
        //        var user = GetUsers().FirstOrDefault(u => u.Name == userName);
        //        return user?.Name;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public void UpdateConnectionIdByUserName(string userName, string connectionId)
        //{
        //    try
        //    {
        //        var user = GetUsers().FirstOrDefault(u => u.Name == userName);
        //        if (user != null && !string.Equals(user.ConnectionId, connectionId))
        //        {
        //            user.ConnectionId = connectionId;
        //        }
        //        context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public Dictionary<string, int> GetFreeUserNames()
        {
            try
            {
                return GetUsers().Where(u => u.IsActive && !u.IsPlaying).ToDictionary(u => u.Name, u => u.Id);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public int GetUserIdByUserName(string userName)
        {
            try
            {
                return GetUsers().FirstOrDefault(u => string.Equals(u.Name, userName)).Id;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public bool HaveUnFinishedGameSession(string userName)
        {
            try
            {
                var user = GetUsers().FirstOrDefault(u => string.Equals(u.Name, userName));
                if (user != null)
                {
                    var isntFinishedGameSession = context.XrefGameSessionUsers.FirstOrDefault(x => x.UserId == user.Id && !x.Finished);
                    if(isntFinishedGameSession == null && user.IsActive)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    throw new Exception("Пользователь с таким именем не найден!");
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
