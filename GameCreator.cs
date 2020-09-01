using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketGame
{
    public class GameCreator
    {
        public List<Gamer> gamers = new List<Gamer>();

        private int numberOfPlayers;

        public GameCreator(int number)
        {
            numberOfPlayers = number;
        }

        public void CreateList()
        {
            for(int i = 0; i < numberOfPlayers; i++)
            {
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
                        JustGamer g = new JustGamer(); 
                        g.CreateGamer(name, numberOfPlayers);
                        break;
                }
            }
        }



    }
}
