namespace CodingChallenge.Models
{
    public sealed class Discover : BaseCreditCard
    {
        public Discover(decimal balance)
        {
            CurrentBalance = balance;
        }

        public override decimal InterestRate
        {
            get { return 0.01m; }
        }
    }
}
