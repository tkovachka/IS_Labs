using System.ComponentModel.DataAnnotations;

namespace EshopAdminApplication.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
