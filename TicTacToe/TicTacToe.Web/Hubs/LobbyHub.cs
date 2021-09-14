using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TicTacToe.Web.Hubs
{
    public class LobbyHub : Hub
    {
        private static string[] GroupsArray = new string[2];
        private static string[] Board = new string[9];
        public LobbyHub()
        {
        }

        public async Task StartGame()
        {
            await Clients.Group("PlayerOne").SendAsync("GameReady");
            await Clients.All.SendAsync("StartTheGame", "New Game has started !");
        }
        public override async Task OnConnectedAsync()
        {
            var user = this.Context.ConnectionId;
            if (GroupsArray[0] !=null)
            {
                if (GroupsArray[1] != null)
                {
                    return;
                }
                GroupsArray[1] = user;
                await this.Groups.AddToGroupAsync(user, "PlayerTwo");
                await this.Clients.Group("PlayerTwo").SendAsync("ConnectPlayer");
                await this.Clients.Group("PlayerOne").SendAsync("GameAvailable");
                return;
            }
            GroupsArray[0] = user;
            await this.Groups.AddToGroupAsync(user, "PlayerOne");
            await this.Clients.Group("PlayerOne").SendAsync("ConnectPlayer");

        }

        public async Task GetMove()
        {

        }

    }
}

