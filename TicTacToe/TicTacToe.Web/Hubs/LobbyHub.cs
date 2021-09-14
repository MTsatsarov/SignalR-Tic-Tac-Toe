using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TicTacToe.Web.Hubs
{
    public class LobbyHub : Hub
    {
        private static string[] GroupsArray = new string[2];

        public LobbyHub()
        {
        }
        public async Task SendMessage(string message)
        {
            var user = this.Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            var user = this.Context.ConnectionId;
            string buttonToshow;
            if (GroupsArray[0] !=null)
            {
                if (GroupsArray[1] != null)
                {
                    return;
                }
                GroupsArray[1] = user;
               await this.Groups.AddToGroupAsync(user, "PlayerTwo");
                buttonToshow = "SecondPlayerReady";
                await this.Clients.Group("PlayerTwo").SendAsync("ConnectPlayer", buttonToshow);
                return;
            }
            GroupsArray[0] = user;
            await this.Groups.AddToGroupAsync(user, "PlayerOne");
            buttonToshow = "FirstPlayerReady";
            await this.Clients.Group("PlayerOne").SendAsync("ConnectPlayer", buttonToshow);
        }

    }
}

