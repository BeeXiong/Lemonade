using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;


namespace LemonadeTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTransaction()
        {
            //create an instance
            Store Store = new Store();
            //arrange to get all the requirements for the function         
            string userInput = "15";
            decimal.TryParse(userInput, out Store.purchaseAmount);

            Store.SetLemonPrice();
            //arrange the testing variables
            decimal testValue1 = .25m;
            decimal testValue2 = 15;
            decimal results;
            //act
            results = Store.GetLemonPrice() * Store.GetPurchaseAmount();
            //assert
            Assert.AreEqual(testValue1 * testValue2, results);
        }
        [TestMethod]
        public void TestSetTaste()
        {
            //create an instance
            Recipe recipe = new Recipe();
            //arrange to get all the requirements for the function
            string sugarCubeChoice = "5";
            string lemonChoice = "10";
            recipe.sugarAmount = Convert.ToInt16(sugarCubeChoice);
            recipe.lemonAmount = Convert.ToInt16(lemonChoice);

            recipe.GetLemonAmount();
            recipe.GetSugarAmount();
            recipe.SetTaste();
            
            //arrange to get the testing variables
            bool result;
            //act (actual test)
            result = recipe.GetSourTaste();

            Assert.AreEqual(true,result);
        }
        [TestMethod]
        public void TestVerify()
        {
            Recipe newRecipe = new Recipe();

            //arrange

            string lemonChoice = "8";
            newRecipe.lemonAmount = (Convert.ToInt16(lemonChoice));

            //action
            newRecipe.VeryifyLemonAmount(9);
            
            Assert.IsTrue(newRecipe.VeryifyLemonAmount(9));
        }
        [TestMethod]
        public void TestSubtraction()
        {
            //arrange
            HumanPlayer Tester = new HumanPlayer();
            Tester.gameInventory.gameIceCubes.Add(new IceCube());
            Tester.gameInventory.gameIceCubes.Add(new IceCube());
            Tester.gameInventory.gameIceCubes.Add(new IceCube());
            Tester.gameInventory.gameIceCubes.Add(new IceCube());
            Tester.gameInventory.gameIceCubes.Add(new IceCube());
            Tester.gameInventory.gameIceCubes.Add(new IceCube());
            Tester.gameInventory.gameIceCubes.Add(new IceCube());
            Tester.gameInventory.gameIceCubes.Add(new IceCube());
            Tester.gameInventory.gameIceCubes.Add(new IceCube());
            Tester.gameInventory.gameIceCubes.Add(new IceCube());
            Tester.gameInventory.gameIceCubes.Add(new IceCube());
            Tester.gameInventory.gameIceCubes.Add(new IceCube());
            Tester.gameInventory.gameIceCubes.Add(new IceCube());


            Tester.gameRecipe.SetItemSelection("ice cubes");
            Tester.inventoryAmount = 10;
         
            //act
            decimal results = 3;
            Tester.SubtractInventory();

            //assert
            Assert.AreEqual(Tester.gameInventory.gameIceCubes.Count , results);
        }
    }
    
}
