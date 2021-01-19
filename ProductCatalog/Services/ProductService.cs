using ProductCatalog.Interfaces;
using ProductCatalog.Models;
using ProductCatalog.ViewModel;
using ProductCatalog.ViewModel.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ListProductViewModel> Get()
        {
            return _repository.Get();
        }
        public Product GetById(int id)
        {
            return _repository.GetById(id);
        }
        public Product Post(EditorProductViewModel model)
        {
            var product = _repository.Post(model);
            _repository.Save(product);
            return product;
        }
        public Product Put(EditorProductViewModel model)
        {
            var product = _repository.Put(model);
            _repository.Update(product);
            return product;
        }
        public void Delete(Product product)
        {
            _repository.Delete(product);
        }
    }
}
