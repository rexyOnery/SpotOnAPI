using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Bank;

namespace Web.Services
{
    public interface IBankService
    {
        bool Deposit(BankRequest model);
        bool MakePayment(int accountId);
        BankResponse GetAccount(int accountId);
        IEnumerable<BankResponse> GetAccounts();
        IEnumerable<BankResponse> GetAccounts(int userId);
    }
    public class BankService : IBankService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public BankService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // public void Transfer(int fromAccountId, int toAccountId, decimal amount)
        // {
        //     var fromAccount = _context.Accounts.Find(fromAccountId);
        //     var toAccount = _context.Accounts.Find(toAccountId);
        //     fromAccount.Balance -= amount;
        //     toAccount.Balance += amount;
        //     _context.SaveChanges();
        // }


        public bool Deposit(BankRequest model)
        {
            // map model to new account object
            var account = _mapper.Map<Bank>(model);
            account.Date = DateTime.UtcNow;
            account.isPaid = false;
            // save account
            _context.Banks.Add(account);
            _context.SaveChanges();

            return ResetReferrerCount(model.ArtisanId);
        }

        private bool ResetReferrerCount(int artisanId)
        {
            var artisan = _context.Artisans.Find(artisanId);
            artisan.RefererCount = 0;
            _context.SaveChanges();
            return true;
        }

        public BankResponse GetAccount(int accountId)
        {
            var account = _context.Banks.Find(accountId);
            return _mapper.Map<BankResponse>(account);
        }

        public IEnumerable<BankResponse> GetAccounts()
        {
            var accounts = _context.Banks.ToList();
            return _mapper.Map<List<BankResponse>>(accounts);
        }

        public IEnumerable<BankResponse> GetAccounts(int userId)
        {
            var accounts = _context.Banks.Where(x => x.ArtisanId == userId).ToList();
            return _mapper.Map<List<BankResponse>>(accounts);
        }

        public bool MakePayment(int accountId)
        {
            var account = _context.Banks.Find(accountId);
            account.isPaid = true;
            _context.Banks.Update(account);
            _context.SaveChanges();
            return true;
        }
    }
}