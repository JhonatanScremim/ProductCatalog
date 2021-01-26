using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.ViewModel.ProductViewModel
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime BirthDate { get; set; }
    }
}
