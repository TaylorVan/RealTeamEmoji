using NUnit.Framework;
using TestApp1;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //Test to check if the piece passed through the method is the same as expected results
        [Test]
        public void PieceTest()
        {
            //create a new page and piece
            MainPage page = new MainPage();
            Piece piece1 = new Piece();
            //Fill in the expected values into the piece
            piece1.Catagory = "Beam";
            piece1.PartName = "7 Beam";
            piece1.PartNum = "1234";
            piece1.Url = "Test.com";
            //Get the test piece
            Piece piece2 = page.GetPieceTest();
            //Assert to make sure they are the same
            Assert.AreEqual(piece1.Catagory, piece2.Catagory);
            Assert.AreEqual(piece1.PartName, piece2.PartName);
            Assert.AreEqual(piece1.PartNum, piece2.PartNum);
            Assert.AreEqual(piece1.Url, piece2.Url);
        }


        //Write method for testing probability
        [Test]
        public void PassedThreshHold()
        {
            //Creates new main page
            MainPage page = new MainPage();
            //gets results for a number higer than current threshold
            bool result = page.ProbabilityTest(0.7);
            //Assert to make sure its true
            Assert.IsTrue(result);
        }

        [Test]
        public void FailedThresHold()
        {
            //Crestes new main page
            MainPage page = new MainPage();
            //gets results for a number higer than current threshold
            bool result = page.ProbabilityTest(0.5);
            //Assert to make sure its false
            Assert.IsFalse(result);
        }
    }
}