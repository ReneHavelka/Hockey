using Application.Common.Interfaces;
using Domain.Entities;
using System.Text.Json;

namespace Application.CQR.Queries
{
    internal class GetDefenders
    {
        IReadPlayers _readPlayers;

        internal GetDefenders(IReadPlayers readPlayers)
        {
            _readPlayers = readPlayers;
        }

        internal IEnumerable<Defender> GetAllDefenders()
        {
            IEnumerable<Defender> allDefenders = null;
            var allDefenderStr = _readPlayers.GetPlayers("Defender");

            if (allDefenderStr != String.Empty) { allDefenders = JsonSerializer.Deserialize<Defender[]>(allDefenderStr); }

            return allDefenders;
        }
    }
}
