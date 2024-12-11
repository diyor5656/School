using School.Core.Entities;
using School.DataAccess.Persistence;

namespace School.DataAccess.Repositories.Impl;

public class FeedBackRepository : BaseRepository<Feedback>, IFeedBackRepository
{
    public FeedBackRepository(DatabaseContext context) : base(context) { }
}
