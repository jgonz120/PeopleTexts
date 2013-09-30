using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextThePeople.Models
{
    public class MessageDataDTO
    {
        public IEnumerable<string> Recipients { get; set; }
        public string Message { get; set; }
    }
}