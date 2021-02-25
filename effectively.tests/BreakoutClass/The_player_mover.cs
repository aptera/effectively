using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace effectively.tests.BreakoutClass
{
    [TestFixture]
    public class The_player_mover
    {
        [TestFixture]
        public class GivenThePlayerWasNotInThePenaltyBox
        {
            [TestCase(0, 5, ExpectedResult = 5)]
            [TestCase(5, 5, ExpectedResult = 10)]
            [TestCase(11, 2, ExpectedResult = 1)]
            public int ThenThePlayersPlaceIsAdvancedByTheCurrentRoll(int currentPlace, int roll)
            {
                PlayerMover playerMover = new PlayerMover(currentPlace, roll, false);
                int NextPlace = playerMover.GetNextPlace();
                return NextPlace;
            }

        }

        [TestFixture]
        public class GivenThePlayerHasJustGottenOutOfThePenaltyBox
        {
            [TestCase(0, 5, ExpectedResult = 4)]
            [TestCase(5, 5, ExpectedResult = 9)]
            [TestCase(11, 2, ExpectedResult = 0)]
            public int ThenThePlayersPlaceIsOnlyAdvancedByOneLessThanTheCurrentRoll(int currentPlace, int roll)
            {
                PlayerMover playerMover = new PlayerMover(currentPlace, roll, true);
                int NextPlace = playerMover.GetNextPlace();
                return NextPlace;
            }

        }


    }
}
