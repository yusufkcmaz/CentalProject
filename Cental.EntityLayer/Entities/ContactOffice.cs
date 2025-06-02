using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class ContactOffice
    {
        public int ContactOfficeId { get; set; }
        public string Title { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string OfficeAdress { get; set; }
        public string Mapurl { get; set; }
    }
}
