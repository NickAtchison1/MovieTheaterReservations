using MovieTheaterReservations.DisplayModels.Ticket;

namespace MovieTheaterReservations.Services.Services.TicketService
{
    public interface ITicketService
    {
        bool CreateTicket(TicketCreate ticketCreate, string userId);
        bool DeleteTicket(int id);
        IEnumerable<TicketListItem> GetAllTickets();
        TicketDetail GetTicket(int id);
        bool UpdateTicket(TicketEdit ticketEdit, string userId);
    }
}