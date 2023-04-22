using Application.Common.Interfaces;
using Application.CQR.Queries;
using Domain.Entities;
using System.Text.Json;

namespace Application.CQR.Commands
{
    internal class NewForward
    {
        IReadPlayers _readPlayers;
        IAddNewPlayer _addNewPlayer;

        internal NewForward(IReadPlayers readPlayers, IAddNewPlayer addNewPlayer)
        {
            _readPlayers = readPlayers;
            _addNewPlayer = addNewPlayer;
        }

        internal void AddForward(Forward forward)
        {
            var getForwards = new GetForwards(_readPlayers);
            var allForwards = getForwards.GetAllForwards();
            IList<Forward> forwardList = new List<Forward>();

            //Posledny forward
            int id = 1;
            if (allForwards != null)
            {
                id = allForwards.Max(x => x.Id);
                forwardList = allForwards.ToList();
                ++id;
            }

            //Priradenie id pre nového forward-a
            forward.Id = id;

            forwardList.Add(forward);

            string updateForwards = JsonSerializer.Serialize(forwardList);

            _addNewPlayer.AddPlayer("Forward", updateForwards);
        }
    }


}
