using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreyHoundsRaces
{
    public partial class GreyHoundsRaces : Form
    {
        #region Declare Variables, Arrays And Classes
        // Declare array of classes with the size of 3
        Punter[] Punter = new Punter[3];
        GreyHound[] Dog = new GreyHound[3];
        FindWinner FindWinner;
        HashSet<GreyHound> getWinners;
        #endregion

        public GreyHoundsRaces()
        {
            InitializeComponent();
        }

        #region Initializing Varaibles And Classes
        private void GreyHoundsRaces_Load(object sender, EventArgs e)
        {

            btnRace.Enabled = false;
            btnPlaceBet.Enabled = false;
            NUpDwnAmountBet.Enabled = false;
            cmbbxBETONDOG.Enabled = false;
            chbxALLIN.Enabled = false;
            chbxCarelChangeBet.Enabled = false;
            chbxAIChangeBet.Enabled = false;
            chbxJoeChangeBet.Enabled = false;

            //Initializing the GreyHound class (defualt values)
            Dog[0] = new GreyHound("Speedy Pebbles", pbxGreyHound1, pbxFinishLine);
            Dog[1] = new GreyHound("To Hot To Handle", pbxGreyHound2, pbxFinishLine);
            Dog[2] = new GreyHound("Speeding Bullet", pbxGreyHound3, pbxFinishLine);

            //Initializing the Punter class using the Factory Class (defualt values) 
            Punter[0] = FactoryPunter.CreatePunter("Carel", 200, false, 45, Dog[0], "", tbxPunterCarelResults, lblMaxBetValue, lblMinBetValue, rbtnPunterCarel, chbxCarelChangeBet);
            Punter[1] = FactoryPunter.CreatePunter("AI", 200, false, 45, Dog[1], "", tbxPunterAIResults, lblMaxBetValue, lblMinBetValue, rbtnPunterAI, chbxAIChangeBet);
            Punter[2] = FactoryPunter.CreatePunter("Joe", 200, false, 45, Dog[2], "", tbxPunterJoeResults, lblMaxBetValue, lblMinBetValue, rbtnPunterJoe, chbxJoeChangeBet);

            for (int i = 0; i < Punter.Length; i++)
            {
                Punter[i].DisplayResults.Text = Punter[i].PunterName + " available cash is " + Punter[i].Cash;
            }

            getWinners = new HashSet<GreyHound>();
            FindWinner = new FindWinner(getWinners.ToList(), Punter.ToList(), Dog.ToList());
        }
        #endregion

        #region Check if punters is beting 
        // Check if this punter is beting 
        private void rbtnPunterJoe_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPunterJoe.Checked == true)
            {
                chbxALLIN.Enabled = true;
                cmbbxBETONDOG.Enabled = true;
                NUpDwnAmountBet.Enabled = true;
            }
        }

        // Check if this punter is beting 
        private void rbtnPunterCarel_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPunterCarel.Checked == true)
            {
                chbxALLIN.Enabled = true;
                cmbbxBETONDOG.Enabled = true;
                NUpDwnAmountBet.Enabled = true;
            }
        }

        // Check if this punter is beting 
        private void rbtnPunterAI_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPunterAI.Checked == true)
            {
                chbxALLIN.Enabled = true;
                cmbbxBETONDOG.Enabled = true;
                NUpDwnAmountBet.Enabled = true;
            }
        }
        #endregion

        #region Set Bet Amount
        private void NUpDwnAmountBet_ValueChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < Punter.Length; i++)
            {
                if (Punter[i].MyRadioButton.Checked == true)
                {
                    // make sure the punter bets between the minbet and maxbet 
                    if (NUpDwnAmountBet.Value >= Convert.ToInt32(Punter[i].LBLMinBet.Text)
                                    && NUpDwnAmountBet.Value <= Convert.ToInt32(Punter[i].LBLMaxBet.Text))
                    {
                        // Check that punters don't bet more then they have
                        if (Punter[i].Cash >= Convert.ToDouble(NUpDwnAmountBet.Value))
                        {
                            cmbbxBETONDOG.Enabled = true;
                        }
                        else if (Punter[i].Cash < Convert.ToDouble(NUpDwnAmountBet.Value) && Punter[i].Busted == false)
                        {
                            MessageBox.Show(Punter[i].PunterName + " doesn't have enough cash.");
                            NUpDwnAmountBet.Value = Convert.ToDecimal(Punter[i].Cash);
                        }
                    }
                    else
                    {
                        cmbbxBETONDOG.Enabled = false;
                        MessageBox.Show("The bet values must be between " + Punter[i].LBLMinBet.Text + " and " + Punter[i].LBLMaxBet.Text);
                    }
                }
            }
        }
        
        private void chbxALLIN_CheckedChanged_1(object sender, EventArgs e)
        {
            cmbbxBETONDOG.Enabled = true;
        }
        #endregion

        #region Select Dog to Bet On
        string[] findDogIndex = { "Speedy Pebbles", "To Hot To Handle", "Speeding Bullet" };
        private void cmbbxBETONDOG_SelectedIndexChanged(object sender, EventArgs e)
        {
            // finding the dog that the punter is going to bet on
            for (int i = 0; i < Punter.Length; i++)
            {
                if (Punter[i].MyRadioButton.Checked == true)
                {
                    Punter[i].Dog = Dog[Array.IndexOf(findDogIndex, cmbbxBETONDOG.SelectedItem.ToString())];
                }
            }
            btnPlaceBet.Enabled = true;
        }
        #endregion

        #region Place Bet Button
        int countbtnClicks = 0;
        private void btnPlaceBet_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Punter.Length; i++) {
                if (Punter[i].Busted == true)
                {
                    Punter[i].ChangeBet.Enabled = false;
                } else{
                    Punter[i].ChangeBet.Enabled = true;
                    Punter[i].ChangeBet.Checked = false;
                }
            }
   
            // Check if Punter is all in or beting a small amount 
            for (int i = 0; i < Punter.Length; i++)
            {
                if (Punter[i].MyRadioButton.Checked == true)
                {
                    if (chbxALLIN.Checked == true)
                    {
                        Punter[i].MyBet = Punter[i].Cash;
                        Punter[i].DisplayResults.Text = Punter[i].PunterName + " has placed a bet on " + Punter[i].Dog.DogName + " And is ALL IN ( $ " + Punter[i].MyBet + " )";
                    }
                    else
                    {
                        Punter[i].MyBet = Convert.ToDouble(NUpDwnAmountBet.Value);
                        Punter[i].DisplayResults.Text = Punter[i].PunterName + " has placed a bet on " + Punter[i].Dog.DogName + " for $ " + Punter[i].MyBet;
                    }

                }
            }

            countbtnClicks++;

            Debug.WriteLine("Count bets placed: " + countbtnClicks);

            // enables and disables Race button based on the 
            //number of times this button is clicked 
            if (countbtnClicks == 3)
            {
                btnRace.Enabled = true;
                rbtnPunterJoe.Enabled = false;
                rbtnPunterCarel.Enabled = false;
                rbtnPunterAI.Enabled = false;
            }
            else
            {
                btnRace.Enabled = false;
            }

            // reset values
            NUpDwnAmountBet.Value = 45;
            btnPlaceBet.Enabled = false;
            NUpDwnAmountBet.Enabled = false;
            cmbbxBETONDOG.Enabled = false;
            cmbbxBETONDOG.Text = "";
            chbxALLIN.Checked = false;
            chbxALLIN.Enabled = false;

            rbtnPunterJoe.Checked = false;
            rbtnPunterCarel.Checked = false;
            rbtnPunterAI.Checked = false;
        }
        #endregion

        #region Start Race
        // declare variables 
        int numBusted = 0;
        bool isRaceOver = false;
        int[] indexNotBusted = new int[3];
        private async void btnRace_Click(object sender, EventArgs e)
        {
            //int[] distances = new int[Dog.Length];

            int Maxdistance = 0;

            chbxCarelChangeBet.Enabled = false;
            chbxJoeChangeBet.Enabled = false;
            chbxAIChangeBet.Enabled = false;

            btnRace.Enabled = false;

            #region Check if Race is over
            //Continue the race as long as the race is not over
            while (isRaceOver == false)
            {
                for (int i = 0; i < Dog.Length; i++)
                {
                    // Check if dog is at the Finish Line
                    if (Dog[i].DogPicture.Location.X < pbxFinishLine.Location.X)
                    {
                        Dog[i].Move(FactoryPunter.DogSpeed.Next(10, 32));
                        await Task.Delay((int)NUpDwnGameSpeed.Value); // minvalue 20 - 2000 maxvalue of delay time
                    }
                    else
                    {
                        isRaceOver = true;
                        
                        for (int j = 0; j < Dog.Length; j++)
                        {
                            if (Dog[j].DogPicture.Location.X  > Maxdistance) { 
                                Maxdistance = Dog[j].DogPicture.Location.X;
                            }
                        }
                        for (int j = 0; j < Dog.Length; j++)
                        {
                            if (Dog[j].DogPicture.Location.X == Maxdistance)
                            {
                                getWinners.Add(Dog[j]);
                                Debug.WriteLine("distances " + Maxdistance);
                            }
                        }
                    }
                }
            }
            #endregion

            FindWinner.Punter = Punter.ToList();
            FindWinner.ListOfWinner = getWinners.ToList();
            FindWinner.LookForWinner();

            #region Check if Punters are Busted and reset race (if game is not over)
            // Count Number of Plunters that are Busted
            for (int i = 0; i < Punter.Length; i++)
            {
                // Check if any Plunters are busted 
                if (Punter[i].Cash <= 0 || Punter[i].Cash < Convert.ToDouble(Punter[i].LBLMinBet.Text))
                {
                    Punter[i].DisplayResults.Text = Punter[i].PunterName + " is Busted. "
                        + " Hound Name " + Punter[i].Dog.DogName;
                    Punter[i].Busted = true;
                    Punter[i].MyRadioButton.Enabled = false;
                }

                if (Punter[i].Busted == true)
                {
                    numBusted++;
                }
                else
                {
                    indexNotBusted[i] = i;
                    Punter[i].MyRadioButton.Enabled = true;
                    Punter[i].ChangeBet.Enabled = true;
                }
                Punter[i].WinningDog = "";
            }

            await Task.Delay(2300);
            
            //reset the position of the GreyHounds
            for (int i = 0; i < Punter.Length; i++)
            {
                Dog[i].ResetRace();
            }

            isRaceOver = false;
            chbxJoeChangeBet.Checked = false;
            chbxCarelChangeBet.Checked = false;
            chbxAIChangeBet.Checked = false;
            countbtnClicks = numBusted;
          
            // Check if all three Plunters are busted 
            if (numBusted == 3)
            {
                btnPlaceBet.Enabled = false;
                NUpDwnAmountBet.Enabled = false;
                cmbbxBETONDOG.Enabled = false;
                chbxALLIN.Enabled = false;
                rbtnPunterAI.Enabled = false;
                rbtnPunterCarel.Enabled = false;
                rbtnPunterJoe.Enabled = false;
                numBusted = 0;
                MessageBox.Show("All punters can't continue beting!", "Game Over");
            }
            else
            {
                // reset values and continue the game
                numBusted = 0;
            }
            #endregion

        }
        #endregion

        #region Change Bet 
        private void chbxJoeChangeBet_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxJoeChangeBet.Checked == true && countbtnClicks >= numBusted) {
                countbtnClicks--;
                //btnPlaceBet.Enabled = true;
                rbtnPunterJoe.Enabled = true;
                chbxJoeChangeBet.Enabled = false;
                rbtnPunterJoe.Enabled = true;
                //cmbbxBETONDOG.Enabled = true;
                Debug.WriteLine("Count bets placed: " + countbtnClicks);
            }
        }

        private void chbxCarelChangeBet_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxCarelChangeBet.Checked == true && countbtnClicks >= numBusted)
            {
                countbtnClicks--;
               // btnPlaceBet.Enabled = true;
                rbtnPunterCarel.Enabled = true;
                chbxCarelChangeBet.Enabled = false;
                rbtnPunterCarel.Enabled = true;
               // cmbbxBETONDOG.Enabled = true;
                Debug.WriteLine("Count bets placed: " + countbtnClicks);
            }
        }

        private void chbxAIChangeBet_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxAIChangeBet.Checked == true && countbtnClicks >= numBusted)
            {
                countbtnClicks--;
              //  btnPlaceBet.Enabled = true;
                rbtnPunterAI.Enabled = false;
                chbxAIChangeBet.Enabled = false;
                rbtnPunterAI.Enabled = true;
              //  cmbbxBETONDOG.Enabled = true;
                Debug.WriteLine("Count bets placed: " + countbtnClicks);
            }
        }
        #endregion
    }
}
