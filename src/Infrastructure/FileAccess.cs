namespace Infrastructure
{
    internal class FileAccess
    {
        string _role;
        public FileAccess(string role)
        {
            _role = role;
        }

        internal string GetFileName()
        {
            string playersFileName = String.Empty;
            //Najdi subor so zoznamom hracov prislusnej kategorie ulohy hraca.

            switch (_role)
            {
                case "Forward":
                    playersFileName = GetForwardFileName();
                    break;
                case "Defender":
                    playersFileName = GetDefenderFileName();
                    break;
                case "Goalie":
                    playersFileName = GetGoalieFileName();
                    break;
            }

            return playersFileName;
        }
        internal string GetForwardFileName()
        {
            var playersFileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Players", "forwards.json");


            //Preverenie existencie priecinka a suboru a pripadne vzytvorenie novych.
            var directory = Path.GetDirectoryName(playersFileName);
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
            if (!Path.Exists(playersFileName)) File.Create(playersFileName).Dispose();


            return playersFileName;
        }

        internal string GetDefenderFileName()
        {
            var playersFileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Players", "defenders.json");

            //Preverenie existencie priecinka a suboru a pripadne vzytvorenie novych.
            var directory = Path.GetDirectoryName(playersFileName);
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
            if (!Path.Exists(playersFileName)) File.Create(playersFileName).Dispose();

            if (!Path.Exists(playersFileName)) File.Create(playersFileName).Dispose();

            return playersFileName;
        }

        internal string GetGoalieFileName()
        {
            var playersFileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Players", "goalies.json");

            //Preverenie existencie priecinka a suboru a pripadne vzytvorenie novych.
            var directory = Path.GetDirectoryName(playersFileName);
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
            if (!Path.Exists(playersFileName)) File.Create(playersFileName).Dispose();

            return playersFileName;
        }
    }
}
