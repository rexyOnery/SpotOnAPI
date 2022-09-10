using System;
using System.Linq;
using AutoMapper;
using WebApi.Helpers;
using WebApi.Models.Dashboard;

namespace WebApi.Services
{
    public interface IDashboardService
    {
        DashboardResponse GetDashboard();
    }

    public class DashboardService : IDashboardService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DashboardService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public DashboardResponse GetDashboard()
        {
            var total_amount = _context.Artisans.Count(x => x.IsApproved == true);
            var total_pending = _context.Artisans.Count(x => x.IsApproved == false);
            var total_artisans = _context.Artisans.Count();
            var monthly_sales = _context.Artisans.Count(x => x.DateApproved.Value.Month == DateTime.Now.Month && x.IsApproved == true);
            var expired_artisans = getExpiredArtisans();
            var regerrer_request = _context.Banks.Count(x => x.isPaid == false);

            var response = new DashboardResponse
            {
                TotalAmount = total_amount,
                TotalPending = total_pending,
                TotalArtisans = total_artisans,
                MonthlySales = monthly_sales,
                ExpiredArtisans = expired_artisans,
                ReferrerRequest = regerrer_request
            };

            return response;

        }

        public int getExpiredArtisans()
        {
            var expired_artisans = _context.Artisans.Where(x => x.IsApproved == true);
            var count = 0;
            foreach (var artisan in expired_artisans)
            {
                if (artisan.DateApproved.Value.AddYears(1) < DateTime.Now)
                {
                    count++;
                }
            }
            return count;
        }
        private int getMonth(DateTime? dateApproved)
        {
            var month = dateApproved.Value.Month;
            return month;
        }
    }
}