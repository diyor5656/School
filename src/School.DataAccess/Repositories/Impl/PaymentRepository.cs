using School.Core.Entities;
using School.DataAccess.Persistence;

namespace School.DataAccess.Repositories.Impl;

public class PaymentRepository : BaseRepository<Payment>, IPyamentRepository
{
    public PaymentRepository(DatabaseContext context) : base(context) { }
}
