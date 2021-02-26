using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using UglyTrivia;

namespace effectively.tests.BreakoutClass
{
    [TestFixture]
    public class The_game
    {

        //Given the player has just gotten out of the penalty box
        //  The Players place is only advanced by one less than the current roll

        [TestFixture]
        public class GivenThePlayerHasJustGottenOutOfThePenaltyBox
        {
            [TestCase(0, 5, ExpectedResult = 4)]
            [TestCase(5, 5, ExpectedResult = 9)]
            [TestCase(11, 2, ExpectedResult = 11)]
            [TestCase(11,3, ExpectedResult = 1)]
            [Test]
            public int ThenThePlayersPlaceIsOnlyAdvancedByOneLessThanTheCurrentRoll(int currentPlace, int rolledValued)
            {

                TestableGame game = new TestableGame();
                game.add("Person1");
                game.setCurrentPlaceTest(0, currentPlace);
                game.setIsInPenaltyBoxTest(0, true);
                game.roll(rolledValued);
                return game.getPlayerPlaceTest(0);

            }
        }

        [TestFixture]
        public class GivenThePlayerIsOutOfPenaltyBox
        {

           
        }
    }

    internal class TestableGame : Game
    {

        public void setCurrentPlaceTest(int currentPlayer, int currentPlace)
        {
            places[currentPlayer] = currentPlace;
        } 

       public void setIsInPenaltyBoxTest(int currentPlayer, bool isInPenaltyBox)
        {
            inPenaltyBox[currentPlayer] = isInPenaltyBox;
        }

        public int getPlayerPlaceTest(int currentPlayer)
        {
            return places[currentPlayer];
        }




    }


    
}
