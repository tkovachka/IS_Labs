using EShop.Domain.Domain;
using EShop.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Order> _entities;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = _context.Set<Order>();
        }

        public List<Order> GetAllOrders()
        {
            return _entities
                .Include(z => z.ProductInOrders)
                .Include(z => z.Owner)
                .Include("ProductInOrders.OrderedProduct")
                .ToList();
        }

        public Order GetDetailsForOrder(BaseEntity id)
        {
            return _entities
                .Include(z => z.ProductInOrders)
                .Include(z => z.Owner)
                .Include("ProductInOrders.OrderedProduct")
                .Include("ProductInOrders.OrderedProduct.Concert")
                .SingleOrDefaultAsync(z => z.Id.Equals(id.Id)).Result;
        }
    }
}
