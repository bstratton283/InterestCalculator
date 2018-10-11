namespace CodingChallenge.Models
{
    public sealed class Visa : BaseCreditCard
    {
        public Visa(decimal balance)
        {
            CurrentBalance = balance;
        }

        public override decimal InterestRate
        {
            get { return 0.1m; }
        }
    }
}
