using WebApplication1.Common;
using WebApplication1.Data;
using WebApplication1.Model.Entity;

namespace WebApplication1.Repository.VisitorRepositories
{
    public class VisitorRepository : QueryableRepository<Visitor>, IVisitorRepository
    {
        private readonly DatabaseContext _context;
        public VisitorRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
            this._context = databaseContext;
        }
    }
}
