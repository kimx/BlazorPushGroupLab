using BlazorPushGroupLab.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace BlazorPushGroupLab.Pages
{
    //主要參考
    //https://learn.microsoft.com/zh-tw/aspnet/core/blazor/tutorials/signalr-blazor?view=aspnetcore-8.0&tabs=visual-studio
    //https://learn.microsoft.com/zh-tw/aspnet/core/signalr/groups?view=aspnetcore-8.0
    //[Authorize]  //預留取得登入者資訊
    public class RoomHub : Hub
    {
        //預留以登入者資訊，取得對應的教室
        //public override Task OnConnectedAsync()
        //{
        //    //var userNo = Context.User.Identity.Name;
        //    //var rooms = db.Find...;
        //    ////從資料庫取得目前使用者所屬的房間。(可以是多個)
        //    //foreach (var room in rooms)
        //    //{
        //    //    Groups.Add(Context.ConnectionId, room.RoomName);
        //    //}
        //    return base.OnConnectedAsync();
        //}

        private RoomService RoomService;
        public RoomHub(RoomService roomService)
        {
            RoomService = roomService;
        }

        public async Task SendMessage(string message)
        {

            await Clients.All.SendAsync("ReceiveMessage", GetMessage(message));
        }

        public async Task EnterRoom(string userName, string roomNo)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomNo);

            await Clients.All.SendAsync("ReceiveMessage", GetMessage($"{userName} 已加入教室 {GetRoomName(roomNo)}."));
        }

        public async Task LeaveRoom(string userName, string roomNo)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomNo);
            await Clients.All.SendAsync("ReceiveMessage", GetMessage($"{userName} 已離開教室 {GetRoomName(roomNo)}."));

        }

        public async Task NotifyRoom(string userName, string roomNo, string message)
        {
            await Clients.Group(roomNo).SendAsync("ReceiveMessageByRoom", roomNo, GetMessage($"{userName} 向教室 {GetRoomName(roomNo)}，發送訊息 : {message}."));

        }

        private string GetRoomName(string roomNo)
        {
            return this.RoomService.GetRooms().SingleOrDefault(o => o.RoomNo == roomNo).RoomName;
        }

        private string GetMessage(string message)
        {
            return $"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} :{message}";
        }


        public override Task OnDisconnectedAsync(Exception? exception)
        {
            //RemoveFromGroupAsync 不需要在 中 OnDisconnectedAsync呼叫 ，系統會自動處理。  
            return base.OnDisconnectedAsync(exception);

        }
    }
}