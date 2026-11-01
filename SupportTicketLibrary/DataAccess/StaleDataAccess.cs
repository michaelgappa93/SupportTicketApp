using CsvHelper;
using CsvHelper.Linq;
using SupportTicketLibrary.Interface;
using SupportTicketLibrary.Models;
using System.Linq;
using Z.Expressions;
namespace SupportTicketLibrary.DataAccess
{
    public class StaleDataAccess
    {

        public List<TicketModel> LoadData(string query)
        {
            
            string filePath = "C:\\Users\\mgapp\\source\\repos\\SupportTicketLibrary\\Data\\data.csv";
            using (var csvFile = CsvReader.FromFile(filePath))
            {
                var data = csvFile.Query().WhereDynamic(query).ToList();
                List<TicketModel> tickets = new List<TicketModel>();
                foreach (var item in data)
                {
                    TicketModel.Status ticketStatus = Enum.Parse<TicketModel.Status>(item.GetValueOrDefault("TicketStatus"));
                    TicketModel.Priority ticketPriority = Enum.Parse<TicketModel.Priority>(item.GetValueOrDefault("TicketPriority"));
                    tickets.Add(new TicketModel()
                    {
                        Title = item.GetValueOrDefault("Title"),
                        Description = item.GetValueOrDefault("Description"),
                        TicketStatus = ticketStatus,
                        TicketPriority = ticketPriority
                    });
                }
                return tickets;
            };
        }

        public void SaveData(string parameters)
        {
            throw new NotImplementedException();
        }
    }
}
