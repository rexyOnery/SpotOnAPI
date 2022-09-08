using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web.Services;
using WebApi.Models.Bank;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class BankController : BaseController
    {
        private readonly IBankService _bankService;
        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<BankResponse> Get(int id)
        {
            var account = _bankService.GetAccount(id);
            return Ok(account);
        }
        [HttpGet]
        public ActionResult<IEnumerable<BankResponse>> Get()
        {
            var accounts = _bankService.GetAccounts();
            return Ok(accounts);
        }
        [HttpGet("{userId:int}")]
        public ActionResult<IEnumerable<BankResponse>> GetUserAccount(int userId)
        {
            var accounts = _bankService.GetAccounts(userId);
            return Ok(accounts);
        }
        [HttpPost]
        public ActionResult<BankResponse> Post(BankRequest model)
        {
            var account = _bankService.Deposit(model);
            return Ok(account);
        }
        [HttpGet("makepayment/{accountId:int}")]
        public ActionResult<bool> makePayment(int accountId)
        {
            var account = _bankService.MakePayment(accountId);
            return Ok(account);
        }

    }
}