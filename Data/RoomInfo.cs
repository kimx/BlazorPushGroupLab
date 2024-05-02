namespace BlazorPushGroupLab.Data
{
    public class RoomInfo
    {
        public RoomInfo()
        {
            this.Messages = new List<string>();
        }
        public string RoomNo { get; set; }
        public string RoomName { get; set; }
        public string Message { get; set; }
        public List<string> Messages { get; set; }
    }
}
