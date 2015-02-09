using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameWar
{
    class Deck
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
    }
}
