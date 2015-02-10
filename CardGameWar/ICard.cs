using System;

namespace CardGameWar
{
    interface ICard : IComparable<ICard>
    {
        Card.Suits Suit { get; set; }
        Card.Values Value { get; set; }

       
    }
}