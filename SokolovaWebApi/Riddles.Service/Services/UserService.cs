using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riddles.Repository.Repositories;

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
                    return new ResponseModels.ApiResponse(false, "Please enter valid credentials!");
                }
                if (user != null && !user.IsActive)
                {
                    return new ResponseModels.ApiResponse(false, "The user with this credentials has already entered to game!");
                }
                else
                {
                    return new ResponseModels.ApiResponse(true, "Success", user);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public ResponseModels.ApiResponse SignUp(string login, string password)
        {
            try
            {
                var user = userRepository.CreateUser(login, password);
                return new ResponseModels.ApiResponse(true, "User was succesfully created!", user);
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
    }
}
