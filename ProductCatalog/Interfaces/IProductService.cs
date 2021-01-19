using ProductCatalog.Models;
using ProductCatalog.ViewModel.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ListProductViewModel> Get();
        Product GetById(int id);
        Product Post(EditorProductViewModel model);
        Product Put(EditorProductViewModel model);
        void Delete(Product product);
    }
}
