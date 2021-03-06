﻿using System;
using System.Collections.Generic;
using System.Deployment.Internal.Isolation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameWar
{
    class Card : ICard
    {
        private Suits _suit;
        private Values _value;

      

        public enum Suits
        {
            Spade,
            Heart,
            Diamond,
            Club
        };

        public enum Values
        {
            Ace = 1,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        }

        public Card.Suits Suit
        {
            get { return _suit; }
            set { _suit = value; }
        }

        public Card.Values Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public int CompareTo(ICard other)
        {
            return Value.CompareTo(other.Value);
        }

        public override String ToString()
        {
            return Value.ToString() + " " + Suit.ToString();
        }
    }
}

