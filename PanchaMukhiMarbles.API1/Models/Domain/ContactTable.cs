namespace PanchaMukhiMarbles.API1.Models.Domain
{
    public class ContactTable
    {
        public Guid Id { get; set; }
        public string[] PhoneNumber { get; set; }
        public string[] Whatsapp { get; set; }
        public string Gmail { get; set; }
        public string Address { get; set; }
    }
}
