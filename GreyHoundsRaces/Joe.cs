using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreyHoundsRaces
{
    public class Joe : Punter
    {
        public override string PunterName { get; set; }
        public override double Cash { get; set; }
        public override bool Busted { get; set; }
        public override double MyBet { get; set; }
        public override GreyHound Dog { get; set; }
        public override string WinningDog { get; set; }
        public override TextBox DisplayResults { get; set; }
        public override Label LBLMaxBet { get; set; }
        public override Label LBLMinBet { get; set; }
        public override RadioButton MyRadioButton { get; set; }

        public Joe(string name, double cash, bool busted, double bet, 
            GreyHound dog, string winningdog, TextBox displayresults, Label lblmaxbet, Label lblminbet, RadioButton radiobutton) {
            PunterName = name;
            Cash = cash;
            Busted = busted;
            MyBet = bet;
            Dog = dog;
            WinningDog = winningdog;
            DisplayResults = displayresults;
            LBLMaxBet = lblmaxbet;
            LBLMinBet = lblminbet;
            MyRadioButton = radiobutton;
        }
    }
}
