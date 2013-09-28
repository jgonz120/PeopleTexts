using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using TextThePeople.DAL;
using System.Linq;
using Twilio;
using TextThePeople.Models;
using System.Net;
using System;

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
        [HttpPost]
        public HttpResponseMessage Post(string from, string to, string osentityId,string message) 
        {
            from = from ?? defaultNumber;
            Persons person;
            try
            {
                if (osentityId != null)
                    person = db.Persons.ToList().Where(x => x.OSEntityPK.ToString() == osentityId).First();
                else
                    person = db.Persons.ToList().Where(x => x.PhoneNumber == to).First();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var accountSid = "AC3c18b86d6c4941dc9ea2c15f090f6d03";
            var authToken = "3a401907393636c13902e6ef930a0e76";
            var twilioClient = new TwilioRestClient(accountSid, authToken);

            try
            {
                twilioClient.SendMessage(from, Normalize(to), message, new string[0]);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }



        //[HttpPost]
        //// POST api/groupmessage?from,recipients,message
        //public void Post(string from, IEnumerable<string> recipients, string message) 
        //{
        //    from = from ?? defaultNumber;

        //    var accountSid = "AC3c18b86d6c4941dc9ea2c15f090f6d03";
        //    var authToken = "3a401907393636c13902e6ef930a0e76";
        //    var twilioClient = new TwilioRestClient(accountSid, authToken);

        //    foreach (var number in recipients)
        //    {
        //        twilioClient.SendMessage(from, Normalize(number), message, new string[0]);
        //    }
        //}

        private string Normalize(string to)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < to.Length; i++)
                if (char.IsNumber(to[i])) sb.Append(to[i]);

            if (sb.Length == 11) return sb.ToString();
            else return ""; // invalid number

        }
    }
}