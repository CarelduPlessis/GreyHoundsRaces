﻿using System;
using System.Windows.Forms;

namespace GreyHoundsRaces
{
    public static class FactoryPunter
    {
       public static Random DogSpeed = new Random();



       public static int count; // managing the instantiation

        public static Punter CreatePunter(string name, double cash, bool busted, double bet,
            GreyHound dog, string winningdog, TextBox displayresults, Label lblmaxbet, Label lblminbet, RadioButton radiobutton, CheckBox changebet)
        {
            if (name == "Joe") {
                count++;
               return new Joe(name, cash, busted, bet, dog, winningdog, displayresults, lblmaxbet, lblminbet, radiobutton, changebet);   
            } else if (name == "Carel") {
                count++;
                return new Carel(name, cash, busted, bet, dog, winningdog, displayresults, lblmaxbet, lblminbet, radiobutton, changebet);
            }else if (name == "AI"){
                count++;
                return new AI(name, cash, busted, bet, dog, winningdog, displayresults, lblmaxbet, lblminbet, radiobutton, changebet);
            }
            return null;
        }
    }    
}    

