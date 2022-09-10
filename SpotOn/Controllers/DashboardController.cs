using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : BaseController
    {
        private IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public IActionResult GetDashboard()
        {
            var dashboard = _dashboardService.GetDashboard();
            return Ok(dashboard);
        }
    }
}