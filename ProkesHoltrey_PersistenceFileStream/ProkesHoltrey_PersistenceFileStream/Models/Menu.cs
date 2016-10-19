using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProkesHoltrey_PersistenceFileStream.Models
{
    public class Menu
    {
        public HighScore AddRecord()
        {
            HighScore tempScore;
            string userEntry = "";
            string playerName = "";
            int score = 0;
            Console.Clear();
            Console.WriteLine("Add Record");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Player Name: ");
            userEntry = Console.ReadLine();
            playerName = userEntry;
            bool convert = false;
            while (!convert)
            {
                Console.Write("Score: ");
                userEntry = Console.ReadLine();
                convert = Int32.TryParse(userEntry, out score);
            }
            tempScore = new HighScore() { PlayerName = playerName, PlayerScore = score };
            return tempScore;
        }

        public void DeleteRecord()
        {
            HighScore tempHighScore;
        }

        public void DisplayAllRecords()
        {

        }

        public void UpdateRecord()
        {

        }

        public void ClearAllRecords()
        {

        }
    }
}
