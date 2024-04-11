using AgileWorks.Models;

namespace AgileWorks.Helpers {
    public static class TicketHelper {
        public static Ticket MarkAsUrgentBasedOnTargetTime(Ticket ticket, DateTime targetTime) {
            if(ticket.DueDate < targetTime) ticket.MarkedAsUrgent = true;
            return ticket;
        }
    }
}
