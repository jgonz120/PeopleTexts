using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextThePeople.Models
{
    public class Logs
    {
        public int LogsId { get; set; }
        public string Message { get; set; }
        public DateTime DateSet { get; set; }
        public string Error { get; set; }
        public virtual Persons Person { get; set; }
    }
}