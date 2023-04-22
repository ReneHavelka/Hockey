using Application.Common.Interfaces;
using Application.CQR.Queries;
using Domain.Entities;
using System.Text.Json;

namespace Application.CQR.Commands
{
    internal class NewGoalie
    {
        IReadPlayers _readPlayers;
        IAddNewPlayer _addNewPlayer;

        internal NewGoalie(IReadPlayers readPlayers, IAddNewPlayer addNewPlayer)
        {
            _readPlayers = readPlayers;
            _addNewPlayer = addNewPlayer;
        }

        internal void AddGoalie(Goalie goalie)
        {
            var getGoalies = new GetGoalies(_readPlayers);
            var allGoalies = getGoalies.GetAllGoalies();
            IList<Goalie> goalieList = new List<Goalie>();

            //Posledny goalie
            int id = 1;
            if (allGoalies != null)
            {
                id = allGoalies.Max(x => x.Id);
                goalieList = allGoalies.ToList();
                ++id;
            }

            //Priradenie id pre nového goalie-a
            goalie.Id = id;

            goalieList.Add(goalie);

            string updateGoalies = JsonSerializer.Serialize(goalieList);

            _addNewPlayer.AddPlayer("Goalie", updateGoalies);
        }
    }


}

