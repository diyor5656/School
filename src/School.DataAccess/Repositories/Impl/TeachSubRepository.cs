using School.Core.Entities;
using School.DataAccess.Persistence;
using School.DataAccess.Repositories.Impl;
using School.Core.Entities;
using School.DataAccess.Persistence;

namespace School.DataAccess.Repositories.Impl;

public class TeachSubRepository : BaseRepository<TeachSub>, ITeachSubRepository
{
    public TeachSubRepository(DatabaseContext context) : base(context) { }
}
