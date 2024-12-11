using School.Core.Entities;
using School.DataAccess.Persistence;

namespace School.DataAccess.Repositories.Impl;

public class RoomRepository : BaseRepository<Room>, IRoomRepository
{
    public RoomRepository(DatabaseContext context) : base(context) { }
}
