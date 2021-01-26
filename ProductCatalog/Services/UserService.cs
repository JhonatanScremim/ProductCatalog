using ProductCatalog.Interfaces;
using ProductCatalog.Models;
using ProductCatalog.ViewModel.ProductViewModel;
using ProductCatalog.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UserViewModel> Get()
        {
            return _repository.Get();
        }

        public User PostUser(EditorUserViewModel model)
        {
            var user = _repository.PostUser(model);
            _repository.Save(user);
            return user;
        }
    }
}
