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
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Ticket> _entities;

        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = _context.Set<Ticket>();
        }

        public List<Ticket> GetAll()
        {
            return _entities
                .Include(z => z.Concert)
                .ToList();
        }

        public Ticket GetDetailsForTickets(Guid? id)
        {
            return _entities
                .Include(z => z.Concert)
                .SingleOrDefaultAsync(z => z.Id == id).Result;
        }
    }
}
