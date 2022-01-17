using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Application.Interfaces;
using VehicleTracking.Entity.Entities;
using VehicleTracking.Infrastructure.Context;

namespace VehicleTracking.Infrastructure.Repositories
{
    public class AccountsRepository : RepositoryBase<User>, IAccountsRepository
    {
        public AccountsRepository(DataContext context): base(context)
        {

        }
    }
}
