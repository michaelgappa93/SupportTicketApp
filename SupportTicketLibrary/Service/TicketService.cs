using SupportTicketLibrary.DataAccess;
using SupportTicketLibrary.Interface;
using SupportTicketLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportTicketLibrary.Service
{
    public class TicketService
    {
        private readonly StaleDataAccess _dataAccess;
        public void CreateTicket(TicketModel ticket)
        {
            _dataAccess.SaveData(ticket, StaleDataAccess.Mode.Add);
        }

        public void DeleteTicket(TicketModel ticket)
        {
            _dataAccess.SaveData(ticket, StaleDataAccess.Mode.Delete);
        }

        public TicketModel GetTicketByStatus(TicketModel.Status status)
        {
            TicketModel ticket = _dataAccess.LoadData($"x => x.TicketStatus == {status}").First();
            return ticket;
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

        public void UpdateStatus(TicketModel ticket)
        {
            _dataAccess.SaveData(ticket, StaleDataAccess.Mode.Update);
        }
    }
}
