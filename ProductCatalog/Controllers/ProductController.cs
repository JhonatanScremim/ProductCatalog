using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Models;
using ProductCatalog.Data;
using ProductCatalog.ViewModel;
using ProductCatalog.ViewModel.ProductViewModel;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Repositorys;
using ProductCatalog.Interfaces;

namespace ProductCatalog.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly IProductRepository _repository;
        public ProductController(IProductService service, IProductRepository repository)
        {
            _service = service;
            _repository = repository;
        }
        
        [Route("v1/products")]
        [HttpGet]
        public IEnumerable<ListProductViewModel> Get()
        {
            return _service.Get();
        }

        [Route("v1/products/{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            return Ok(result);
        }

        [Route("v1/products")]
        [HttpPost]
        public ResultViewModel Post([FromBody]EditorProductViewModel model)
        {
            model.Validate();
            if (model.Invalid)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possivel efetuar o cadastro",
                    Data = model.Notifications 
                };
            }
            var product = _service.Post(model);

            return new ResultViewModel
            {
                Success = true,
                Message = "Cadastro realizado com sucesso.",
                Data = product
            };
        }

        [Route("v1/products")]
        [HttpPut]
        public ResultViewModel Put([FromBody] EditorProductViewModel model)
        {
            var product = _service.Put(model);

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto atualizado.",
                Data = product
            };
        }

        [Route("v1/products")]
        [HttpDelete]
        public ResultViewModel Delete([FromBody]Product product)
        {
            _service.Delete(product);

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto removido."
            };
        }
    }
}
