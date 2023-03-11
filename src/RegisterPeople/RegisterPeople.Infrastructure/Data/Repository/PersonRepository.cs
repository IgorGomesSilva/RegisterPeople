using RegisterPeople.Domain.Entitys;
using RegisterPeople.Domain.Interfaces.Repository;

namespace RegisterPeople.Infrastructure.Data.Repository
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        private readonly SqlContext _sqlContext;

        public PersonRepository(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}
