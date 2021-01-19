using System.Collections.Generic;
using System.Linq;
using ProductCatalog.Models;
using ProductCatalog.Data;
using ProductCatalog.ViewModel.ProductViewModel;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Interfaces;
using System;

namespace ProductCatalog.Repositorys
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDataContext _context;
        
        public ProductRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<ListProductViewModel> Get()
        {
            return _context.Products
                .Include(x => x.Category)
                .Select(x => new ListProductViewModel()
                {
                    Id = x.IdProduct,
                    Title = x.Title,
                    Price = x.Price,
                    IdCategory = x.IdCategory,
                    Category = x.Category.Title
                })
                .AsNoTracking().ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
            // Foi usado o Find() para o método ser usado em dois locais, veja o método de Update na controller
        }

        public Product Post(EditorProductViewModel model)
        {
            var product = new Product();
            product.Title = model.Title;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Quantity = model.Quantity;
            product.Image = model.Image;
            product.CreateDate = DateTime.Now;
            product.LastUpdateDate = DateTime.Now;
            product.IdCategory = model.IdCategory;
            return product;
        }

        public Product Put(EditorProductViewModel model)
        {
            var product = _context.Products.Find(model.IdProduct);
            product.Title = model.Title;
            product.IdCategory = model.IdCategory;
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now;
            product.Price = model.Price;
            product.Quantity = model.Quantity;
            return product;
        }

        public void Save(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Entry<Product>(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
