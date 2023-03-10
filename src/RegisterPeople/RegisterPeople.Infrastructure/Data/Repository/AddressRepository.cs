using Microsoft.EntityFrameworkCore;
using RegisterPeople.Domain.Entitys;
using RegisterPeople.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeople.Infrastructure.Data.Repository
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        private readonly SqlContext _sqlContext;

        public AddressRepository(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task<IEnumerable<Address>> GetByIdPerson(int idPerson)
        {
            return await _sqlContext.Address.Where(x => x.IdPerson == idPerson).ToListAsync();
        }
    }
}
