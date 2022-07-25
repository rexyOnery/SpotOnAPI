namespace WebApi.Helpers
{
    public class SmsSettings
    {
        public string Sender { get; set; }
        public string AdminPhone { get; set; }
        public string Token { get; set; }
        public int Routing { get; set; }
        public int Type { get; set; }
        public string BaseUrl { get; set; }
    }
}