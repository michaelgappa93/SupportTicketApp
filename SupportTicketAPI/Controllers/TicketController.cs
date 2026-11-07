using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportTicketLibrary.Service;
namespace SupportTicketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketService _ticketService;
        public TicketController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public IActionResult GetTickets()
        {
            var tickets = _ticketService.GetTickets();
            return Ok(tickets);
        }

        [HttpGet]
        public IActionResult GetTicketById(string id)
        {
            var ticket = _ticketService.GetTicketById(int.Parse(id));
            return Ok(ticket);
        }

        [HttpGet]
        public IActionResult GetTicketsByStatus(string status)
        {
            var tickets = _ticketService.GetTicketsByStatus((SupportTicketLibrary.Models.TicketModel.Status)Enum.Parse(typeof(SupportTicketLibrary.Models.TicketModel.Status), status));
            return Ok(tickets);
        }

        [HttpPost]
        public IActionResult CreateTicket([FromBody] SupportTicketLibrary.Models.TicketModel ticket)
        {
            _ticketService.CreateTicket(ticket);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteTicket([FromRoute] string id)
        {
            var ticket = _ticketService.GetTicketById(int.Parse(id));
            _ticketService.DeleteTicket(ticket);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateTicket([FromRoute] string id, [FromBody] SupportTicketLibrary.Models.TicketModel ticket)
        {
            ticket.Id = int.Parse(id);
            _ticketService.UpdateTicket(ticket);
            return Ok();
        }
    }
}
