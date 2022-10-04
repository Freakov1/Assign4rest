using MandatoryAssignment;

namespace Assign4rest
{
    public class FootballPlayersManager
    {
        private static int _nextId = 1;

        public static List<FootballPlayer> Players = new List<FootballPlayer>
        {
            new FootballPlayer { ID = _nextId++, Name = "Simon", Age = 25, ShirtNumber = 66 },
            new FootballPlayer { ID = _nextId++, Name = "Bent", Age = 25, ShirtNumber = 56 },
            new FootballPlayer { ID = _nextId++, Name = "Torben", Age = 25, ShirtNumber = 44 },
            new FootballPlayer { ID = _nextId++, Name = "Arne", Age = 25, ShirtNumber = 12 }
        };

        public List<FootballPlayer> GetAll()
        {
            return Players;
        }
        public FootballPlayer GetById(int id)
        {
            foreach(FootballPlayer player in Players)
            {
                if(player.ID == id) return player;
            }
            return null;
        }
        public FootballPlayer AddPlayer(FootballPlayer player)
        {
            player.ID = _nextId++;
            Players.Add(player);
            return player;
        }
        public FootballPlayer UpdatePlayer(int id, FootballPlayer updates)
        {
            FootballPlayer player = Players.Find(F => F.ID == id);
            if (player == null) return null;
            player.Name = updates.Name;
            player.Age = updates.Age;
            player.ShirtNumber = updates.ShirtNumber;
            return player;
        }
        public FootballPlayer DeletePlayer(int id)
        {
            FootballPlayer player = Players.Find(p => p.ID == id);
            Players.Remove(player);
            return player;
        }
    }
}
