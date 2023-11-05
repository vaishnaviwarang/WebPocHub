using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebPOCHub.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        [MaxLength(30)]
        public string RoleName { get; set; } = string.Empty;
        [MaxLength(300)]
        public string RoleDescription { get; set; } = String.Empty;
        public ICollection<User>? Users { get; set; }    
    }
}
