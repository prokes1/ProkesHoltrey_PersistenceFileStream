using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
            ReadHighScoresFromTextFile(file, highScoreClassListWrite);
            DisplayIntroMenu(highScoreClassListWrite);
            ObjectListReadWrite(file, highScoreClassListWrite);
        }

        static void ObjectListReadWrite(string dataFile, List<HighScore> highScoreClassListWrite)
        {
            List<HighScore> highScoresClassListWrite = new List<HighScore>();

            List<string> highScoresStringListRead = new List<string>(); ;
            List<HighScore> highScoresClassListRead = new List<HighScore>(); ;

            Console.WriteLine("The following high scores will be added to HighScore.txt.\n");
            // display list of high scores objects
            Console.WriteLine("Send to file: ");
            menu.DisplayHighScores(highScoreClassListWrite);
            // build the list of strings and write to the text file line by line
            WriteHighScoresToTextFile(highScoreClassListWrite, dataFile);
            Console.Clear();
            
            for (int i = 0; i <= 100; i+=5)
            {
                Console.Clear();
                Console.WriteLine("Loading... " + i + "% completed.");
                Thread.Sleep(30);
            }
            Console.WriteLine("High scores added successfully.\n");
            
                highScoresClassListRead = ReadHighScoresFromTextFile(dataFile, highScoresClassListWrite);

            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
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

        static List<HighScore> ReadHighScoresFromTextFile(string dataFile, List<HighScore> highScoresClassList)
        {
            const char delineator = ',';

            List<string> highScoresStringList = new List<string>();

            

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
                Console.WriteLine("6. Exit/Send to file");

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
                        usingMenu = false;
                        break;
                    default:
                        Console.WriteLine("It appears you have selected an incorrect choice.");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue or the ESC key to exit.");

                        userResponse = Console.ReadKey(true);
                        if (userResponse.Key == ConsoleKey.Escape)
                        {
                            Console.WriteLine("Exiting Application. Press any key to continue.");
                            Console.ReadKey();
                            Environment.Exit(1);
                        }
                        break;
                }
            }
        }
    }
}
