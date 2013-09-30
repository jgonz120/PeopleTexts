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
        private Dictionary<string, TwilioAccountInfo> credentials = new Dictionary<string, TwilioAccountInfo>()
        {
            {"+13059096944", new TwilioAccountInfo(){Phone = "+13059096944", AccountSid = "AC3c18b86d6c4941dc9ea2c15f090f6d03", AuthToken = "3a401907393636c13902e6ef930a0e76"}}, // adrian
            {"+19542411967", new TwilioAccountInfo(){Phone = "+19542411967", AccountSid = "ACc2fca8682c1c54a181234efc4e1fe307", AuthToken = "6dc139931bac15710af5072925e2d4f1"}}, // jon
            {"+17862320454", new TwilioAccountInfo(){Phone = "+17862320454", AccountSid = "AC8b61c811de18b2fb9f03540cb0a7b056", AuthToken = "86e9ac5b91a5afb73006067f1c30258b"}}, // rene
            {"+19548839514", new TwilioAccountInfo(){Phone = "+19548839514", AccountSid = "ACd3277fec1228d5c50bd66dc910be1822 ", AuthToken = "f8b8e5cfe71b5fc1fac20109105555b2"}}, // laura
        };

        private string[] _numbers = new[] { "+13059096944", "+19542411967", "+17862320454", "+19548839514" };

        public MessageController()
        {
            db = new TextThePeopleContext();
        }

        public MessageController(TextThePeopleContext context)
        {
            db = context;
        }

        [HttpPost]
        public void Send(IEnumerable<string> recipients, string message)
        {
            var gen = new Random();

            foreach (var r in recipients)
            {
                Persons p;
                if (TryFindInDB(r, out p))
                {
                    int i = gen.Next(_numbers.Length);
                    var account = credentials[_numbers[i]];
                    try
                    {
                        var twilioClient = new TwilioRestClient(account.AccountSid, account.AuthToken);
                        twilioClient.SendMessage(account.Phone, Normalize(p.PhoneNumber), message, new string[0]);
                    }
                    catch
                    {
                        throw new HttpResponseException(HttpStatusCode.BadRequest);
                    }
                }
                else
                    throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        [NonAction]
        private bool TryFindInDB(string key, out Persons person)
        {
            person = null;
            try
            {
                var matchingEntity = from p in db.Persons.ToList()
                                     where p.OSEntityPK.ToString() == key || p.PhoneNumber == key
                                     select p;

                person = matchingEntity.Single();
            }
            catch (InvalidOperationException e) { return false; }
            return true;
        }

        [NonAction]
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