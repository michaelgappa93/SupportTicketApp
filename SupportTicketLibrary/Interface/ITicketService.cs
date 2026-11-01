using SupportTicketLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportTicketLibrary.Interface
{
    public interface ITicketService
    {
        Task<List<TicketModel>> GetTickets();
        Task<TicketModel> GetTicketById(int id);
        Task<TicketModel> GetTicektByStatus(TicketModel.Status status);
        Task<IAsyncResult> CreateTicket(TicketModel ticket);
        Task<IAsyncResult> UpdateStatus(TicketModel ticket);
        Task<IAsyncResult> DeleteTicket(TicketModel ticket);

    }
}
