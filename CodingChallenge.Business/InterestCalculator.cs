using CodingChallenge.Models;
using CodingChallenge.Models.Interfaces;

namespace CodingChallenge.Business
{
    public static class InterestCalculator
    {
        public static decimal CalculatePersonSimpleInterest(Person accountHolder)
        {
            decimal totalInterest = 0;

            foreach(var wallet in accountHolder.Wallets)
            {
                totalInterest += CalculateWalletSimpleInterest(wallet);
            }

            return totalInterest;
        }

        public static decimal CalculateWalletSimpleInterest(Wallet wallet)
        {
            decimal totalInterest = 0;

            foreach (ICreditCard card in wallet.CreditCards)
            {
                totalInterest += CalculateSimpleInterest(card.CurrentBalance, card.InterestRate);
            }

            return totalInterest;
        }

        public static decimal CalculateSimpleInterest(decimal balance, decimal rate)
        {
            return balance * rate;
        }
    }
}
