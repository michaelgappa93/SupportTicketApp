using SupportTicketLibrary.DataAccess;
using SupportTicketLibrary.Models;

namespace SupportTicketLibrary.Service
{
    public class TicketService
    {
        private readonly StaleDataAccess _dataAccess;

        public TicketService(StaleDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public void CreateTicket(TicketModel ticket)
        {
            _dataAccess.SaveData(ticket, StaleDataAccess.Mode.Add);
        }

        public void DeleteTicket(TicketModel ticket)
        {
            _dataAccess.SaveData(ticket, StaleDataAccess.Mode.Delete);
        }

        public List<TicketModel> GetTicketsByStatus(TicketModel.Status status)
        {
            List<TicketModel> tickets = _dataAccess.LoadData($"x => x.TicketStatus == {status}");
            return tickets;
        }

        public TicketModel GetTicketById(int id)
        {
            TicketModel ticket = _dataAccess.LoadData($"x => x.Id == {id}").First();
            return ticket;
        }

        public List<TicketModel> GetTickets()
        {
            List<TicketModel> tickets = _dataAccess.LoadData();
            return tickets;
        }

        public void UpdateTicket(TicketModel ticket)
        {
            _dataAccess.SaveData(ticket, StaleDataAccess.Mode.Update);
        }
    }
}
