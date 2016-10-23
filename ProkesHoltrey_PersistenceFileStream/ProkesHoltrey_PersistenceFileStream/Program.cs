using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProkesHoltrey_PersistenceFileStream.Models;
using ProkesHoltrey_PersistenceFileStream;

namespace ProkesHoltrey_PersistenceFileStream
{
    class Program
    {
        static Menu menu = new Menu();
        static void Main(string[] args)
        {
            List<HighScore> highScoreClassListWrite = new List<HighScore>();
            
            //string textFilePath = "Data\\Data.txt";
            string textFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

            string file = textFilePath + @"\Data\HighScore.txt";
            DisplayIntroMenu(highScoreClassListWrite);
            ObjectListReadWrite(file, highScoreClassListWrite);

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        static void ObjectListReadWrite(string dataFile, List<HighScore> highScoreClassListWrite)
        {
            List<HighScore> highScoresClassListWrite = new List<HighScore>();

            List<string> highScoresStringListRead = new List<string>(); ;
            List<HighScore> highScoresClassListRead = new List<HighScore>(); ;

            // initialize a list of HighScore objects
           

            Console.WriteLine("The following high scores will be added to HighScore.txt.\n");
            // display list of high scores objects
            menu.DisplayHighScores(highScoreClassListWrite);
            
            Console.WriteLine("\nAdd high scores to text file. Press any key to continue.\n");
            Console.ReadKey();

            // build the list of strings and write to the text file line by line
            WriteHighScoresToTextFile(highScoreClassListWrite, dataFile);

            Console.WriteLine("High scores added successfully.\n");

            Console.WriteLine("Read into a string of HighScore and display the high scores from data file. Press any key to continue.\n");
            Console.ReadKey();


            // build the list of HighScore class objects from the list of strings
            highScoresClassListRead = ReadHighScoresFromTextFile(dataFile);

            // display list of high scores objects
           menu.DisplayHighScores(highScoresClassListRead);
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
        static void DisplayIntroMenu(List<HighScore> highScoreClassList)
        {
            bool usingMenu = true;

            while (usingMenu)
            {
                Console.Clear();
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
                        menu.DisplayHighScores(highScoreClassList);
                        //usingMenu = false;
                        break;
                    case '2':
                        menu.AddRecord(highScoreClassList);
                        //usingMenu = false;
                        break;
                    case '3':
                        menu.DeleteRecord(highScoreClassList);
                        //usingMenu = false;
                        break;
                    case '4':
                        menu.UpdateRecord(highScoreClassList);
                        break;
                    case '5':
                        menu.ClearAllRecords(highScoreClassList);
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
