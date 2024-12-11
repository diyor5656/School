using School.Core.Entities;
using School.DataAccess.Persistence;

namespace School.DataAccess.Repositories.Impl;

public class CourseRepository : BaseRepository<Course>, ICourseRepository
{
    public CourseRepository(DatabaseContext context) : base(context) { }
}
