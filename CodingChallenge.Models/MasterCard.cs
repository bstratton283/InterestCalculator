namespace CodingChallenge.Models
{
    public sealed class MasterCard : BaseCreditCard
    {
        public MasterCard(decimal balance)
        {
            CurrentBalance = balance;
        }

        public override decimal InterestRate
        {
            get { return 0.05m; }
        }
    }
}
