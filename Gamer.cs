using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasketGame
{

    

    public abstract class Gamer
    {

        public Random rand = new Random();

        public string Name;
        public abstract int Move(int weight, Gamer Player, out bool isWinner);

        public void AddGamer()
        {
            GameCreator.gamers.Add(this);
        }

        public virtual void CreateGamer(string name, double number)
        {
            Name = name;
        }

    }

    public class JustGamer : Gamer
    {
        public override int Move(int weight, Gamer Player, out bool isWinner)
        {

            int tmp = rand.Next(40, 140);
            GameCreator.AllNumbers[GameCreator.CountNamedNumbers] = tmp;
            Console.WriteLine($"Player 1: {tmp}");
            GameCreator.CountNamedNumbers++;
            if (tmp == weight)
            {
                GameCreator.Victory(Player);
                isWinner = true;
            }
            else isWinner = false;
            return tmp;
        }
    }

    public class NoteGamer : Gamer
    {
        private int[] Array;
        private int CountArray = 0;

        public override int Move(int weight, Gamer Player, out bool isWinner)
        {
            int tmp;
            bool isUnique = true;
            do
            {
                tmp = rand.Next(40, 140);
                for (int i = 0; i < CountArray; i++)
                {
                    if (Array[i] == tmp)
                    {
                        isUnique = false;
                        break;
                    }
                    isUnique = true;
                }
            } while (!isUnique);            
            GameCreator.AllNumbers[GameCreator.CountNamedNumbers] = tmp;
            GameCreator.CountNamedNumbers++;
            Array[CountArray] = tmp;
            Console.WriteLine($"Player 2: {tmp}");
            CountArray++;
            if (tmp == weight)
            {
                GameCreator.Victory(Player);
                isWinner = true;
            }
            else isWinner = false;
            return tmp;
        }

        public override void CreateGamer(string name, double number)
        {
            Name = name;
            Array = new int[BasketGame.Program.Range];
        }
    }

    public class OverGamer : Gamer
    {
        private int Count = 40;
        public override int Move(int weight, Gamer Player, out bool isWinner)
        {

            int tmp = Count;
            Count++;
            GameCreator.AllNumbers[GameCreator.CountNamedNumbers] = tmp;
            GameCreator.CountNamedNumbers++;
            Console.WriteLine($"Player 3: {tmp}");
            if (tmp == weight)
            {
                GameCreator.Victory(Player);
                isWinner = true;
            }
            else isWinner = false;
            return tmp;
        }
    }

    public class Cheater : Gamer
    {
        public override int Move(int weight, Gamer Player, out bool isWinner)
        {
            int tmp;
            bool isUnique = true;
            do {
                tmp = rand.Next(40, 140);
                for (int i = 0; i < GameCreator.CountNamedNumbers; i++)
                {
                    if (GameCreator.AllNumbers[i] == tmp)
                    {
                        isUnique = false;
                        break;
                    }
                    isUnique = true;
                }
            } while (!isUnique);
            GameCreator.AllNumbers[GameCreator.CountNamedNumbers] = tmp;
            GameCreator.CountNamedNumbers++;
            Console.WriteLine($"Player 4: {tmp}");
            if (tmp == weight)
            {
                GameCreator.Victory(Player);
                isWinner = true;
            }
            else isWinner = false;
            return tmp;
        }
    }

    public class OverCheater : Gamer
    {
        private int Count = 40;
        public override int Move(int weight, Gamer Player, out bool isWinner)
        {
            int tmp;
            bool isUnique = true;
            do
            {
                tmp = Count;
                Count++;
                for (int i = 0; i < GameCreator.CountNamedNumbers; i++)
                {
                    if (GameCreator.AllNumbers[i] == tmp)
                    {
                        isUnique = false;
                        break;
                    }
                    isUnique = true;
                }
            } while (!isUnique);
            GameCreator.AllNumbers[GameCreator.CountNamedNumbers] = tmp;
            GameCreator.CountNamedNumbers++;
            Console.WriteLine($"Player 5: {tmp}");
            if (tmp == weight)
            {
                GameCreator.Victory(Player);
                isWinner = true;
            }
            else isWinner = false;
            return tmp;
        }
    }
}
