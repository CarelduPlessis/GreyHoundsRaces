Write a log of my work and Commenting 

Programe Requirements:
-------------------------------------
Form features
    1.1 The maximum amount that can be bet for each bettor in a label
    1.2 The Up/down box can only go to that maximum number for each bettor
    1.3 When the Bet is laid the Name, Amount, and Dog appear on the right
    1.4 When a person is out of money, they cannot bet again 
    1.5 When all the bettors lose (which they eventually will) the game is over

Class Operations
    2.1 Two classes Greyhound and Bet (Bet is optional)
    2.2 An Abstract Punter class
    2.3 Three inherited bettor classes

Unit test
    3.1 A unit test using Instantiation


***********************************************************************************************************************************************************************************************************************

Bet Class -- have not used this class in my program

***********************************************************************************************************************************************************************************************************************

I am not to sure how to use this class in this Assignment

because the Punter class already stores these values. 

Why can't I just access it from the Punter Class?


I want to drop this class but i am not to sure how it will effect my mark as it is in the marking rubric 

("Two classes Greyhound and Bet (Bet is optional)").




***********************************************************************************************************************************************************************************************************************

Greyhound Class

***********************************************************************************************************************************************************************************************************************

The objective of the Greyhound Class is:
----------------------------------------

* Store the dog values with these properties: DogName, DogPicture and RaceTrackLength.

* Move the dog with the Move(int distance) methored.

* resets the dogs position after each race with the ResetRace() methored.


Have not used the property below:

--- I am still trying to work out if RaceTrackLength will be used in the Move(int distance) methored 

Greyhound is a normal public class that stores the dog values in the properties of the Greyhound class. 




***********************************************************************************************************************************************************************************************************************

Punter Abstract Class

***********************************************************************************************************************************************************************************************************************

The objective of the Punter Class is:
---------------------------------------

* To create an Idea of the people that bet in the Game, that other classes will Inherit from.

* All the values of the other class (Carel Class, Joe Class, AI Class) are accessed from this class.

- The properties: string PunterName, double Cash, bool Busted, double MyBet, GreyHound Dog, string WinningDog, System.Windows.Forms.Label LBLMaxBet, 
                  System.Windows.Forms.Label LBLMinBet, RadioButton MyRadioButton 

***********************************************************************************************************************************************************************************************************************

All Inheritance Class (Carel Class, Joe Class, AI Class)

***********************************************************************************************************************************************************************************************************************
The objective of All the Inheritance Classes is:
------------------------------------------------

* These classes make the idea they inherated real by implementing the properties by:

---- Override all the Inherited properties in each class (Carel Class, Joe Class, AI Class) inorder to store unique values in each class. 

---- Use the Constructor to Initialize a new instance of each class.

***********************************************************************************************************************************************************************************************************************

FactoryPunter Static Class

***********************************************************************************************************************************************************************************************************************
The objective of the FactoryPunter Class is:
--------------------------------------------

* The FactoryPunter class is to manage the Initializing of new instance of each Inheritance Class (Carel Class, Joe Class, AI Class) for the Punter Class.

----- Keep track of the over all number of new instance of Classes.

* Manage the speed of the GreyHounds (Dogs) with a reserved/special key word Random that generates random Numbers. 


Note: I have note used the FactoryPunter class to manage anything other then what is writen above.



***********************************************************************************************************************************************************************************************************************

Form: GreyHoundsRaces

***********************************************************************************************************************************************************************************************************************
The objective of the GreyHoundsRaces Form is:
---------------------------------------------

* This is where the Game is Played (Where all the logic of the game is coded)

* The Rules of the Game:

--- The game only ends when all the punters are out of cash or don't have enough cash to cover the entry amout to bet.

--- All punters that are not busted (not broke) must bet between 45 - 150 dollars on a dog of their choice.

--- Note: The only why to bet more then 150 dollars is to go ALL IN (beting all the cash the punter have).

--- There are three dogs to choice from (Speedy Pebbles, To Hot To Handle, Speeding Bullet).

--- When the punter have set the amount of cash and chosen the dog to bet on, then the punter can place the bet.

--- When all three punters placed their bets the race can begin.

--- Note: The punters may have to take part in more then one race for the game to end. 

--- If the races outcome is a Draw nobody loses money or gain money because the race doesn't count.

--- Note: there is two "await Task.Delay()" in this Class.

    ---- The first Delay is used to speed up or slow down the race.

    ---- The second Delay is used to give the user time to see who won and who lost (this ones delay is hard coded).




***********************************************************************************************************************************************************************************************************************

TestingGreyHoundsRacesGame (Unit Testing)

***********************************************************************************************************************************************************************************************************************
The objective of the TestingGreyHoundsRacesGame Unit Test Project is:
---------------------------------------------------------------------

What is Instantiation?

By (Mark Michaelis and Eric Lippert, Date: Oct 21, 2015) "Instantiation is when a object is created from a class because a object is an instances of a class".

source: https://www.informit.com/articles/article.aspx?p=2438407#:~:text=The%20process%20of%20creating%20an,object%20(see%20Listing%205.3).


* Testing the Instantiation of my classes (Carel Class, Joe Class, AI Class) by testing: 

       ----- The Number Of new class instances.

       ----- Test the initializing of my classes by checking if they keep their values in the expected properties.

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

Recent Problems (bugs)

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


**** The second run of the race is where the pictureboxes stop moving. --- problem solved
     
    the programe skips the if statments -- probably


**** Randomly everyone lose at the same time (no winners) ---  problem solved


**** More then one winner ---  problem solved


**** Game Breaks down on the third race (this problem my manavest more as the game have more races) ---  problem solved

------- buttons and radiobuttons are disabled when they are not supposed to.

          --- For example one of the Punter radiobutton is disabled with out being busted.


*** The draw and winner feature logic wasn't work proberly  ---  problem solved

     ---- For example displayed the wronge text


*** issue where the dogs that are not beted on doesn't move. ---  problem solved





The code below helps with debuging 
            
Debug.WriteLine("distances Length " + distances.Length);
Debug.WriteLine(Winners.Count);
Debug.WriteLine("the winner is " + Winners[0].DogName);
Debug.WriteLine("the Copy is " + dog[Array.IndexOf(findDogIndex, Winners[0].DogName)].DogName);
Debug.WriteLine("the Index is " + Array.IndexOf(findDogIndex, Winners[0].DogName));





----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Improvements in the future of this program

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

* I want to improve the robustness of my programs betting feature in the UI where I disable and enable buttons.

* I want to cut down on the code that works out the results of the race and displays it by using methods.

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------








