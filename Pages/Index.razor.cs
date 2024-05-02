using BlazorPushGroupLab.Data;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorPushGroupLab.Pages
{
    public partial class Index
    {
        private List<Data.RoomInfo> AllRooms = new List<Data.RoomInfo>();
        private bool IsLogon = false;
        private string UserName = "";
        private string LoginRoom = null;
        private HubConnection? hubConnection;
        private List<string> AllMessages = new List<string>();
        private List<string> RoomMessages = new List<string>();
        private string? userInput = "Kimxinfo";

        protected override async Task OnInitializedAsync()
        {
            AllRooms = UserService.GetRooms();
            await InitHub();
        }


        private async Task InitHub()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(Navigation.ToAbsoluteUri("/roomhub"))
                .Build();

            //ALL
            hubConnection.On<string>("ReceiveMessage", (message) =>
            {
                AllMessages.Add(message);
                InvokeAsync(StateHasChanged);
            });

            hubConnection.On<string, string>("ReceiveMessageByRoom", (roomNo, message) =>
            {
                RoomMessages.Add(message);
                InvokeAsync(StateHasChanged);
            });

            await hubConnection.StartAsync();
        }

        private async Task Login()
        {
            IsLogon = true;
            UserName = userInput;
            await hubConnection.SendAsync("SendMessage", $"{UserName} µn¤J");
        }

        private async Task EnterRoom(RoomInfo room)
        {
            if (LoginRoom != null)
                await hubConnection.SendAsync("LeaveRoom", UserName, LoginRoom);
            await hubConnection.SendAsync("EnterRoom", UserName, room.RoomNo);
            LoginRoom = room.RoomNo;
        }
        private async Task LeaveRoom(RoomInfo room)
        {
            await hubConnection.SendAsync("LeaveRoom", UserName, room.RoomNo);
            LoginRoom = null;
        }

        private async Task NotifyRoom(RoomInfo room)
        {
            await hubConnection.SendAsync("NotifyRoom", UserName, room.RoomNo, room.Message);
        }

        public bool IsConnected => hubConnection?.State == HubConnectionState.Connected;

        public async ValueTask DisposeAsync()
        {
            if (hubConnection is not null)
            {
                await hubConnection.DisposeAsync();
            }
        }
    }
}