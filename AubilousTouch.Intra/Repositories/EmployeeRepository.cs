using AubilousTouch.Core.Interfaces.Repositories;
using AubilousTouch.Core.Models;
using AubilousTouch.Intra.Context;
using AubilousTouch.Intra.Repositories.Base;
using System.Threading.Tasks;

namespace AubilousTouch.Intra.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AubilousTouchDbContext context) : base(context)
        {

        }

    }
}
