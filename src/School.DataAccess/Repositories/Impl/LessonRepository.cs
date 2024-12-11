using School.Core.Entities;
using School.DataAccess.Persistence;

namespace School.DataAccess.Repositories.Impl;

public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
{
    public LessonRepository(DatabaseContext context) : base(context) { }
}
