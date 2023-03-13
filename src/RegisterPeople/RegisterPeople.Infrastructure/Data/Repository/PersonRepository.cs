using Microsoft.EntityFrameworkCore;
using RegisterPeople.Domain.Entitys;
using RegisterPeople.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeople.Infrastructure.Data.Repository
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        private readonly SqlContext _sqlContext;

        public PersonRepository(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _sqlContext.Person.Include(x => x.Address).OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Person> GetById(int id)
        {
            return await _sqlContext.Person.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
