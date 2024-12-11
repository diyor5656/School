using School.Core.Entities;
using School.DataAccess.Persistence;

namespace School.DataAccess.Repositories.Impl;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(DatabaseContext context) : base(context) { }
}
