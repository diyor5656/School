using School.Core.Entities;
using School.DataAccess.Persistence;

namespace School.DataAccess.Repositories.Impl;

public class ExamRepository : BaseRepository<Exam>, IExamRepository
{
    public ExamRepository(DatabaseContext context) : base(context) { }
}
