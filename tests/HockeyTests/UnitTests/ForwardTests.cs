using Application;
using Application.Common.Interfaces;
using Infrastructure;

namespace HockeyTests.UnitTests
{
    [TestClass]
    public class ForwardTests
    {
        IReadPlayers readPlayers;
        IAddNewPlayer addNewPlayer;


        public ForwardTests()
        {
            readPlayers = new ReadPlayersFile();
            addNewPlayer = new AddNewPlayer();
        }

        [TestMethod]
        public void ForwardNameSurnameShouldNotBeNull()
        {
            string name = "";
            string surname = "";
            DateOnly dateOfBirth = DateOnly.FromDateTime(DateTime.Now.AddYears(-3));

            string exMessage = String.Empty;
            var hockeyManager = new HockeyManager(readPlayers, addNewPlayer);
            try
            {
                hockeyManager.AddNewForward(name, surname, dateOfBirth, 0);
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
            }

            string expected1 = "No name";
            string expected2 = "No surname";
            string expexted3 = "Date too late";

            Assert.IsTrue(exMessage.Contains(expected1) && exMessage.Contains(expected2) && exMessage.Contains(expexted3));
        }

        [TestMethod]
        public void AddTemporaryAndPrintYoungestGuy()
        {
            var hockeyManager = new HockeyManager(readPlayers, addNewPlayer);

            string name = "John";
            string surname = "Lazy";
            DateOnly dateOfBirth = DateOnly.FromDateTime(DateTime.Now.AddYears(-21));

            hockeyManager.AddNewForward(name, surname, dateOfBirth, 50);

            name = "Peter";
            surname = "Swift";
            dateOfBirth = DateOnly.FromDateTime(DateTime.Now.AddYears(-18));
            hockeyManager.AddNewDefender(name, surname, dateOfBirth, 70);

            name = "Steve";
            surname = "Nevermind";
            dateOfBirth = DateOnly.FromDateTime(DateTime.Now.AddYears(-23));
            hockeyManager.AddNewGoalie(name, surname, dateOfBirth, 20);

            hockeyManager.PrintNameAndAgeOfTheYoungestPlayer();
        }
    }
}
