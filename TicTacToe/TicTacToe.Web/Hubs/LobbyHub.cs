using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TicTacToe.Web.Hubs
{
    public class LobbyHub : Hub
    {

        public LobbyHub()
        {
        }
        public async Task SendMessage(string message)
        {
            var user = this.Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        //public override async Task OnConnectedAsync()
        //{
        //    var user = this.Context.User.FindFirst(ClaimTypes.Name).Value;
        //    var message = $"{user} has joined lobby.";
        //    await Clients.All.SendAsync("ReceiveMessage", user, message);
        //}
    }
}

