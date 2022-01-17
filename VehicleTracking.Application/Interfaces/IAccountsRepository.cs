using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Entity.Entities;

namespace VehicleTracking.Application.Interfaces
{
    public interface IAccountsRepository: IAsyncRepository<User>
    {
    }
}
