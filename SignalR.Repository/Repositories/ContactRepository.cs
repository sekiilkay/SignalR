using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Repository.Context;

namespace SignalR.Repository.Repositories
{
    public class ContactRepository(SignalRContext context) : GenericRepository<Contact>(context), IContactRepository
    {
    }
}
