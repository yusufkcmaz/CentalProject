using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.TestimonialDtos
{
    public class CreateTestimonialDto
    {
       
        public string? ImageUrl { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int Review { get; set; }
        public string? Commend { get; set; }
    }
}
