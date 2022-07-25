using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SMSController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ISmsService _smsService;

        public SMSController(
            ISmsService smsService,
            IMapper mapper)
        {
            _smsService = smsService;
            _mapper = mapper;
        }

        [HttpPost("collectionsms/{customerId}")]
        public IActionResult sendCollectedSMS(int customerId)
        {
            _smsService.SendCollectedSms(customerId);
            return Ok(new { message = "Message successfully sent." });
        }

        [HttpPost("pickupsms/{customerId}/{totalItems}/{price}")]
        public IActionResult sendPickUpSMS(int customerId, int totalItems, string price)
        {
            _smsService.SendPickUpSMS(customerId, totalItems, price);
            return Ok(new { message = "Message successfully sent." });
        }

        [HttpGet("request")]
        public IActionResult sendAdminOffSiteCustomerSMS()
        {
            _smsService.SendAdminOffSiteCustomerSms();
            return Ok(new { message = "Message successfully sent." });
        }



    }
}