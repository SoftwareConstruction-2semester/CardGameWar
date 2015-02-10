using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameWar
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck d = new Deck();
            Console.WriteLine(d);

            Console.WriteLine("---------------------");
            d.Shuffle();
            Console.WriteLine(d.DealCard());
            Console.WriteLine(d.DealCard());
            Console.WriteLine(d.DealCard());
            Console.WriteLine(d.DealCard());
            Console.WriteLine(d.DealCard());
            Console.WriteLine(d.DealCard());

            Console.WriteLine("-----------");
            ICard[] cards = d.DealCards(6);
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(cards[i]);
            }

        }
    }
}
