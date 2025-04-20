using SignalR.Core.UnitOfWork;
using SignalR.Repository.Context;

namespace SignalR.Repository.UnitOfWork
{
    public class UnitOfWork(SignalRContext context) : IUnitOfWork
    {
        public void SaveChanges() => context.SaveChanges();

        public async Task SaveChangesAsync() => await context.SaveChangesAsync();
    }
}
