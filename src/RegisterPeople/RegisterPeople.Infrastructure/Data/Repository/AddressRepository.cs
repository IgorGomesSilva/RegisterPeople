using RegisterPeople.Domain.Entitys;
using RegisterPeople.Domain.Interfaces.Repository;

namespace RegisterPeople.Infrastructure.Data.Repository
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        private readonly SqlContext _sqlContext;

        public AddressRepository(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}
