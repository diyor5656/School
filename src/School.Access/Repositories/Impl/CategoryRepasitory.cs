using School.Core.Entities;
using School.Access.Persistence;

namespace School.Access.Repositories.Impl;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(DatabaseContext context) : base(context) { }
}
