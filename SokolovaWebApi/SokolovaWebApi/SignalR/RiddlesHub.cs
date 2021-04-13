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
                Context.GetHttpContext().User.AddIdentity(new GenericIdentity(userName));
                userService.UpdateConnectionId(userName, Context.ConnectionId);
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
            try
            {
                var identityUserName = Context.User.Identities.FirstOrDefault(i => !string.IsNullOrWhiteSpace(i.Name))?.Name ?? string.Empty;
                userService.ChangeActivityByUserName(identityUserName, false);
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
            await Clients.Client(connectionId).SendAsync("SendInvite", Thread.CurrentPrincipal.Identity.Name);
        }

        public async void AcceptInvite(string userName, bool accept)
        {
            var connectionId = userService.GetConnectionId(userName);
            await Clients.Client(connectionId).SendAsync("AcceptInvite", accept);
        }
    }
}
