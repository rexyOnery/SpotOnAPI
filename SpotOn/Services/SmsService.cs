using WebApi.Models.SMS;
using AutoMapper;
using Microsoft.Extensions.Options;
using System.IO;
using System.Net;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface ISmsService
    {
        void SendCollectedSms(int CustomerId);
        void SendPickUpSMS(int customerId, int totalItems, string price);
        void SendAdminOffSiteCustomerSms();
    }

    public class SmsService : ISmsService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly SmsSettings _smsSettings;
        public SmsService(
            DataContext context,
            IMapper mapper,
            IOptions<SmsSettings> smsSettings)
        {
            _context = context;
            _mapper = mapper;
            _smsSettings = smsSettings.Value;
        }

        public void SendCollectedSms(int customerId)
        {
            string message;
            var customer = _context.Artisans.Find(customerId);

            message = $@"You've colledted your clothes. Thanks for your patronage!";

            var SMSRequest = new SMSRequest();
            SMSRequest.Phone = customer.Phone;
            SMSRequest.Message = message;

            SendSMS(SMSRequest);
        }

        public void SendPickUpSMS(int customerId, int totalItems, string price)
        {
            string message;
            var customer = _context.Artisans.Find(customerId);

            message = $@"We recieved your request. Total Number of item(s) received: {totalItems}. Total Cost: {price}";

            var SMSRequest = new SMSRequest();
            SMSRequest.Phone = customer.Phone;
            SMSRequest.Message = message;

            SendSMS(SMSRequest);
        }

        public void SendAdminOffSiteCustomerSms()
        {
            string message;

            message = $@"You have a new request. Please assign an agent to the customer!";

            var SMSRequest = new SMSRequest();
            SMSRequest.Phone = _smsSettings.AdminPhone;
            SMSRequest.Message = message;

            SendSMS(SMSRequest);
        }

        private void SendSMS(SMSRequest model)
        {
            string sender = _smsSettings.Sender;
            string to = model.Phone;
            string token = _smsSettings.Token;
            int routing = _smsSettings.Routing;
            int type = _smsSettings.Type;
            string baseurl = _smsSettings.BaseUrl;
            string url = baseurl + "message=" + model.Message + "&to=" + to + "&sender=" + sender + "&type=" + type + "&routing=" + routing + "&token=" + token;

            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(string.Format(url));
            webReq.Method = "GET";
            HttpWebResponse webResponse = (HttpWebResponse)webReq.GetResponse();
            Stream answer = webResponse.GetResponseStream();
            StreamReader _recivedAnswer = new StreamReader(answer);
            var ans = _recivedAnswer.ReadToEnd();
        }



    }
}
