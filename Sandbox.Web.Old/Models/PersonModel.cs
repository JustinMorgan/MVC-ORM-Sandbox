using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sandbox.Web.Models
{
    public class PersonModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}