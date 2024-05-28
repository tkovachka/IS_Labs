using System.ComponentModel.DataAnnotations;
using System;
using EshopAdminApplication.Models.Identity;

namespace EshopAdminApplication.Models
{
    public class Ticket : BaseEntity
    {
        public Guid ConcertId { get; set; }
        public Concert? Concert { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public double Rating { get; set; }
        public EShopApplicationUser? CreatedBy { get; set; }
        public ICollection<TicketInShoppingCart>? ProductsInShoppingCart { get; set; }
        public ICollection<TicketInOrder>? ProductInOrders { get; set; }
    }
}
