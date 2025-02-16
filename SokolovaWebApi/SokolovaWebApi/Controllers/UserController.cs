﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Riddles.Service.Services;
using Riddles.Service.ResponseModels;
using Riddles.DAL.Entities;
using System.Threading;
using System.Security.Principal;

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

        [HttpGet]
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
        [Route("SignUp")]
        public ApiResponse SignUp([FromBody]User user)
        {
            ApiResponse response;
            try
            {
                response = userService.SignUp(user);
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

        [HttpPut]
        [Route("ChangeActivityOfUser/{userId}")]
        public bool ChangeActivityOfUser(int userId, [FromBody]bool isActive)
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

        [HttpPut]
        [Route("ChangeIsPlayingOfUser/{userId}")]
        public bool ChangeIsPlayingOfUser([FromBody]bool isPlaying, int userId)
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

        [HttpGet]
        [Route("GetFreeUserNames")]
        public Dictionary<string, int> GetFreeUserNames()
        {
            Dictionary<string, int> userNames;
            try
            {
                userNames = userService.GetFreeUserNames();
            }
            catch (Exception ex)
            {
                userNames = null;
            }

            return userNames;
        }

        [HttpGet]
        [Route("HaveUnFinishedGameSession/{rivalName}")]
        public bool HaveUnFinishedGameSession(string rivalName)
        {
            try
            {
                return userService.HaveUnFinishedGameSession(rivalName);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
