using Application.Common.Interfaces;
using Application.Common.Validators;
using Application.CQR.Commands;
using Application.CQR.Queries;
using Domain.Common;
using Domain.Entities;

namespace Application
{
    public class HockeyManager
    {
        IReadPlayers _readPlayers;
        IAddNewPlayer _addNewPlayer;

        public HockeyManager(IReadPlayers readPlayers, IAddNewPlayer addNewPlayer)
        {
            _readPlayers = readPlayers;
            _addNewPlayer = addNewPlayer;
        }

        public void AddNewForward(string name, string surname, DateOnly dateOfBirth, int goals)
        {
            Forward forward = new Forward();
            forward.Name = name;
            forward.Surname = surname;
            forward.DateOfBirth = dateOfBirth;
            forward.Goals = goals;

            try
            {
                var palyerValidator = new PlayerValidator(forward);
                string validationResult = palyerValidator.PlayerValidate(forward);
            }
            catch
            {
                throw;
            }


            var newForward = new NewForward(_readPlayers, _addNewPlayer);
            newForward.AddForward(forward);
        }

        public void AddNewDefender(string name, string surname, DateOnly dateOfBirth, int hits)
        {
            Defender defender = new Defender();
            defender.Name = name;
            defender.Surname = surname;
            defender.DateOfBirth = dateOfBirth;
            defender.Hits = hits;

            try
            {
                var palyerValidator = new PlayerValidator(defender);
                string validationResult = palyerValidator.PlayerValidate(defender);
            }
            catch
            {
                throw;
            }


            var newDefender = new NewDefender(_readPlayers, _addNewPlayer);
            newDefender.AddDefender(defender);
        }

        public void AddNewGoalie(string name, string surname, DateOnly dateOfBirth, int wins)
        {
            Goalie goalie = new Goalie();
            goalie.Name = name;
            goalie.Surname = surname;
            goalie.DateOfBirth = dateOfBirth;
            goalie.Wins = wins;

            try
            {
                var palyerValidator = new PlayerValidator(goalie);
                string validationResult = palyerValidator.PlayerValidate(goalie);
            }
            catch
            {
                throw;
            }

            var newDefender = new NewGoalie(_readPlayers, _addNewPlayer);
            newDefender.AddGoalie(goalie);
        }

        public void PrintNameAndAgeOfTheYoungestPlayer()
        {
            var getForwards = new GetForwards(_readPlayers);
            var getDefenders = new GetDefenders(_readPlayers);
            var getGoalies = new GetGoalies(_readPlayers);

            Player player = null;
            DateOnly minDateOfBirth = new DateOnly(1, 1, 1);

            var youngestForward = getForwards.GetAllForwards().MinBy(x => x.DateOfBirth);
            if (youngestForward != null)
            {
                player = youngestForward;
                minDateOfBirth = youngestForward.DateOfBirth;
            }

            var youngestDefender = getDefenders.GetAllDefenders().MinBy(x => x.DateOfBirth);
            if (youngestDefender != null)
            {
                if (youngestDefender.DateOfBirth < minDateOfBirth)
                {
                    player = youngestDefender;
                    minDateOfBirth = youngestDefender.DateOfBirth;
                }
            }

            var youngestGoalie = getGoalies.GetAllGoalies().MinBy(x => x.DateOfBirth);
            {
                if (youngestGoalie.DateOfBirth < minDateOfBirth)
                {
                    player = youngestGoalie;
                    minDateOfBirth = youngestGoalie.DateOfBirth;
                }
            }

            var thisYear = DateOnly.FromDateTime(DateTime.Now).Year;
            var youngestPlayerYearOfBirth = player.DateOfBirth.Year;

            Console.WriteLine($"Our youngest player {player.Name} {player.Surname} is {thisYear - youngestPlayerYearOfBirth} old.");
        }
    }
}
