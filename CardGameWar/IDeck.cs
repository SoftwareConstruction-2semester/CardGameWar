using System;
using System.Collections;
using System.Collections.Generic;

namespace CardGameWar
{
    interface IDeck : ICollection<ICard>
    {
        IDeck[] split(int numberOfDecks);
        
        ICard DealCard();

        ICard[] DealCards(int numnerOfCards);

        void Shuffle();
    }
}