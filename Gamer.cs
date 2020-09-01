using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketGame
{
    public abstract class Gamer
    {


        public string Name;

        public int[] Array;
        public int CountArray = 0;
        public virtual int Move()
        {
            return RandomClass.GetRandom();
        }
        public virtual void AddMyNumbers()
        {

        }

        public virtual void CreateGamer(string name, double number)
        {
            Name = name;
            Array = new int [(int)Math.Ceiling(BasketGame.Program.Range / number)];
        }

        public void Victory()
        {
            Console.WriteLine($"{Name} has won!");
        }
    }

    public class JustGamer : Gamer
    {

    }
}
