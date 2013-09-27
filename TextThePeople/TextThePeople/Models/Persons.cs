using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextThePeople.Models
{
    public class Persons
    {
        public int PersonsId { get; set; }
        public int OSEntityPK { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Logs> Logs { get; set; }

    }
}