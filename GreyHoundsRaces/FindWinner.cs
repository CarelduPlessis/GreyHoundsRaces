using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace GreyHoundsRaces
{
    public class FindWinner
    {
        #region initialisation
        public List<GreyHound> ListOfWinner { get; set; }
        public List<Punter> Punter { get; set; }

        public List<GreyHound> Dog { get; set; }

        public FindWinner(List<GreyHound> listOfWinner, List<Punter> punter, List<GreyHound> dog)
        {
            ListOfWinner = listOfWinner;
            Punter = punter;
            Dog = dog;
        }
        #endregion

        #region Methods: WonRace(int k), LostRace(int k) and Draw(int j)
        string displayWinnerDog = "";
        public void WonRace(int k)
        {
            if (Punter[k].Busted == false)
            {
                displayWinnerDog = Punter[k].Dog.DogName;

                Punter[k].Cash = Punter[k].Cash + Punter[k].MyBet;
                Punter[k].DisplayResults.Text = Punter[k].PunterName + " Won and Now has $"
                    + Punter[k].Cash + ". Hound Name " + Punter[k].Dog.DogName;
            }
            else
            {
                displayWinnerDog = Punter[k].Dog.DogName;

                Punter[k].DisplayResults.Text = Punter[k].PunterName + "Won but stays Busted! "
                + " Hound Name " + Punter[k].Dog.DogName;
            }
        }

        public void LostRace(int k)
        {
            if (Punter[k].Busted == false)
            {
                Punter[k].Cash = Punter[k].Cash - Punter[k].MyBet;

                Punter[k].DisplayResults.Text = Punter[k].PunterName + " Lost and Now has $"
                    + Punter[k].Cash + ". Hound Name " + Punter[k].Dog.DogName;
            }
            else
            {
                Punter[k].DisplayResults.Text = Punter[k].PunterName + " Lost and stays Busted! "
                    + " Hound Name " + Punter[k].Dog.DogName;
            }
        }

        public void Draw(int j)
        {
            Punter[j].DisplayResults.Text = "This race doesn't count becuase its a draw.";
        }
        #endregion

        #region Work out who is the winner and Display them
        public void LookForWinner()
        {
            #region NotUsedAtTheMoment: I am trying to use the Dictionary in the future
            //MessageBox.Show(Punter[0].Dog.DogName);

            /*
            var Punters = new Dictionary<string, (string DogName, int PunterDogLocation, string PunterName, bool ISPunterBusted, int PunterIndex)>();

            Punters.Add(Punter[0].Dog.DogName, (Punter[0].Dog.DogName, Punter[0].Dog.DogPicture.Location.X, Punter[0].PunterName, Punter[0].Busted, 0));
            Punters.Add(Punter[1].Dog.DogName, (Punter[1].Dog.DogName, Punter[1].Dog.DogPicture.Location.X, Punter[1].PunterName, Punter[1].Busted, 1));
            Punters.Add(Punter[2].Dog.DogName, (Punter[2].Dog.DogName, Punter[2].Dog.DogPicture.Location.X, Punter[2].PunterName, Punter[2].Busted, 2));

            Debug.WriteLine("Index 0:  " + Punter[0].Dog.DogName);
            Debug.WriteLine("Index 1:  " + Punter[1].Dog.DogName);
            Debug.WriteLine("Index 2:  " + Punter[2].Dog.DogName);
            */
            #endregion

            #region NotUsedAtTheMoment: Find winner Using a Dictionary
            /*
            for (int i = 0; i < Punters.Count; i++)
            {
                if (ListOfWinner.Count > i) {
                    Debug.WriteLine("Index:  " + i);
                    if (Punters.ContainsKey(ListOfWinner[i].DogName))
                    {
                        //MessageBox.Show("In FindWinner.cs " + Punters[ListOfWinner[i].DogName].DogName);

                        if (ListOfWinner.Count == 1 && ListOfWinner[0].DogName == Punters[ListOfWinner[0].DogName].DogName)
                        {
                            WonRace(Punters[ListOfWinner[0].DogName].PunterIndex);
                        }


                        if (ListOfWinner.Count == 2)
                        {
                            if (ListOfWinner[0].DogPicture.Location.X > ListOfWinner[1].DogPicture.Location.X)
                            {
                                WonRace(Punters[ListOfWinner[0].DogName].PunterIndex);
                            }
                            else if (ListOfWinner[0].DogPicture.Location.X < ListOfWinner[1].DogPicture.Location.X)
                            {
                                WonRace(Punters[ListOfWinner[1].DogName].PunterIndex);
                            }
                            else if (ListOfWinner[0].DogPicture.Location.X == ListOfWinner[1].DogPicture.Location.X)
                            {
                                Random flipACoined = new Random();
                                Debug.WriteLine("flipACoined");
                                int randomIndex = flipACoined.Next(0, 2);

                                if (ListOfWinner[randomIndex].DogName == Punter[i].Dog.DogName)
                                {
                                    WonRace(randomIndex);
                                }
                            }
                        }
                    }
                }
            }*/
            #endregion

            Debug.WriteLine("Count Winners:  " + ListOfWinner.Count);
            Debug.WriteLine("Current winner ZB:  " + displayWinnerDog);

            #region Current Solution to find the winner
            for (int i = 0; i < Punter.Count; i++)
            {
                if (ListOfWinner.Count == 1 && ListOfWinner[0].DogName == Punter[i].Dog.DogName)
                {
                    Debug.WriteLine("Winner dog:  " + ListOfWinner[0].DogName);
                    WonRace(i);
                }

                if (ListOfWinner.Count == 2)
                {
                    Debug.WriteLine("Winner dog:  " + ListOfWinner[0].DogName);
                    Debug.WriteLine("Winner dog:  " + ListOfWinner[1].DogName);
                    if (ListOfWinner[0].DogPicture.Location.X > ListOfWinner[1].DogPicture.Location.X)
                    {
                        for (int j = 0; j < Punter.Count; j++)
                        {
                            if (ListOfWinner[0].DogName == Punter[j].Dog.DogName)
                            {
                                WonRace(j);
                            }
                        }
                    }
                    else if (ListOfWinner[0].DogPicture.Location.X < ListOfWinner[1].DogPicture.Location.X)
                    {
                        for (int j = 0; j < Punter.Count; j++)
                        {
                            if (ListOfWinner[1].DogName == Punter[j].Dog.DogName)
                            {
                                WonRace(j);
                            }
                        }
                    }
                    else if (ListOfWinner[0].DogPicture.Location.X == ListOfWinner[1].DogPicture.Location.X)
                    {
                        Random flipACoined = new Random();
                        Debug.WriteLine("flipACoined");
                        int randomIndex = flipACoined.Next(0, 2);

                        for (int j = 0;  j < Punter.Count; j++) 
                        {
                            if (ListOfWinner[randomIndex].DogName == Punter[j].Dog.DogName)
                            {
                                WonRace(j);
                            }
                        }
                    }
                }
                else if (ListOfWinner.Count == 3) {
                    for (int j = 0; j < Dog.Count; j++) 
                    {
                        Debug.WriteLine("Draw: " + i);
                        Draw(j);
                    }  
                }   
            }
            #endregion

            #region Find Losers 
            for (int i = 0; i < Punter.Count; i++)
            {
                if (displayWinnerDog != Punter[i].Dog.DogName) 
                {
                   LostRace(i);
                }
            }
            #endregion

            #region Refactored: Display Winner Dog 
          
            if (displayWinnerDog != "") //A punter's dog wins else the race is a draw
            {
                MessageBox.Show("Winning Dog is: " + displayWinnerDog);
            }
            else if (displayWinnerDog == "")
            {
                MessageBox.Show("This Race doesn't Count");
            }
            #endregion

            #region NotUsedAtTheMoment: Display Winner Dog 
           /*
            if (displayWinnerDog != "") // punters winning dog  else house wins
            {
                MessageBox.Show("Winning Dog is: " + displayWinnerDog);
            }
            else if (displayWinnerDog == "" && ListOfWinner.Count == 1)
            {
                MessageBox.Show("Winning Dog is: " + ListOfWinner[0].DogName);
            }
            else if (displayWinnerDog == "" && ListOfWinner.Count == 2 & ListOfWinner[0].DogName != ListOfWinner[1].DogName)
            {
                MessageBox.Show("Winning Dogs are: " + ListOfWinner[0].DogName + " , " + ListOfWinner[1].DogName);
            }
            else if (displayWinnerDog == "" && ListOfWinner.Count == 2 & ListOfWinner[0].DogName == ListOfWinner[1].DogName)
            {
                MessageBox.Show("Winning Dog is: " + ListOfWinner[0].DogName);
            }
           */
            #endregion

            #region Clear ListOfWinner, List of Punter and a Dictionary of Punters
            // Make Space for new values:
            ListOfWinner.Clear();
            Punter.Clear();
            displayWinnerDog = "";
            //Punters.Clear();
            #endregion

        }
        #endregion
    }
}


