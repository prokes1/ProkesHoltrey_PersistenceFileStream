using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProkesHoltrey_PersistenceFileStream.Models
{
    public class Menu
    {
        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();

            Console.WriteLine("Press any key to continue.");
            ConsoleKeyInfo response = Console.ReadKey();

            Console.WriteLine();

            Console.CursorVisible = true;
        }

        public void AddRecord(List<HighScore> highScoreClassList)
        {
            HighScore tempScore;
            string userEntry = "";
            string playerName = "";
            int score = 0;
            bool convert = false;
            Console.Clear();
            Console.WriteLine("Add Record");
            Console.WriteLine();

            while (!convert)
            {
                Console.Write("Player Name: ");
                userEntry = Console.ReadLine();
                if (highScoreClassList.Count > 0)
                {
                    foreach (HighScore player in highScoreClassList)
                    {
                        if (userEntry == player.PlayerName)
                        {
                            convert = false;
                            Console.WriteLine("Name already taken. Please choose another name.");
                            continue;
                        }
                        else
                        {
                            convert = true;
                            playerName = userEntry;
                        }
                    }
                }
                else
                {
                    playerName = userEntry;
                    convert = true;
                }
            }
            convert = false;

            while (!convert)
            {
                Console.WriteLine();
                Console.Write("Score: ");
                userEntry = Console.ReadLine();
                convert = Int32.TryParse(userEntry, out score);
                if (convert == false)
                {
                    Console.WriteLine("Score invalid. Please use an integer.");
                }
            }
            tempScore = new HighScore() { PlayerName = playerName, PlayerScore = score };
            highScoreClassList.Add(tempScore);

            DisplayContinuePrompt();
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

            DisplayContinuePrompt();
        }

        public void DisplayHighScores(List<HighScore> highScoreClassList)
        {
            Console.Clear();
            Console.WriteLine("Records");
            Console.WriteLine();
            if (highScoreClassList.Count == 0)
            {
                Console.WriteLine("No records found.");
            }
            foreach (HighScore player in highScoreClassList)
            {
                Console.WriteLine("Player: {0}\tScore: {1}", player.PlayerName, player.PlayerScore);
            }

            DisplayContinuePrompt();
        }

        public void UpdateRecord(List<HighScore> highScoreClassList)
        {
            string userEntry = "";
            string playerName = "";
            int score = 0;
            int previousScore = 0;
            bool recordExists;
            bool noRecords = true;
            bool loop = true;
            Console.Clear();
            Console.WriteLine("Update Current Record");
            Console.WriteLine();
            Console.WriteLine();
            

            if (highScoreClassList.Count == 0)
            {
                noRecords = true;
                if (noRecords)
                {
                    Console.WriteLine("There are no records available.");
                    Console.WriteLine("Would you like to add a record?(y/n)");
                    userEntry = Console.ReadLine().ToUpper();
                    while (loop)
                    {
                        if (userEntry == "Y" || userEntry == "YES")
                        {
                            AddRecord(highScoreClassList);
                            loop = false;
                        }
                        else if (userEntry == "N" || userEntry == "NO")
                        {
                            loop = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid reponse. Please answer 'y' or 'n'.");
                            loop = true;
                        }
                    }   
                }
                
            }
            else
            {
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
                    Console.WriteLine();
                    Console.WriteLine("Previous High Score: " + previousScore);
                    Console.WriteLine();
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
                DisplayContinuePrompt();
            }
            
        }

        public void ClearAllRecords(List<HighScore> highScoreClassList)
        {
            highScoreClassList.Clear();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("All records have been cleared.");

            DisplayContinuePrompt();
        }
    }
}
