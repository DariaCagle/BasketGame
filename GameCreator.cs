using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketGame
{
    public class GameCreator
    {
        public static int[] AllNumbers = new int[BasketGame.Program.Range];
        public static int CountNamedNumbers = 0;

        public static List<Gamer> gamers = new List<Gamer>();

        public static void Add(Gamer s)
        {
            gamers.Add(s);
        }

        public static void Victory(Gamer player)
        {
            
             Console.WriteLine ($"{player.Name} won the game!");
        }


        public static void CreateList(int numberOfPlayers)
        {
            for(int i = 1; i <= numberOfPlayers; i++)
            {

                Console.WriteLine($"Player {i}");
                Console.Write("Enter a player's name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Choose a gamer type:");
                Console.WriteLine($"{(int)GAMER.JUSTGAMER}. Ordinary gamer");
                Console.WriteLine($"{(int)GAMER.NOTEGAMER}. Notebook gamer");
                Console.WriteLine($"{(int)GAMER.OVERGAMER}. Overgamer");
                Console.WriteLine($"{(int)GAMER.CHEATER}. Cheater");
                Console.WriteLine($"{(int)GAMER.OVERCHEATER}. Overcheater");
                GAMER choice = (GAMER)int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case GAMER.JUSTGAMER:
                        JustGamer jg = new JustGamer(); 
                        jg.CreateGamer(name, numberOfPlayers);
                        jg.AddGamer();
                        break;
                    case GAMER.NOTEGAMER:
                        NoteGamer ng = new NoteGamer();
                        ng.CreateGamer(name, numberOfPlayers);
                        ng.AddGamer();
                        break;
                    case GAMER.OVERGAMER:
                        OverGamer og = new OverGamer();
                        og.CreateGamer(name, numberOfPlayers);
                        og.AddGamer();
                        break;
                    case GAMER.CHEATER:
                        Cheater c = new Cheater();
                        c.CreateGamer(name, numberOfPlayers);
                        c.AddGamer();
                        break;
                    case GAMER.OVERCHEATER:
                        OverCheater oc = new OverCheater();
                        oc.CreateGamer(name, numberOfPlayers);
                        oc.AddGamer();
                        break;
                    default:
                        return;
                }
            }
        }

        public static void GameProcess(int numberOfPlayers, int basketWeight)
        {            
            for (int j = 0; j <100; j++)
            {
                int player = (j % numberOfPlayers);
                gamers[player].Move(basketWeight, gamers[player], out bool isWinner);
                if (isWinner)
                {
                    return;
                }
            }
            GameOver(basketWeight, numberOfPlayers);
            Console.WriteLine("Game over");
        }

        public static void GameOver(int basketWeight, int numberOfPlayers)
        {
            int min = BasketGame.Program.Range;
            int minIndex = 0;
            for(int i = 0; i < BasketGame.Program.Range; i++)
            {
                int diff = Math.Abs(AllNumbers[i] - basketWeight);
                if(diff < min)
                {
                    min = diff;
                    minIndex = i;
                }
            }
            int player = (minIndex % numberOfPlayers);
            Console.WriteLine($"{gamers[player].Name} was the closest.");
        }

    }
}
