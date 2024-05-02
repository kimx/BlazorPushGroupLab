namespace BlazorPushGroupLab.Data
{
    public class RoomService
    {
        private List<RoomInfo> Rooms;
        public RoomService()
        {
            Rooms = new List<RoomInfo>();
            Rooms.Add(new RoomInfo { RoomNo = "1000", RoomName = "安親班" });
            Rooms.Add(new RoomInfo { RoomNo = "2000", RoomName = "英文進修班" });
            Rooms.Add(new RoomInfo { RoomNo = "3000", RoomName = "國文先修班" });
            Rooms.Add(new RoomInfo { RoomNo = "4000", RoomName = "資優衝刺班" });
        }

        public List<RoomInfo> GetRooms()
        {
            return this.Rooms;
        }
    }
}
