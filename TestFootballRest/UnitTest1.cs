using Assign4rest;
using MandatoryAssignment;

namespace TestFootballRest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetAll()
        {
            FootballPlayersManager _manager = new FootballPlayersManager();
            List<FootballPlayer> footballPlayers = new List<FootballPlayer>();

            footballPlayers = _manager.GetAll();
            Assert.IsTrue(footballPlayers.Count == 4);
        }
        [TestMethod]
        public void TestGetById()
        {
            FootballPlayersManager _manager = new FootballPlayersManager();
            FootballPlayer footballPlayer = new FootballPlayer();
            FootballPlayer footballPlayer2 = new FootballPlayer();
            footballPlayer.ID = 1;
            footballPlayer2 = _manager.GetById(1);
            Assert.AreEqual(footballPlayer.ID, footballPlayer2.ID);
        }
    }
}