using p.lib;
using Microsoft.AspNetCore.SignalR;

public class update_client : Hub
{
        public async Task update() 
    { 
        await Clients.All.SendAsync("updateclient"); 
    } 


}