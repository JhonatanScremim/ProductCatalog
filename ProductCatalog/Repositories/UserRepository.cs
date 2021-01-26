using ProductCatalog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCatalog.Interfaces;
using ProductCatalog.ViewModel.ProductViewModel;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Models;
using ProductCatalog.ViewModel.UserViewModel;

namespace ProductCatalog.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDataContext _context;

        public UserRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<UserViewModel> Get()
        {
            return _context.Users
                .Select(x => new UserViewModel()
                {
                    UserId = x.UserId,
                    UserName = x.UserName,
                    Email = x.Email,
                    BirthDate = x.BirthDate
                }).AsNoTracking().ToList();
        }

        public User PostUser(EditorUserViewModel model)
        {
            var user = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
                BirthDate = Convert.ToDateTime(model.BirthDate),
                CreateDate = DateTime.Now,
                IsActive = true
            };
            return user;
            
        }

        public void Save(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
