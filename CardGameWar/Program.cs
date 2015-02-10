using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardGameWar
{
    class Program
    {
        public Player _p1 = new Player();
        public Player _p2 = new Player();

        private IDeck _deck = new Deck();

        static void Main(string[] args)
        {
            Program game = new Program();
            game.prepareGame();
            game.startGame();

        }

        private void startGame()
        {
            // while both players have cards left
            while (_p1.Hand.Count > 0 && _p2.Hand.Count > 0)
            {
                _p1.CurrentCard = _p1.Hand.DealCard();
                _p2.CurrentCard = _p2.Hand.DealCard();
                Console.WriteLine("Plyer 1: "+_p1.CurrentCard);
                Console.WriteLine("Plyer 2: " + _p2.CurrentCard);
                if (_p1.CurrentCard.Value > _p2.CurrentCard.Value) Console.WriteLine("player 1 wins");
                else if (_p1.CurrentCard.Value < _p2.CurrentCard.Value) Console.WriteLine("player 2 wins");
                else Console.WriteLine("War");
                
            }

        }

        private void prepareGame()
        {
            _deck.Shuffle();
            IDeck[] splitdeck = _deck.split(2);
            _p1.Hand = splitdeck[0];
            _p2.Hand = splitdeck[1];
            

        }
    }
}
