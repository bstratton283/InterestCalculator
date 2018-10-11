using System.Collections.Generic;

namespace CodingChallenge.Models
{
    public class Person
    {
        public Person(string name, List<Wallet> wallets)
        {
            Name = name;
            Wallets = wallets;
        }

        public string Name { get; private set; }
        public List<Wallet> Wallets { get; private set; } = new List<Wallet>();
    }
}
