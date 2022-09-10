namespace WebApi.Models.Dashboard
{
    public class DashboardResponse
    {
        public int TotalAmount { get; set; }
        public int TotalPending { get; set; }
        public int TotalArtisans { get; set; }
        public int MonthlySales { get; set; }
        public int ExpiredArtisans { get; set; }
        public int ReferrerRequest { get; set; }
    }
}