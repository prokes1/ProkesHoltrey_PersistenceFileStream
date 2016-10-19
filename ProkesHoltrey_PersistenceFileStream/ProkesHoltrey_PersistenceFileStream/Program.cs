using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProkesHoltrey_PersistenceFileStream.Models;

namespace ProkesHoltrey_PersistenceFileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            //string textFilePath = "Data\\Data.txt";
            string textFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string file = textFilePath + @"\Data\HighScores.txt";

            ObjectListReadWrite(file);

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        static void ObjectListReadWrite(string dataFile)
        {
            List<HighScore> highScoresClassListWrite = new List<HighScore>();

            List<string> highScoresStringListRead = new List<string>(); ;
            List<HighScore> highScoresClassListRead = new List<HighScore>(); ;

            // initialize a list of HighScore objects
            highScoresClassListWrite = InitializeListOfHighScores();

            Console.WriteLine("The following high scores will be added to Data.txt.\n");
            // display list of high scores objects
            DisplayHighScores(highScoresClassListWrite);

            Console.WriteLine("\nAdd high scores to text file. Press any key to continue.\n");
            Console.ReadKey();

            // build the list of strings and write to the text file line by line
            WriteHighScoresToTextFile(highScoresClassListWrite, dataFile);

            Console.WriteLine("High scores added successfully.\n");

            Console.WriteLine("Read into a string of HighScore and display the high scores from data file. Press any key to continue.\n");
            Console.ReadKey();


            // build the list of HighScore class objects from the list of strings
            highScoresClassListRead = ReadHighScoresFromTextFile(dataFile);

            // display list of high scores objects
            DisplayHighScores(highScoresClassListRead);
        }

        static List<HighScore> InitializeListOfHighScores()
        {
            List<HighScore> highScoresClassList = new List<HighScore>();

            // initialize the IList of high scores - note: no instantiation for an interface
            highScoresClassList.Add(new HighScore() { PlayerName = "John", PlayerScore = 1296 });
            highScoresClassList.Add(new HighScore() { PlayerName = "Joan", PlayerScore = 345 });
            highScoresClassList.Add(new HighScore() { PlayerName = "Jeff", PlayerScore = 867 });
            highScoresClassList.Add(new HighScore() { PlayerName = "Joe", PlayerScore = 2309 });
            highScoresClassList.Add(new HighScore() { PlayerName = "Jazz", PlayerScore = 239 });
            highScoresClassList.Add(new HighScore() { PlayerName = "Reggie", PlayerScore = 2130 });
            highScoresClassList.Add(new HighScore() { PlayerName = "Red", PlayerScore = 1209 });
            highScoresClassList.Add(new HighScore() { PlayerName = "Charles", PlayerScore = 309 });
            highScoresClassList.Add(new HighScore() { PlayerName = "Val", PlayerScore = 3289 });
            highScoresClassList.Add(new HighScore() { PlayerName = "Billy", PlayerScore = 909 });

            return highScoresClassList;
        }

        static void DisplayHighScores(List<HighScore> highScoreClassList)
        {
            foreach (HighScore player in highScoreClassList)
            {
                Console.WriteLine("Player: {0}\tScore: {1}", player.PlayerName, player.PlayerScore);
            }
        }

        static void WriteHighScoresToTextFile(List<HighScore> highScoreClassLIst, string dataFile)
        {
            string highScoreString;

            List<string> highScoresStringListWrite = new List<string>();

            // build the list to write to the text file line by line
            foreach (var player in highScoreClassLIst)
            {
                highScoreString = player.PlayerName + "," + player.PlayerScore;
                highScoresStringListWrite.Add(highScoreString);
            }

            File.WriteAllLines(dataFile, highScoresStringListWrite);
        }

        static List<HighScore> ReadHighScoresFromTextFile(string dataFile)
        {
            const char delineator = ',';

            List<string> highScoresStringList = new List<string>();

            List<HighScore> highScoresClassList = new List<HighScore>();

            // read each line and put it into an array and convert the array to a list
            highScoresStringList = File.ReadAllLines(dataFile).ToList();

            foreach (string highScoreString in highScoresStringList)
            {
                // use the Split method and the delineator on the array to separate each property into an array of properties
                string[] properties = highScoreString.Split(delineator);

                highScoresClassList.Add(new HighScore() { PlayerName = properties[0], PlayerScore = Convert.ToInt32(properties[1]) });
            }

            return highScoresClassList;
        }
        static void DisplayIntroMenu()
        {
            bool usingMenu = true;

            while (usingMenu)
            {
                Console.WriteLine("Menu");
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("1. Display All Records");
                Console.WriteLine();
                Console.WriteLine("2. Add a Record");
                Console.WriteLine();
                Console.WriteLine("3. Delete a Record");
                Console.WriteLine();
                Console.WriteLine("4. Update a Record");
                Console.WriteLine();
                Console.WriteLine("5. Clear all Records");
                Console.WriteLine();
                Console.WriteLine("6. Exit");

                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case '1':
                        DisplayAllRecords();
                        usingMenu = false;
                        break;
                    case '2':
                        AddRecord();
                        break;
                    case '3':
                        usingMenu = false;
                        DeleteRecord();
                        break;
                    case '4':
                        UpdateRecord();
                        break;
                    case '5':
                        ClearAllRecords();
                        break;
                    case '6':
                        Exit();
                        break;
                    default:
                        Console.WriteLine("It appears you have selected an incorrect choice.");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue or the ESC key to exit.");

                        userResponse = Console.ReadKey(true);
                        if (userResponse.Key == ConsoleKey.Escape)
                        {
                            usingMenu = false;
                        }
                        break;
                }
            }
        }

        static HighScore AddRecord()
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
            while (convert)
            {
                Console.Write("Score: ");
                userEntry = Console.ReadLine();
                convert = Int32.TryParse(userEntry, out score);
            }
            tempScore = new HighScore() { PlayerName = playerName, PlayerScore = score };
            return tempScore;
        }

        static void DeleteRecord()
        {
            HighScore tempHighScore;
        }

        static void DisplayAllRecords()
        {
            
        }

        static void UpdateRecord()
        {

        }

        static void ClearAllRecords()
        {

        }

        static void Exit()
        {
            Console.Clear();
            Console.WriteLine("Dude, why you leaving?");
            Console.WriteLine("I guess you can press any key to leave.");
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}
