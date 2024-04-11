using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgileWorks.Data;
using AgileWorks.Models;
using AgileWorks.Helpers;

namespace AgileWorks.Controllers
{
    public class TicketsController : Controller
    {
        private readonly TicketDatabaseContext _context;

        public TicketsController(TicketDatabaseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "All Tickets";
            List<Ticket> tickets = await _context.Ticket.ToListAsync();

            tickets.ForEach((ticket) => {
                DateTime targetTime = DateTime.Now.AddHours(1);
                ticket = TicketHelper.MarkAsUrgentBasedOnTargetTime(ticket, targetTime);
            });

            IEnumerable<Ticket> ascendinglyOrderedTickets = tickets.OrderBy((ticket) => ticket.DueDate);
            return View(ascendinglyOrderedTickets);
        }
        public IActionResult Create()
        {
            ViewData["Title"] = "Create";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,DueDate")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket != null)
            {
                _context.Ticket.Remove(ticket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }
    }
}
