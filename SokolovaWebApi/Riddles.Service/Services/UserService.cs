using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riddles.Repository.Repositories;
using Riddles.DAL.Entities;

namespace Riddles.Service.Services
{
    public class UserService
    {
        private readonly UserRepository userRepository;

        public UserService()
        {
            userRepository = new UserRepository();
        }

        public ResponseModels.ApiResponse LogIn(string login, string password)
        {
            try
            {
                var user = userRepository.GetUserByLoginAndPassword(login, password);
                if (user == null)
                {
                    return new ResponseModels.ApiResponse(false, "Введите валидные логин и пароль!");
                }
                if (user != null && user.IsActive)
                {
                    return new ResponseModels.ApiResponse(false, "Пользователь с такими данными уже вошёл в игру!");
                }
                else
                {
                    return new ResponseModels.ApiResponse(true, "Успешно!", user);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public ResponseModels.ApiResponse SignUp(User user)
        {
            try
            {
                var resultUser = userRepository.CreateUser(user);
                return new ResponseModels.ApiResponse(true, "User was succesfully created!", resultUser);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<string> GetUserNames()
        {
            try
            {
                return userRepository.GetUsers()?.Select(u => u.Name).ToList();
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
                userRepository.ChangeActivityOfUser(userId, isActive);
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
                userRepository.ChangeIsPlayingOfUser(userId, isPlaying);
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
                userRepository.ChangeActivityByUserName(userName, active);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public Dictionary<string, int> GetFreeUserNames()
        {
            try
            {
                return userRepository.GetFreeUserNames();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public int GetUserIdByName(string userName)
        {
            try
            {
                return userRepository.GetUserIdByUserName(userName);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
