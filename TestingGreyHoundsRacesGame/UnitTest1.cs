using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreyHoundsRaces;


namespace TestingGreyHoundsRacesGame
{

    [TestClass]
    public class UnitTest1
    {
        // Check the number of new Instances in the FactoryPunter class
        [TestMethod]
        public void TestNumberOfClassInstances()
        {
            GreyHound[] dog = new GreyHound[3];

            FactoryPunter.CreatePunter("Carel", 200, false, 45, dog[0], "", null, null, null, null, null);
            FactoryPunter.CreatePunter("AI", 200, false, 45, dog[1], "", null, null, null, null, null);
            FactoryPunter.CreatePunter("Joe", 200, false, 45, dog[2], "", null, null, null, null, null);

            Assert.AreEqual(3,FactoryPunter.count);
        }


        // Check if the values is initialized and stored correctly in the punter class
        [TestMethod]
        public void TestInitializing()
        {
            Punter[] punter = new Punter[3];
            GreyHound[] dog = new GreyHound[3];

            punter[0] = FactoryPunter.CreatePunter("Carel", 200, false, 45, dog[0], "", null, null, null, null, null);
           
            Assert.AreEqual("Carel", punter[0].PunterName);
            /*
             * other values that can be tested
             * 
                Assert.AreEqual(200, punter[0].Cash);
                Assert.AreEqual(false, punter[0].Busted);
                Assert.AreEqual(45, punter[0].MyBet);
                Assert.AreEqual("", punter[0].WinningDog);
            */

        }
    }
}
