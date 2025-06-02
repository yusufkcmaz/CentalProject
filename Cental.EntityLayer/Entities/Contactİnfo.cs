using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class ContactInfo 
    {
        public int ContactInfoId { get; set; }
        public string? Adress { get; set; }
        public string? Mail { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FaxsNumber { get; set; }
       

    }
}
