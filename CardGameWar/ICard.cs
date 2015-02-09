namespace CardGameWar
{
    interface ICard
    {
        Card.Suits Suit { get; set; }
        Card.Values Value { get; set; }

       
    }
}