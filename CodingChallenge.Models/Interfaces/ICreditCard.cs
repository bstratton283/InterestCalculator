namespace CodingChallenge.Models.Interfaces
{
    public interface ICreditCard
    {
        decimal InterestRate { get; }
        decimal CurrentBalance { get; }
    }
}
