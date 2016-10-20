using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProkesHoltrey_PersistenceFileStream.Models
{
    public class Menu
    {
        public void AddRecord(List<HighScore> highScoreClassList)
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
            highScoreClassList.Add(tempScore);
        }

        public void DeleteRecord(List<HighScore> highScoreClassList)
        {
            string userEntry = "";
            string playerName = "";
            Console.Clear();
            Console.WriteLine("Delete Record");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Player Name: ");
            userEntry = Console.ReadLine();
            playerName = userEntry;
            highScoreClassList.RemoveAll(item => item.PlayerName == playerName);
        }

        public void DisplayHighScores(List<HighScore> highScoreClassList)
        {
            Console.Clear();
            Console.WriteLine("Records");
            

            foreach (HighScore player in highScoreClassList)
            {
                Console.WriteLine("Player: {0}\tScore: {1}", player.PlayerName, player.PlayerScore);
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

        }

        public void UpdateRecord(List<HighScore> highScoreClassList)
        {
            string userEntry = "";
            string playerName = "";
            int score = 0;
            int previousScore = 0;
            Console.Clear();
            Console.WriteLine("Update Current Record");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Player Name: ");
            userEntry = Console.ReadLine();
            playerName = userEntry;
            foreach (HighScore player in highScoreClassList)
            {
                if (player.PlayerName == playerName)
                {
                    previousScore = player.PlayerScore;
                }
            }
            bool convert = false;
            while (!convert)
            {
                Console.WriteLine("Preivous High Score: " + previousScore);
                Console.Write("New High Score: ");
                userEntry = Console.ReadLine();
                convert = Int32.TryParse(userEntry, out score);
                foreach (HighScore player in highScoreClassList)
                {
                    if (player.PlayerName == playerName)
                    {
                        player.PlayerScore = score;
                    }
                }
            }
        }

        public void ClearAllRecords()
        {

        }
    }
}
