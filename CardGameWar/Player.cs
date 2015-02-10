using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameWar
{
    class Player
    {
        public IDeck Hand { get; set; }
        public ICard CurrentCard { get; set; }
        public List<ICard> cardsWon { get; set; }
    } 
    
}
