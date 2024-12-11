using School.Core.Entities;
using School.DataAccess.Persistence;

namespace School.DataAccess.Repositories.Impl;

public class LeesonSchudeRepository : BaseRepository<Lesson>, ILessonRepository
{
    public LeesonSchudeRepository(DatabaseContext context) : base(context) { }
}
