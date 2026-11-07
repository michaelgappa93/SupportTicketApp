using SupportTicketLibrary.DataAccess;
using SupportTicketLibrary.Models;
namespace UnitTextSupportTicketLibrary
{
    public class UnitTestStaleDataAccess
    {
        [Fact]
        public void TestFilePath()
        {
            StaleDataAccess staleDataAccess = new StaleDataAccess();
            staleDataAccess.FilePath = "C:\\Users\\mgapp\\source\\repos\\SupportTicketApp\\UnitTextSupportTicketLibrary\\TestData\\data.csv";
            Assert.Equal(File.Exists(staleDataAccess.FilePath), true);
        }

        [Fact]
        public void TestLoadDataQuery()
        {
            StaleDataAccess staleDataAccess = new StaleDataAccess();
            staleDataAccess.FilePath = "C:\\Users\\mgapp\\source\\repos\\SupportTicketApp\\UnitTextSupportTicketLibrary\\TestData\\data.csv";
            string query = "x => x.Id == 1";
            List<TicketModel> tickets = staleDataAccess.LoadData(query);
            Assert.NotNull(tickets);
            Assert.True(tickets.Count > 0);
        }

        [Fact]
        public void TestLoadData()
        {
            StaleDataAccess staleDataAccess = new StaleDataAccess();
            staleDataAccess.FilePath = "C:\\Users\\mgapp\\source\\repos\\SupportTicketApp\\UnitTextSupportTicketLibrary\\TestData\\data.csv";
            List<TicketModel> tickets = staleDataAccess.LoadData();
            Assert.NotNull(tickets);
            Assert.True(tickets.Count > 0);
        }

        [Fact]
        public void TestAddData()
        {
            StaleDataAccess staleDataAccess = new StaleDataAccess();
            staleDataAccess.FilePath = "C:\\Users\\mgapp\\source\\repos\\SupportTicketApp\\UnitTextSupportTicketLibrary\\TestData\\data.csv";
            staleDataAccess.SaveData(new TicketModel()
            {
                Id = 4,
                Title = "Test 1",
                Description = "Test 1",
                TicketStatus = TicketModel.Status.Active,
                TicketPriority = TicketModel.Priority.Low,
            }, StaleDataAccess.Mode.Add);
            TicketModel savedTicket = staleDataAccess.LoadData("x => x.Id == 4").FirstOrDefault();
            Assert.NotNull(savedTicket);
            Assert.True(savedTicket.Id == 4);
            
        }
        [Fact]
        public void TestDeleteData()
        {
            StaleDataAccess staleDataAccess = new StaleDataAccess();
            staleDataAccess.FilePath = "C:\\Users\\mgapp\\source\\repos\\SupportTicketApp\\UnitTextSupportTicketLibrary\\TestData\\data.csv";
            staleDataAccess.SaveData(new TicketModel()
            {
                Id = 4
            }, StaleDataAccess.Mode.Delete);
            TicketModel savedTicket = staleDataAccess.LoadData("x => x.Id == 4").FirstOrDefault();
            Assert.Null(savedTicket);
        }
    }
}
