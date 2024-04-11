using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgileWorks.Data;
using AgileWorks.Models;

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
                DateTime dueDate = ticket.DueDate;
                DateTime targetTIme = DateTime.Now.AddHours(1);

                if(dueDate < targetTIme) {
                    ticket.MarkedAsUrgent = true;
                }
            });
            return View(tickets);
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

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }
    }
}
