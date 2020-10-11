
namespace GreyHoundsRaces
{
    public class Bet
    {
        public double AmountBet { get; set; }
        public string DogBetOn { get; set; }

        public Bet(string dogbeton, double amountbet) {
            AmountBet = amountbet;
            DogBetOn = dogbeton;
        }
    }
}
