using ProductCatalog.ViewModel.ProductViewModel;
using ProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<ListProductViewModel> Get();
        Product GetById(int id);
        Product Post(EditorProductViewModel model);
        Product Put(EditorProductViewModel model);
        void Save(Product product);
        void Update(Product product);
        void Delete(Product product);

    }
}
