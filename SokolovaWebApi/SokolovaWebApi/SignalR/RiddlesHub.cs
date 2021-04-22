using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Riddles.Service.Services;
using System.Threading;
using System.Security.Claims;
using System.Security.Principal;

namespace SokolovaWebApi.SignalR
{
    public class RiddlesHub : Hub
    {
        private readonly UserService userService;

        public RiddlesHub()
        {
            userService = new UserService();
        }

        public async Task Send(string userName, string message)
        {
            try
            {
                //Context.GetHttpContext().User.AddIdentity(new GenericIdentity(userName));
                //userService.UpdateConnectionId(userName, Context.ConnectionId);
                UserHubConfigure.UserConnections.Add(new UserConnection(userName, Context.ConnectionId));
                userService.ChangeActivityByUserName(userName, true);
                await Clients.All.SendAsync("Recieve", message);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userConfigure = UserHubConfigure.UserConnections.FirstOrDefault(u => string.Equals(u.ConnectionId, Context.ConnectionId));
            if(userConfigure != null)
            {
                userService.ChangeActivityByUserName(userConfigure.UserName, false);
                userService.ChangeIsPlayingOfUser(userService.GetUserIdByName(userConfigure.UserName), false);
                UserHubConfigure.UserConnections.Remove(userConfigure);
            }
            
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendInvite(string userName, string levelName)
        {
            var guestConnectionId = UserHubConfigure.UserConnections.FirstOrDefault(u => string.Equals(u.UserName, userName))?.ConnectionId;
            var hostUserName = UserHubConfigure.UserConnections.FirstOrDefault(u => string.Equals(u.ConnectionId, Context.ConnectionId))?.UserName ?? string.Empty;
            if (string.IsNullOrWhiteSpace(guestConnectionId))
            {
                throw new Exception("Не найден коннекшен данного пользователя!");
            }

            await Clients.Client(guestConnectionId).SendAsync("SendInvite", hostUserName, levelName);
            return;
        }

        public async void AcceptInvite(string userName, bool accept)
        {
            var connectionId = UserHubConfigure.UserConnections.FirstOrDefault(u => string.Equals(u.UserName, userName))?.ConnectionId;
            if (string.IsNullOrWhiteSpace(connectionId))
            {
                throw new Exception("Не найден коннекшен данного пользователя!");
            }

            await Clients.Client(connectionId).SendAsync("AcceptInvite", accept);
        }

        public async void StartGame(string userName, int gameSessionId)
        {
            var connectionId = UserHubConfigure.UserConnections.FirstOrDefault(u => string.Equals(u.UserName, userName))?.ConnectionId;
            if (string.IsNullOrWhiteSpace(connectionId))
            {
                throw new Exception("Не найден коннекшен данного пользователя!");
            }

            await Clients.Client(connectionId).SendAsync("StartGame", gameSessionId);
        }

        //сдаться
        public async void Surrender(string userName, string rivalName)
        {
            var rivalConnectionId = UserHubConfigure.UserConnections.FirstOrDefault(u => string.Equals(u.UserName, rivalName))?.ConnectionId;
            if (string.IsNullOrWhiteSpace(rivalConnectionId))
            {
                throw new Exception("Не найден коннекшен данного пользователя!");
            }

            await Clients.Client(rivalConnectionId).SendAsync("Surrender", userName);
        }

        //соперник закончил раньше тебя и ждёт твоих действий
        public async void RivalFinished(string rivalName)
        {
            var rivalConnectionId = UserHubConfigure.UserConnections.FirstOrDefault(u => string.Equals(u.UserName, rivalName))?.ConnectionId;
            if (string.IsNullOrWhiteSpace(rivalConnectionId))
            {
                throw new Exception("Не найден коннекшен данного пользователя!");
            }

            await Clients.Client(rivalConnectionId).SendAsync("RivalFinished");
        }
    }
}
