using ProductCatalog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCatalog.Interfaces;
using ProductCatalog.ViewModel.ProductViewModel;
using Microsoft.EntityFrameworkCore;

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
    }
}
