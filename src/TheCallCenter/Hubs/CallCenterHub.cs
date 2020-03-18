using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using TheCallCenter.Data.Entities;

namespace TheCallCenter.Hubs
{
    public class CallCenterHub : Hub<ICallCenterHub>
    {
        public async Task NewCallReceived(Call newCall)
        {
            //await Clients.All.NewCallReceived(newCall);

            await Clients.Groups("CallCenters").NewCallReceived(newCall);
        }

        public async Task JoinCallCenters()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "CallCenters");
        }
    }
}
