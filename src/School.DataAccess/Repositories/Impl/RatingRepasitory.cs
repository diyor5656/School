using School.Core.Entities;
using School.DataAccess.Persistence;

namespace School.DataAccess.Repositories.Impl;

public class RatingRepository : BaseRepository<Rating>, IRatingRepository
{
    public RatingRepository(DatabaseContext context) : base(context) { }
}
