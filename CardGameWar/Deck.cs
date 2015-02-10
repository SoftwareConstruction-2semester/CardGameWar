using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameWar
{
    class Deck : IDeck
    {
        private List<ICard> cards = new List<ICard>(); 
        public Deck()
        {
            for (int i = 1; i <= 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ICard card = new Card();
                    card.Value = (Card.Values)i;
                    card.Suit = (Card.Suits) j;
                    cards.Add(card);
                }
            }
        }

        public IEnumerator<ICard> GetEnumerator()
        {
            return cards.GetEnumerator();
        }

        public override string ToString()
        {
            return String.Join(", \n", cards);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public void Add(ICard item)
        {
            cards.Add(item);
        }

        public void Clear()
        {
            cards.Clear();
        }

        public bool Contains(ICard item)
        {
            return cards.Contains(item);
        }

        public void CopyTo(ICard[] array, int arrayIndex)
        {
            cards.CopyTo(array, arrayIndex);
        }

        public bool Remove(ICard item)
        {
            return cards.Remove(item);
        }

        public int Count
        {
            get { return cards.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public IDeck[] split(int numberOfDecks)
        {
            IDeck[] decks = new IDeck[numberOfDecks];
            for (int i = 0; i < numberOfDecks; i++)
            {
                    decks[i] = new Deck();
            }

            while (cards.Count >numberOfDecks)
            {
                foreach (var deck in decks)
                {
                    deck.Add(DealCard());
                }
            }
            foreach (var deck in decks)
            {
                if (cards.Count > 0)
                {
                    deck.Add(DealCard());
                }
            }
            return decks;


            //IDeck[] decks = new IDeck[numberOfDecks];
            //for (int i = 0; i < (cards.Count/numberOfDecks); i++)
            //{
            //    for (int j = 0; j < numberOfDecks; j++)
            //    {
            //        decks[j].Add(DealCard());
            //    }   
            //}
            //// the remaining cards
            //for (int i = 0; i < cards.Count; i++)
            //{
            //    decks[i].Add(DealCard());
            //}

            // return decks;
        }

        public ICard DealCard()
        {
            ICard c = cards[0];
            cards.Remove(c);
            return c;
        }

        public ICard[] DealCards(int numnerOfCards)
        {
            ICard[] cards = new ICard[numnerOfCards];
            for (int i = 0; i < numnerOfCards; i++)
            {
                cards[i] = DealCard();
            }
            return cards;
        }

        public void Shuffle()
        {
            var rnd = new Random();
            var result = cards.OrderBy(item => rnd.Next());
            cards= new List<ICard>(result);
        }
    }
}
