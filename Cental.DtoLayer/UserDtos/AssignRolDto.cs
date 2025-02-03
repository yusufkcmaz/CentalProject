using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.UserDtos
{
    public class AssignRolDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public bool RoleExist { get; set; } 
        public string RoleName { get; set; }
    }
}
