using EShop.Domain.Domain;

namespace EShop.Repository.Interface
{
    public interface ITicketRepository
    {
        List<Ticket> GetAll();
        Ticket GetDetailsForTickets(Guid? id);
    }
}
