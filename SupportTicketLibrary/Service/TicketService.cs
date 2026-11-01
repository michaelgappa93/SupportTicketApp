using SupportTicketLibrary.Interface;
using SupportTicketLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportTicketLibrary.Service
{
    public class TicketService
    {
        public Task<IAsyncResult> CreateTicket(TicketModel ticket)
        {
            throw new NotImplementedException();
        }

        public Task<IAsyncResult> DeleteTicket(TicketModel ticket)
        {
            throw new NotImplementedException();
        }

        public Task<TicketModel> GetTicektByStatus(TicketModel.Status status)
        {
            throw new NotImplementedException();
        }

        public Task<TicketModel> GetTicketById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TicketModel>> GetTickets()
        {
            throw new NotImplementedException();
        }

        public Task<IAsyncResult> UpdateStatus(TicketModel ticket)
        {
            throw new NotImplementedException();
        }
    }
}
