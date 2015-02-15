using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameWar
{
    class Player
    {
        private List<ICard> _cardsWon = new List<ICard>();
        public IDeck Hand { get; set; }
        public ICard CurrentCard { get; set; }

        public List<ICard> cardsWon
        {
            get { return _cardsWon; }
            set { _cardsWon = value; }
        }

        public override string ToString()
        {
            return "Number of card on hand: " + Hand.Count;
        }
    } 
    
}
