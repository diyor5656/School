using School.Core.Entities;
using School.DataAccess.Persistence;

namespace School.DataAccess.Repositories.Impl;

public class StudentRepository : BaseRepository<Student>, IStudentRepository
{
    public StudentRepository(DatabaseContext context) : base(context) { }
}
