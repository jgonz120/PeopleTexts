using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TextThePeople.Models
{
    public class Persons
    {
        public int PersonsId { get; set; }
        public int OSEntityPK { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(11, MinimumLength = 11)]
        public string PhoneNumber { get; set; }

        public int PersonType { get; set; }

        public virtual ICollection<Logs> Logs { get; set; }

    }
}