using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Repository.Context;

namespace SignalR.Repository.Repositories
{
    public class TestimonialRepository(SignalRContext context) : GenericRepository<Testimonial>(context), ITestimonialRepository
    {
    }
}
