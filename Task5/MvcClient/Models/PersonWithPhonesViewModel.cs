using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcClient.Models
{
    public class PersonWithPhonesViewModel
    {
        public Person Owner { get; set; }
        public IEnumerable<Phone> Phones { get; set; }
    }
}