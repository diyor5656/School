using School.Core.Entities;
using School.DataAccess.Persistence;

namespace School.DataAccess.Repositories.Impl;

public class GroupRepository : BaseRepository<Group>, IGroupRepository
{
    public GroupRepository(DatabaseContext context) : base(context) { }
}
