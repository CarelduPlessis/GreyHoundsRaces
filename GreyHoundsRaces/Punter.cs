using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GreyHoundsRaces
{
    public abstract class Punter
    {
        public abstract string PunterName { get; set; }
        public abstract double Cash { get; set; }
        public abstract bool Busted { get; set; }
        public abstract double MyBet { get; set; }
        public abstract GreyHound Dog { get; set; }
        public abstract string WinningDog { get; set; }
        public abstract TextBox DisplayResults { get; set; }
        public abstract System.Windows.Forms.Label LBLMaxBet { get; set; }
        public abstract System.Windows.Forms.Label LBLMinBet { get; set; }
        public abstract RadioButton MyRadioButton { get; set; }
        public abstract CheckBox ChangeBet { get; set; }
    }
}
