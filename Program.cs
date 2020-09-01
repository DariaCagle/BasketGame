using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RandomClass
{
    public static int GetRandom()
    { 
        Random random = new Random();
        return random.Next(40, 140);
    }
}



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
            GameCreator game = new GameCreator(NumberOfPlayers);
            game.CreateList();


            int BasketWeight = RandomClass.GetRandom();
            Console.WriteLine($"The weight of the basket is {BasketWeight} kg");

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
