namespace NerdDinner.Events
{
    public class AddressChanged : IEventData
    {
        public string ChangeReason { get; set; }
        public int DinnerID { get; set; }
        public string NewAddress { get; set; }
    }
}