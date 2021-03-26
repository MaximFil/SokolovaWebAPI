using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Riddles.Service.Services;
using Riddles.Service.ResponseModels;

namespace SokolovaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserService userService;

        public UserController()
        {
            userService = new UserService();
        }

        [HttpPost]
        [Route("LogIn/{login}/{password}")]
        public ApiResponse LogIn(string login, string password)
        {
            ApiResponse response;
            try
            {
                response = userService.LogIn(login, password);
            }
            catch (Exception ex)
            {
                response = new ApiResponse(false, ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("SignUp/{login}/{password}")]
        public ApiResponse SignUp(string login, string password)
        {
            ApiResponse response;
            try
            {
                response = userService.SignUp(login, password);
            }
            catch (Exception ex)
            {
                response = new ApiResponse(false, ex.Message);
            }

            return response;
        }

        [HttpGet]
        [Route("GetUserNames")]
        public List<string> GetUserNames()
        {
            List<string> userNames;
            try
            {
                userNames = userService.GetUserNames();
            }
            catch (Exception ex)
            {
                userNames = null;
            }

            return userNames;
        }

        [HttpPost]
        [Route("ChangeActivityOfUser/{userId}/{isActive}")]
        public bool ChangeActivityOfUser(int userId, bool isActive)
        {
            try
            {
                userService.ChangeActivityOfUser(userId, isActive);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("ChangeIsPlayingOfUser")]
        public bool ChangeIsPlayingOfUser(int userId, bool isPlaying)
        {
            try
            {
                userService.ChangeIsPlayingOfUser(userId, isPlaying);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
