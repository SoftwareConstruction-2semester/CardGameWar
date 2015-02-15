using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Security.Claims;
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

        private List<ICard> _warCards = new List<ICard>();

        static void Main(string[] args)
        {
            Program game = new Program();
            game.prepareGame();

            while (game._p1.Hand.Count > 0 && game._p2.Hand.Count > 0)
            {
                game.playRound();
                game.PrepareRound();
                System.Threading.Thread.Sleep(500);
            }
            Console.WriteLine(" - - - GAME OVER - - -");
            Console.WriteLine("player 1: " + game._p1);
            Console.WriteLine("player 2: " + game._p2);




        }

        private void PrepareRound()
        {
            foreach (var card in _p1.cardsWon)
            {
                _p1.Hand.Add(card);
            }
            _p1.cardsWon.Clear();

            foreach (var card in _p2.cardsWon)
            {
                _p2.Hand.Add(card);
            }
            _p2.cardsWon.Clear();

            _p1.Hand.Shuffle();
            _p2.Hand.Shuffle();
        }

        private void playRound()
        {
            // while both players have cards left
            while (_p1.Hand.Count > 0 && _p2.Hand.Count > 0)
            {
                _p1.CurrentCard = _p1.Hand.DealCard();
                _p2.CurrentCard = _p2.Hand.DealCard();
                Console.WriteLine("Plyer 1: " + _p1.CurrentCard);
                Console.WriteLine("Plyer 2: " + _p2.CurrentCard);
                if (_p1.CurrentCard.Value > _p2.CurrentCard.Value)
                {
                    Console.WriteLine("player 1 wins");
                    _p1.cardsWon.Add(_p1.CurrentCard);
                    _p1.cardsWon.Add(_p2.CurrentCard);
                }
                else if (_p1.CurrentCard.Value < _p2.CurrentCard.Value)
                {
                    Console.WriteLine("player 2 wins");
                    _p2.cardsWon.Add(_p1.CurrentCard);
                    _p2.cardsWon.Add(_p2.CurrentCard);
                }
                else
                {
                    War();
                }

            }

        }

        private void War()
        {
            if (_p1.Hand.Count < 4 || _p2.Hand.Count < 4)
            {
                PrepareRound();
            }

            if (_p1.Hand.Count < 4)
            {
                PlayerOneWinsWar();
            }

            if (_p2.Hand.Count < 4)
            {
                PlayerTwoWinsWar();
            }

            if (_p1.Hand.Count >= 4 && _p2.Hand.Count >= 4)
            {

                _warCards.Add(_p1.CurrentCard);
                _warCards.Add(_p2.CurrentCard);
                _warCards.AddRange(_p1.Hand.DealCards(3));
                _warCards.AddRange(_p2.Hand.DealCards(3));
                Console.WriteLine("War: (" + String.Join(", ", _warCards) + ")");
                _p1.CurrentCard = _p1.Hand.DealCard();
                _p2.CurrentCard = _p2.Hand.DealCard();
                Console.WriteLine("Plyer 1: " + _p1.CurrentCard);
                Console.WriteLine("Plyer 2: " + _p2.CurrentCard);
                if (_p1.CurrentCard.Value > _p2.CurrentCard.Value)
                {
                    PlayerOneWinsWar();
                }
                else if (_p1.CurrentCard.Value < _p2.CurrentCard.Value)
                {
                    PlayerTwoWinsWar();
                }
                else
                {
                    War();
                }
            }



        }

        private void PlayerOneWinsWar()
        {
            Console.WriteLine("player 1 wins war");
            _p1.cardsWon.Add(_p1.CurrentCard);
            _p1.cardsWon.Add(_p2.CurrentCard);
            _p1.cardsWon.AddRange(_warCards);
            _warCards.Clear();
        }

        private void PlayerTwoWinsWar()
        {
            Console.WriteLine("player 2 wins war");
            _p2.cardsWon.Add(_p1.CurrentCard);
            _p2.cardsWon.Add(_p2.CurrentCard);
            _p2.cardsWon.AddRange(_warCards);
            _warCards.Clear();
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
