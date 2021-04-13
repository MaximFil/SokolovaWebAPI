using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SokolovaWebApi
{
    public static class UserHubConfigure
    {
        public static List<UserConnection> UserConnections { get; set; }

        static UserHubConfigure()
        {
            UserConnections = new List<UserConnection>();
        }
    }

    public class UserConnection
    {
        public string UserName { get; set; }

        public string ConnectionId { get; set; }

        public UserConnection(string userName, string connectionId)
        {
            this.UserName = userName;
            this.ConnectionId = connectionId;
        }

    }
}
