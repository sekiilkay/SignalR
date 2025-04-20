using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Repository.Context;

namespace SignalR.Repository.Repositories
{
    public class MessageRepository(SignalRContext context) : GenericRepository<Message>(context), IMessageRepository
    {
    }
}
