using CodingChallenge.Models.Interfaces;

namespace CodingChallenge.Models
{
    public abstract class BaseCreditCard : ICreditCard
    {
        public abstract decimal InterestRate { get; }

        public decimal CurrentBalance { get; protected set; } = 0;
    }
}
