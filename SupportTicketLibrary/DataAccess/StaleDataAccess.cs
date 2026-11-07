using CsvHelper;
using CsvHelper.Linq;
using SupportTicketLibrary.Models;
using System.Linq;
using Z.Expressions;
namespace SupportTicketLibrary.DataAccess
{
    public class StaleDataAccess
    {
        public string FilePath { get; set; }
        public enum Mode
        {
            Add,
            Update,
            Delete
        }

        public Mode SaveMode { get; set; }
        public List<TicketModel> LoadData(string? query = null)
        {
            
            string filePath = FilePath;
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
            string filePath = FilePath;
            var table = CsvQueryable.FromFile<TicketModel>(filePath);
            if (saveMode == StaleDataAccess.Mode.Add)
            {
                table.AppendRecords(new[] { ticket });
            }
            else if (saveMode == StaleDataAccess.Mode.Delete)
            {
                table.Delete(x => x.Id == ticket.Id);
            }
            else if (saveMode == StaleDataAccess.Mode.Update)
            {
                List<TicketModel> tickets = LoadData();
                tickets.RemoveAll(x => x.Id == ticket.Id);
                tickets.Add(ticket);
                tickets.WriteCsv(filePath);
            }
        }
    }
}
