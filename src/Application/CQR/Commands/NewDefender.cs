using Application.Common.Interfaces;
using Application.CQR.Queries;
using Domain.Entities;
using System.Text.Json;

namespace Application.CQR.Commands
{
    internal class NewDefender
    {
        IReadPlayers _readPlayers;
        IAddNewPlayer _addNewPlayer;

        public NewDefender(IReadPlayers readPlayers, IAddNewPlayer addNewPlayer)
        {
            _readPlayers = readPlayers;
            _addNewPlayer = addNewPlayer;
        }

        internal void AddDefender(Defender defender)
        {
            var getDefenders = new GetDefenders(_readPlayers);
            var allDefenders = getDefenders.GetAllDefenders();
            IList<Defender> defenderList = new List<Defender>();

            //Posledny Defender
            int id = 1;
            if (allDefenders != null)
            {
                id = allDefenders.Max(x => x.Id);
                defenderList = allDefenders.ToList();
                ++id;
            }

            //Priradenie id pre nového Defender-a
            defender.Id = id;

            defenderList.Add(defender);

            string updateDefenders = JsonSerializer.Serialize(defenderList);

            _addNewPlayer.AddPlayer("Defender", updateDefenders);
        }
    }
}
