using Application.Common.Interfaces;
using Domain.Entities;
using System.Text.Json;

namespace Application.CQR.Queries
{
    internal class GetForwards
    {
        IReadPlayers _readPlayers;
        internal GetForwards(IReadPlayers readPlayers)
        {
            _readPlayers = readPlayers;
        }

        internal IEnumerable<Forward> GetAllForwards()
        {
            IEnumerable<Forward> allForwards = null;
            var allForwardStr = _readPlayers.GetPlayers("Goalie");

            if (allForwardStr != String.Empty) { allForwards = JsonSerializer.Deserialize<Forward[]>(allForwardStr); }

            return allForwards;
        }
    }
}
