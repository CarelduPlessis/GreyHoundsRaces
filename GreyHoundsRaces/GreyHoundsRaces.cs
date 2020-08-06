using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreyHoundsRaces
{
    public partial class GreyHoundsRaces : Form
    {
        // declare array of classes with the size of 3
        Punter[] punter = new Punter[3];
        GreyHound[] dog = new GreyHound[3];
        public GreyHoundsRaces()
        {
            InitializeComponent();
        }

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
            dog[0] = new GreyHound("Speedy Pebbles", pbxGreyHound1, pbxFinishLine);
            dog[1] = new GreyHound("To Hot To Handle", pbxGreyHound2, pbxFinishLine);
            dog[2] = new GreyHound("Speeding Bullet", pbxGreyHound3, pbxFinishLine);

            //Initializing the Punter class using the Factory Class (defualt values) 
            punter[0] = FactoryPunter.CreatePunter("Carel", 200, false, 45, dog[0], "", tbxPunterCarelResults, lblMaxBetValue, lblMinBetValue, rbtnPunterCarel);
            punter[1] = FactoryPunter.CreatePunter("AI", 200, false, 45, dog[1], "", tbxPunterAIResults, lblMaxBetValue, lblMinBetValue, rbtnPunterAI);
            punter[2] = FactoryPunter.CreatePunter("Joe", 200, false, 45, dog[2], "", tbxPunterJoeResults, lblMaxBetValue, lblMinBetValue, rbtnPunterJoe);

            for (int i = 0; i < punter.Length; i++)
            {
                punter[i].DisplayResults.Text = punter[i].PunterName + " available cash is " + punter[i].Cash;
            }
        }

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

        private void NUpDwnAmountBet_ValueChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < punter.Length; i++)
            {
                if (punter[i].MyRadioButton.Checked == true)
                {

                    // make sure the punter bets between the minbet and maxbet 
                    if (NUpDwnAmountBet.Value >= Convert.ToInt32(punter[i].LBLMinBet.Text)
                                    && NUpDwnAmountBet.Value <= Convert.ToInt32(punter[i].LBLMaxBet.Text))
                    {
                        // Check that punters don't bet more then they have
                        if (punter[i].Cash >= Convert.ToDouble(NUpDwnAmountBet.Value))
                        {
                            cmbbxBETONDOG.Enabled = true;
                        }
                        else if (punter[i].Cash < Convert.ToDouble(NUpDwnAmountBet.Value) && punter[i].Busted == false)
                        {
                            MessageBox.Show(punter[i].PunterName + " doesn't have enough cash.");
                            NUpDwnAmountBet.Value = Convert.ToDecimal(punter[i].Cash);
                        }
                    }
                    else
                    {
                        cmbbxBETONDOG.Enabled = false;
                        MessageBox.Show("The bet values must be between " + punter[i].LBLMinBet.Text + " and " + punter[i].LBLMaxBet.Text);
                    }
                }
            }
        }

        private void chbxALLIN_CheckedChanged_1(object sender, EventArgs e)
        {
            cmbbxBETONDOG.Enabled = true;
        }

        string[] findDogIndex = { "Speedy Pebbles", "To Hot To Handle", "Speeding Bullet" };
        private void cmbbxBETONDOG_SelectedIndexChanged(object sender, EventArgs e)
        {
            // finding the dog that the punter is going to bet on
            for (int i = 0; i < punter.Length; i++)
            {
                if (punter[i].MyRadioButton.Checked == true)
                {
                    punter[i].Dog = dog[Array.IndexOf(findDogIndex, cmbbxBETONDOG.SelectedItem.ToString())];
                }
            }
            btnPlaceBet.Enabled = true;
        }

        int countbtnClicks = 0;
        private void btnPlaceBet_Click(object sender, EventArgs e)
        {

            if (punter[0].Busted == true)
            {
                chbxCarelChangeBet.Enabled = false;
            }else {
                chbxCarelChangeBet.Enabled = true;
            }
            
            if (punter[1].Busted == true)
            {
                chbxAIChangeBet.Enabled = false;
            } else{
                chbxAIChangeBet.Enabled = true;
            }
           
            if (punter[2].Busted == true)
            {
                chbxJoeChangeBet.Enabled = false;
            } else{
                chbxJoeChangeBet.Enabled = true;
            }
           
            // Check if Punter is all in or beting a small amount 
            for (int i = 0; i < punter.Length; i++)
            {
                if (punter[i].MyRadioButton.Checked == true)
                {
                    if (chbxALLIN.Checked == true)
                    {
                        punter[i].MyBet = punter[i].Cash;
                        punter[i].DisplayResults.Text = punter[i].PunterName + " has placed a bet on " + punter[i].Dog.DogName + " And is ALL IN ( $ " + punter[i].MyBet + " )";
                    }
                    else
                    {
                        punter[i].MyBet = Convert.ToDouble(NUpDwnAmountBet.Value);
                        punter[i].DisplayResults.Text = punter[i].PunterName + " has placed a bet on " + punter[i].Dog.DogName + " for $ " + punter[i].MyBet;
                    }

                }
            }

            countbtnClicks++;

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
            chbxALLIN.Enabled = false;

            rbtnPunterJoe.Checked = false;
            rbtnPunterCarel.Checked = false;
            rbtnPunterAI.Checked = false;

        }

        // declare variables 
        int numBusted = 0;
        bool isRaceOver = false;
        int[] indexNotBusted = new int[3];
        List<GreyHound> Winners = new List<GreyHound>();
        private async void btnRace_Click(object sender, EventArgs e)
        {
            int[] distances = new int[dog.Length];

            //Continue the race as long as the race is not over
            while (isRaceOver == false)
            {
                for (int i = 0; i < dog.Length; i++)
                {
                    // Check if dog is at the Finish Line
                    if (dog[i].DogPicture.Location.X < pbxFinishLine.Location.X)
                    {
                        dog[i].Move(FactoryPunter.DogSpeed.Next(10, 32));
                        //findMax[i] = dog[i].DogPicture.Location.X;
                        await Task.Delay((int)NUpDwnGameSpeed.Value); // minvalue 20 - 2000 maxvalue of delay time
                    }
                    else
                    {
                        isRaceOver = true;
                        
                        for (int j = 0; j < dog.Length; j++)
                        {
                            distances[j] = dog[j].DogPicture.Location.X;
                        }
                        for (int j = 0; j < dog.Length; j++)
                        {
                            if (dog[j].DogPicture.Location.X == distances.Max())
                            {
                                Winners.Add(dog[j]);
                                Debug.WriteLine("distances " + distances[j]);
                            }
                        }
                    }
                }
            }
            Debug.WriteLine(Winners.Count);
            for (int k = 0; k < dog.Length; k++) {
                // Check if one of the Dogs Won, if not its a draw
                
                if (Winners.Count == 1 && Winners[0].DogName == punter[k].Dog.DogName)
                { // increase Money 
                    if (punter[k].Busted == false) {
                        punter[k].Cash = punter[k].Cash + punter[k].MyBet;
                        punter[k].DisplayResults.Text = punter[k].PunterName + " Won and Now has $"
                            + punter[k].Cash + ". Hound Name " + punter[k].Dog.DogName;
                    } else {
                        punter[k].DisplayResults.Text = punter[k].PunterName + "Won but stays Busted! "
                            + " Hound Name " + punter[k].Dog.DogName;
                    }
                } else if (Winners.Count == 2) {
                    
                    if (Winners[0].DogPicture.Location.X > Winners[1].DogPicture.Location.X)
                    {
                        if (punter[k].Busted == false) {
                            punter[k].Cash = punter[k].Cash + punter[k].MyBet;
                            punter[k].DisplayResults.Text = punter[k].PunterName + " Won and Now has $"
                                + punter[k].Cash + ". Hound Name " + punter[k].Dog.DogName;
                        } else {
                            punter[k].DisplayResults.Text = punter[k].PunterName + "Won but stays Busted! "
                                + " Hound Name " + punter[k].Dog.DogName;
                        }
                    } else if (Winners[0].DogPicture.Location.X < Winners[1].DogPicture.Location.X){
                        punter[k].Cash = punter[k].Cash + punter[k].MyBet;

                        punter[k].DisplayResults.Text = punter[k].PunterName + " Won and Now has $"
                            + punter[k].Cash + ". Hound Name " + punter[k].Dog.DogName;
                    }else if (Winners[0].DogPicture.Location.X == Winners[1].DogPicture.Location.X) {
                        Random flipACoined = new Random();
                        Debug.WriteLine("flipACoined");
                        Debug.WriteLine(Winners[0].DogName);
                        Debug.WriteLine(Winners[1].DogName);
                        if (Winners[flipACoined.Next(0, 2)].DogName == punter[k].Dog.DogName)
                        {
                            if (punter[k].Busted == false)
                            {
                                punter[k].Cash = punter[k].Cash + punter[k].MyBet;
                                punter[k].DisplayResults.Text = punter[k].PunterName + " Won and Now has $"
                                    + punter[k].Cash + ". Hound Name " + punter[k].Dog.DogName;
                            } else{
                                punter[k].DisplayResults.Text = punter[k].PunterName + "Won but stays Busted! "
                                    + " Hound Name " + punter[k].Dog.DogName;
                            }
                        }else {
                            if (punter[k].Busted == false){
                                punter[k].Cash = punter[k].Cash - punter[k].MyBet;

                                punter[k].DisplayResults.Text = punter[k].PunterName + " Lost and Now has $"
                                    + punter[k].Cash + ". Hound Name " + punter[k].Dog.DogName;
                            }else{
                                punter[k].DisplayResults.Text = punter[k].PunterName + " Lost and stays Busted! "
                                    + " Hound Name " + punter[k].Dog.DogName;
                            }
                        }
                    }
                } else if (Winners.Count >= 3){
                    for (int j = 0; j < dog.Length; j++)
                    {
                        punter[j].DisplayResults.Text = "This race doesn't count becuase its a draw.";
                    }
                } else if(Winners[0].DogName != punter[k].Dog.DogName){
                    if (punter[k].Busted == false){
                        punter[k].Cash = punter[k].Cash - punter[k].MyBet;

                        punter[k].DisplayResults.Text = punter[k].PunterName + " Lost and Now has $"
                            + punter[k].Cash + ". Hound Name " + punter[k].Dog.DogName;
                    } else {
                        punter[k].DisplayResults.Text = punter[k].PunterName + " Lost and stays Busted! "
                            + " Hound Name " + punter[k].Dog.DogName;
                    }
                }
            }

            Winners.Clear();

            // Count Number of Plunters that are Busted
            for (int i = 0; i < punter.Length; i++)
            {
                // Check if any Plunters are busted 
                if (punter[i].Cash <= 0 || punter[i].Cash < Convert.ToDouble(punter[i].LBLMinBet.Text))
                {
                    punter[i].DisplayResults.Text = punter[i].PunterName + " is Busted. "
                        + " Hound Name " + punter[i].Dog.DogName;
                    punter[i].Busted = true;
                    punter[i].MyRadioButton.Enabled = false;
                }

                if (punter[i].Busted == true)
                {
                    numBusted++;
                }
                else
                {
                    indexNotBusted[i] = i;
                }
                punter[i].WinningDog = "";
            }

            await Task.Delay(2300);
            
            //reset the position of the GreyHounds
            for (int i = 0; i < punter.Length; i++)
            {
                dog[i].ResetRace();
            }

            isRaceOver = false;
            btnRace.Enabled = false;
            countbtnClicks = numBusted;

            chbxJoeChangeBet.Checked = false;
            chbxCarelChangeBet.Checked = false;
            chbxAIChangeBet.Checked = false;

            

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
                MessageBox.Show("All punters can't continue beting", "Game Over");
            }
            else
            {
                numBusted = 0;
                rbtnPunterAI.Enabled = true;
                rbtnPunterCarel.Enabled = true;
                rbtnPunterJoe.Enabled = true;
            }
        }
      
        private void chbxJoeChangeBet_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxJoeChangeBet.Checked == true && countbtnClicks >= numBusted) {
                countbtnClicks--;
                btnPlaceBet.Enabled = true;
                rbtnPunterJoe.Enabled = true;
                chbxJoeChangeBet.Enabled = false;
            }
        }

        private void chbxCarelChangeBet_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxCarelChangeBet.Checked == true && countbtnClicks >= numBusted)
            {
                countbtnClicks--;
                btnPlaceBet.Enabled = true;
                rbtnPunterCarel.Enabled = true;
                chbxCarelChangeBet.Enabled = false;
            }
        }

        private void chbxAIChangeBet_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxAIChangeBet.Checked == true && countbtnClicks >= numBusted)
            {
                countbtnClicks--;
                btnPlaceBet.Enabled = true;
                rbtnPunterAI.Enabled = false;
                chbxAIChangeBet.Enabled = false;
            }
        }
    }
}
