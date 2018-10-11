using CodingChallenge.Models.Interfaces;
using System.Collections.Generic;

namespace CodingChallenge.Models
{
    public sealed class Wallet
    {
        public List<ICreditCard> CreditCards { get; set; } = new List<ICreditCard>();

        public Wallet AddCard(ICreditCard card)
        {
            CreditCards.Add(card);
            return this;
        }
    }
}
