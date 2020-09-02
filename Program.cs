using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum GAMER
{
    JUSTGAMER = 1,
    NOTEGAMER,
    OVERGAMER,
    CHEATER,
    OVERCHEATER
}


namespace BasketGame
{

    class Program
    {

        public const int Range = 100;
        static void Main(string[] args)
        {
            Console.Write("Enter number of players (2 - 8): ");
            int NumberOfPlayers = NumberCheck();
            Console.WriteLine(NumberOfPlayers);
            GameCreator.CreateList(NumberOfPlayers);
            Random random = new Random();
            int BasketWeight = random.Next(40, 140);
            Console.WriteLine($"The weight of the basket is {BasketWeight} kg");
            GameCreator.GameProcess(NumberOfPlayers, basketWeight: BasketWeight);
        }

        public static int NumberCheck()
        {
            int NumberOfPlayers;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out NumberOfPlayers) || NumberOfPlayers < 2 || NumberOfPlayers > 8)
                {
                    Console.Write("Wrong input! Try again: ");
                }
                else return NumberOfPlayers;
            }
        }
    }
}
