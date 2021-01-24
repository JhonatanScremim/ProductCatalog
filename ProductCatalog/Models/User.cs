using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Models
{
    public class User
    {
        public virtual int UserId { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual DateTime DateRegistered { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
