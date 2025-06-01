using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osus.Core.Enums;

namespace Osus.Core
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public Guid Password { get; set; }
        public UserRole UserRole { get; set; }
    }
}
