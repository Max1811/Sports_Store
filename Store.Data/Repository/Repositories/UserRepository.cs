using SportsStore.Data.Entities;
using Store.Data.ApplicationContext;
using Store.Data.Repository.EFGenericRepository;
using Store.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
