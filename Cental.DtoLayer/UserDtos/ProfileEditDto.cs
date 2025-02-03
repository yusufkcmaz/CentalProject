using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.UserDtos 
{
    public class ProfileEditDto
    {
        public String FirstName {  get; set; }
        public String LastName {  get; set; }
        public String Email {  get; set; }
        public String PhoneNumber {  get; set; }
        public String ImageUrl {  get; set; }
        public IFormFile ImageFile {  get; set; }
        public string CurrentPassword { get; set; }
    }
}
