using GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Program
    {
        public static List<Game> games = new List<Game>();

        static void Main(string[] args)
        {
            StartApp();
        }

        private static void StartApp()
        {
            DisplayMenu();
            int choice = int.Parse(Console.ReadLine());
            bool menuFlag = false;

            while (!menuFlag)
            {                
                if (choice == 1)
                { 
                    Console.Clear();
                    AddGame();
                    menuFlag = true;
                }
                else if (choice == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Game List: ");
                    Console.WriteLine(" ");
                    CheckList();
                    menuFlag = true;
                }
                else if (choice == 3)
                {
                    Console.Clear();
                    Console.WriteLine("You can add more games later.");
                    Console.WriteLine(" ");
                    menuFlag = true;
                }                                        
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("MENU");
            Console.WriteLine(" ");
            Console.WriteLine("1. Add Game");
            Console.WriteLine("2. Check Game List");
            Console.WriteLine("3. Exit");
        }

        private static void AddGame()
        {
            //Console.Clear();
            addGameLabel:
            Console.WriteLine("Adding game...");
            Console.WriteLine(" ");
            bool gameFlag = false;

            while (!gameFlag)
            {               
                var currentGame = new Game();

                games.Add(currentGame);
                Console.Write("Add game name: ");
                currentGame.GameName = Console.ReadLine();

                Console.Write("Add game platform: ");
                currentGame.Platform = Console.ReadLine();

                Console.Write("Add year of release: ");
               currentGame.Year = Console.ReadLine();

                Console.Write("Add short game summary: ");
                currentGame.GameSummary = Console.ReadLine();

                bool priceFlag = false;
                int number = 0;

                while (!priceFlag)
                {
                    Console.Write("Add game price: ");
                    if (int.TryParse(Console.ReadLine(), out number))
                    {
                        currentGame.Price = number;
                        priceFlag = true;
                        gameFlag = true;
                        Console.Clear();
                        Console.WriteLine("Game added!");
                        Console.WriteLine();                                               
                    }
                    else
                    {
                        Console.WriteLine("{0} was not a valid input for game price, please try again.",number);
                    }
                }                
            }

            Console.WriteLine("Enter \"B\" to go back and add new game or \"M\" to return to menu");
            string goBack;
            goBack = Console.ReadLine();

            bool backFlag = false;

            while (!backFlag)
            {
                if (goBack.ToLower() == "b")
                {                    
                    backFlag = true;
                    Console.Clear();
                    //goto addGameLabel;
                    AddGame();
                }
                else if (goBack.ToLower() == "m")
                {                    
                    backFlag = true;
                    Console.Clear();
                    StartApp();
                }
            }
        }

        private static bool CheckForAddedGames()
        {
            if (!games.Any())
            {
                Console.WriteLine("Currently there are no games in the list!");
                Console.WriteLine();
                Console.WriteLine("Press enter to go back");
                Console.ReadLine();
                Console.Clear();
                StartApp();
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void CheckList()
        {           
            if (!CheckForAddedGames())
            {
                return;
            }
            
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Game Name                     | Platform   | Year   |  Price");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine();

            foreach (Game game in games)
            {
                Console.WriteLine(string.Format("{0,-29} | {1,-10} | {2,-6} | {3,5}", game.GameName, game.Platform, game.Year, game.Price));
            }            

            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine();

            bool backFlag = false;

            while (!backFlag)
            {
                Console.WriteLine("Enter \"B\" to go back to the menu.");
                Console.WriteLine("To sort the list by price press \"P\", or \"Y\" to sort by release year.");
                string choice = Console.ReadLine();

                if (choice.ToLower() == "b")
                {
                    Console.Clear();
                    backFlag = true;
                    StartApp();
                }
                else if (choice.ToLower() == "p")
                {
                    Console.Clear();
                    Console.WriteLine("Game List: ");
                    Console.WriteLine();
                    IEnumerable<Game> orderedGames =
                        from game in games
                        orderby game.Price descending
                        select game;


                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine("Game Name                     | Platform   | Year   |  Price");
                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine();

                    foreach (Game game in orderedGames)
                    {
                        Console.WriteLine(string.Format("{0,-29} | {1,-10} | {2,-6} | {3,5}", game.GameName, game.Platform, game.Year, game.Price));
                    }

                    Console.WriteLine();
                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine();
                }

                else if (choice.ToLower() == "y")
                {
                    Console.Clear();
                    Console.WriteLine("Game List: ");
                    Console.WriteLine();
                    IEnumerable<Game> orderedGames =
                        from game in games
                        orderby game.Year descending
                        select game;


                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine("Game Name                     | Platform   | Year   |  Price");
                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine();

                    foreach (Game game in orderedGames)
                    {
                        Console.WriteLine(string.Format("{0,-29} | {1,-10} | {2,-6} | {3,5}", game.GameName, game.Platform, game.Year, game.Price));
                    }

                    Console.WriteLine();
                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("{0} is wrong input for return to menu", choice);
                }
            }                        
        }
    }
}
