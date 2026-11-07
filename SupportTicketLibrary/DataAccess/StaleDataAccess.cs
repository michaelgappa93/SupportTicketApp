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
        public enum Mode
        {
            Delete,
            Add
        }

        public Mode SaveMode { get; set; }
        public List<TicketModel> LoadData(string? query = null)
        {
            
            string filePath = "C:\\Users\\mgapp\\source\\repos\\SupportTicketApp\\SupportTicketLibrary\\Data\\data.csv";
            using (var csvFile = CsvReader.FromFile(filePath))
            {
                var tickets = csvFile.GetRecords<TicketModel>().ToList();
                if (query != null)
                {
                    return tickets.WhereDynamic(query).ToList();
                }
                return tickets;
            }
            ;
        }

        public void SaveData(TicketModel ticket, StaleDataAccess.Mode saveMode)
        {
            List<TicketModel> tickets = LoadData();
            tickets.Add(ticket);
            string filePath = "C:\\Users\\mgapp\\source\\repos\\SupportTicketApp\\SupportTicketLibrary\\Data\\data.csv";
            var table = CsvQueryable.FromFile<TicketModel>(filePath);
            if (saveMode == StaleDataAccess.Mode.Add)
            {
                table.AppendRecords(new[] { ticket });
            }
            else if (saveMode == StaleDataAccess.Mode.Delete)
            {
                table.Delete(x => x.Id == ticket.Id);
            }
        }
    }
}
