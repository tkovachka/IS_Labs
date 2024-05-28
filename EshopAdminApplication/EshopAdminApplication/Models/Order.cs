namespace EshopAdminApplication.Models
{
    public class Order : BaseEntity
    {
        public string? OwnerId { get; set; }
        public Ticket? Owner { get; set; }
        public ICollection<TicketInOrder>? ProductInOrders { get; set; }
    }
}
