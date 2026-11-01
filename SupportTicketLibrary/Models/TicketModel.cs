using System;
using System.Collections.Generic;
using System.Text;

namespace SupportTicketLibrary.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public enum Status
        {
            Active,
            Inactive
        }
        public Status TicketStatus { get; set; } = Status.Active;
        public enum Priority
        {
            Low,
            Medium,
            High
        }
        public Priority TicketPriority { get; set; }
    }
}
