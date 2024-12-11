using School.Core.Entities;
using School.DataAccess.Persistence;

namespace School.DataAccess.Repositories.Impl;

public class EventRepository : BaseRepository<Event>, IEventRepository
{
    public EventRepository(DatabaseContext context) : base(context) { }
}
