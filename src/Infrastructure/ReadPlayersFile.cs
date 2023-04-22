using Application.Common.Interfaces;
using System.Text;

namespace Infrastructure
{
    public class ReadPlayersFile : IReadPlayers
    {
        public string GetPlayers(string role)
        {
            var fileAccess = new FileAccess(role);
            string playersFileName = fileAccess.GetFileName();

            var players = File.ReadAllText(playersFileName, Encoding.UTF8);

            return players;
        }
    }
}
