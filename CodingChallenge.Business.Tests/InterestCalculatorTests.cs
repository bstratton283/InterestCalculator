using CodingChallenge.Models;
using CodingChallenge.Models.Interfaces;
using CodingChallenge.Business;
using System.Collections.Generic;
using Xunit;

namespace CodingChallenge.Business.Tests
{
    public class InterestCalculatorTests
    {
        [Fact]
        public void TestCase1()
        {
            //Arrange
            decimal bal = 100m;
            var visa    = new Visa(bal);
            var mc      = new MasterCard(bal);
            var disc    = new Discover(bal);

            Wallet homersWallet = new Wallet();
            homersWallet.AddCard(visa);
            homersWallet.AddCard(mc);
            homersWallet.AddCard(disc);

            Person homer = new Person("Homer J Simpson", new List<Wallet>() { homersWallet });

            //Act
            decimal interestHomer = InterestCalculator.CalculatePersonSimpleInterest(homer);

            decimal interestVisa        = InterestCalculator.CalculateSimpleInterest(visa.CurrentBalance, visa.InterestRate);
            decimal interestMasterCard  = InterestCalculator.CalculateSimpleInterest(mc.CurrentBalance, mc.InterestRate);
            decimal interestDiscover    = InterestCalculator.CalculateSimpleInterest(disc.CurrentBalance, disc.InterestRate);

            //Assert
            Assert.Equal(16m, interestHomer);       //Total simple interest for the person

            Assert.Equal(10m, interestVisa);        //Simple interest per card
            Assert.Equal(5m, interestMasterCard);
            Assert.Equal(1m, interestDiscover);

            Assert.Equal(interestHomer, interestVisa + interestMasterCard + interestDiscover); //Total should equal the sum of all cards
        }

        [Fact]
        public void TestCase2()
        {
            //Arrange
            decimal bal = 100m;
            var visa = new Visa(bal);
            var mc = new MasterCard(bal);
            var disc = new Discover(bal);

            Wallet margesWallet1 = new Wallet();
            margesWallet1.AddCard(visa);
            margesWallet1.AddCard(disc);

            Wallet margesWallet2 = new Wallet();
            margesWallet2.AddCard(mc);

            Person marge = new Person("Marge Simpson", new List<Wallet>() { margesWallet1, margesWallet2 });

            //Act
            decimal interestMarge = InterestCalculator.CalculatePersonSimpleInterest(marge);

            decimal interestWallet1 = InterestCalculator.CalculateWalletSimpleInterest(margesWallet1);
            decimal interestWallet2 = InterestCalculator.CalculateWalletSimpleInterest(margesWallet2);

            //Assert
            Assert.Equal(16m, interestMarge);       //Total simple interest for the person

            Assert.Equal(11m, interestWallet1);     //Simple interest per wallet
            Assert.Equal(5m, interestWallet2);

            Assert.Equal(interestMarge, interestWallet1 + interestWallet2); //Total should equal the sum of all wallets
        }

        [Fact]
        public void TestCase3()
        {
            //Arrange
            decimal bal = 100m;
            var visa = new Visa(bal);
            var mc = new MasterCard(bal);
            var disc = new Discover(bal);

            Wallet bartsWallet = new Wallet();
            bartsWallet.AddCard(mc);
            bartsWallet.AddCard(visa);

            Person bart = new Person("Bart Simpson", new List<Wallet>() { bartsWallet });

            Wallet lisasWallet = new Wallet();
            lisasWallet.AddCard(visa);
            lisasWallet.AddCard(mc);

            Person lisa = new Person("Lisa Simpson", new List<Wallet>() { lisasWallet });

            //Act
            decimal interestBart            = InterestCalculator.CalculatePersonSimpleInterest(bart);
            decimal interestBartsWallet     = InterestCalculator.CalculateWalletSimpleInterest(bartsWallet);

            decimal interestLisa            = InterestCalculator.CalculatePersonSimpleInterest(lisa);
            decimal interestLisasWallet     = InterestCalculator.CalculateWalletSimpleInterest(lisasWallet);

            //Assert
            Assert.Equal(15m, interestBart);
            Assert.Equal(15m, interestLisa);

            Assert.Equal(15m, interestBartsWallet);
            Assert.Equal(15m, interestLisasWallet);
        }
    }
}
