using Application.Common.Interfaces;
using System.Text;

namespace Infrastructure
{
    public class AddNewPlayer : IAddNewPlayer
    {
        public void AddPlayer(string role, string playersString)
        {
            var fileAccess = new FileAccess(role);
            string playersFileName = fileAccess.GetFileName();

            //Zapis.
            File.WriteAllText(playersFileName, playersString, Encoding.UTF8);
        }
    }
}