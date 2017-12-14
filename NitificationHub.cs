using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Notifications.Models;

namespace Notifications
{
    public class NitificationHub : Hub
    {

        public static void Show(IEnumerable<Notifications.Models.Notifications> payload)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<NitificationHub>();
            context.Clients.All.broadcastMessage(payload);
        }
    }
}