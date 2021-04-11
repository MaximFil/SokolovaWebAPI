using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Riddles.Service.Services;
using System.Threading;

namespace SokolovaWebApi.SignalR
{
    public class RiddlesHub : Hub
    {
        private readonly UserService userService;

        public RiddlesHub()
        {
            userService = new UserService();
        }

        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Recieve", message);
        }

        public override async Task OnConnectedAsync()
        {
            try
            {
                userService.UpdateConnectionId(UserPrincipal.UserName, Context.ConnectionId);
            }
            catch(Exception ex)
            {
                throw;
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            try
            {
                userService.ChangeActivityByUserName(UserPrincipal.UserName, false);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendInvite(string userName)
        {
            var connectionId = userService.GetConnectionId(userName);
            await Clients.Client(connectionId).SendAsync("SendInvite", UserPrincipal.UserName);
        }

        public async void AcceptInvite(string userName, bool accept)
        {
            var connectionId = userService.GetConnectionId(userName);
            await Clients.Client(connectionId).SendAsync("AcceptInvite", accept);
        }
    }
}
