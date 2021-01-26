using ProductCatalog.Models;
using ProductCatalog.ViewModel.ProductViewModel;
using ProductCatalog.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserViewModel> Get();
        User PostUser(EditorUserViewModel model);
    }
}
