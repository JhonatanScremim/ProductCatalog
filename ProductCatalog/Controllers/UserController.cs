using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Interfaces;
using ProductCatalog.ViewModel;
using ProductCatalog.ViewModel.ProductViewModel;
using ProductCatalog.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Controllers
{
    public class UserController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("v1/user")]
        public IEnumerable<UserViewModel> Get()
        {
            return _service.Get();
        }

        [HttpPost]
        [Route("v1/user")]
        public ResultViewModel PostUser([FromBody] EditorUserViewModel model)
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

            var user = _service.PostUser(model);

            return new ResultViewModel
            {
                Success = true,
                Message = "Cadastro realizado com sucesso.",
                Data = user
            };

        }
    }
}
