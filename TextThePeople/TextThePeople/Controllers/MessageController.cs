using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using TextThePeople.DAL;
using Twilio;

namespace TextThePeople.Controllers
{
    public class MessageController : ApiController
    {
        TextThePeopleContext db;
        private string defaultNumber = "+13059096944"; // adrian's twilio phone number

        public MessageController()
        {
            db = new TextThePeopleContext();
        }

        public MessageController(TextThePeopleContext context)
        {
            db = context;
        }

        // POST api/sendmessage?from,to,message
        public void Post(string from, string to, string message) 
        {
            from = from ?? defaultNumber;

            var accountSid = "AC3c18b86d6c4941dc9ea2c15f090f6d03";
            var authToken = "3a401907393636c13902e6ef930a0e76";
            var twilioClient = new TwilioRestClient(accountSid, authToken);

            twilioClient.SendMessage(from, Normalize(to), message, new string[0]);
        }

        [HttpPost]
        // POST api/groupmessage?from,recipients,message
        public void Post(string from, IEnumerable<string> recipients, string message) 
        {
            from = from ?? defaultNumber;

            var accountSid = "AC3c18b86d6c4941dc9ea2c15f090f6d03";
            var authToken = "3a401907393636c13902e6ef930a0e76";
            var twilioClient = new TwilioRestClient(accountSid, authToken);

            foreach (var number in recipients)
            {
                twilioClient.SendMessage(from, Normalize(number), message, new string[0]);
            }
        }

        private string Normalize(string to)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < to.Length; i++)
                if (char.IsNumber(to[i])) sb.Append(to[i]);

            if (sb.Length == 10) return sb.ToString();
            else return ""; // invalid number

        }
    }
}