using Application.Common.Interfaces;
using Domain.Entities;
using System.Text.Json;

namespace Application.CQR.Queries
{
    internal class GetGoalies
    {

        IReadPlayers _readPlayers;
        internal GetGoalies(IReadPlayers readPlayers)
        {
            _readPlayers = readPlayers;
        }

        internal IEnumerable<Goalie> GetAllGoalies()
        {
            IEnumerable<Goalie> allGoalies = null;
            var allGoalieStr = _readPlayers.GetPlayers("Goalie");

            if (allGoalieStr != String.Empty) { allGoalies = JsonSerializer.Deserialize<Goalie[]>(allGoalieStr); }

            return allGoalies;
        }
    }
}
