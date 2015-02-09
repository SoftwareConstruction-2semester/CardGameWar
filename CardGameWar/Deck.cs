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

        public IEnumerator<IDeck> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return String.Join(", \n", cards);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IDeck item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(IDeck item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(IDeck[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IDeck item)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }
    }
}
