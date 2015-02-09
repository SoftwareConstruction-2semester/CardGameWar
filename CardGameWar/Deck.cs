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

        public override string ToString()
        {
            return String.Join(", \n", cards);
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }
    }
}
