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
        private class TestableGame:Game
		{
            public string MessageLog { get; set; }

			protected override void Log(string message)
			{
				MessageLog += message + Environment.NewLine;
			}
		}

        [Test]
        public void Approval()
		{
            var aGame = new TestableGame();

            aGame.add("Chet");
            aGame.add("Pat");

            aGame.roll(4);
            aGame.wasCorrectlyAnswered();

            aGame.roll(6);
            aGame.wrongAnswer();

            aGame.roll(5);
            aGame.wrongAnswer();

            aGame.roll(4);
            aGame.wrongAnswer();

            aGame.roll(6);
            aGame.wasCorrectlyAnswered();

            aGame.roll(3);
            aGame.wasCorrectlyAnswered();

            aGame.roll(5);
            aGame.wrongAnswer();

            aGame.roll(1);
            aGame.wasCorrectlyAnswered();

            Assert.AreEqual(ApprovalResults + Environment.NewLine, aGame.MessageLog);
        }

        [TestFixture]
        public class GivenThePlayerHasJustGottenOutOfThePenaltyBox
        {
            [Test]
            public void ThenThePlayersPlaceIsOnlyAdvancedByOneLessThanTheCurrentRoll()
            {
                TestableGame game = new TestableGame();
                game.add("Larry");
                Assert.AreEqual(4, game.GetOutOfPenaltyBox(5));
            }
        }

        const string ApprovalResults = @"Chet was added
They are player number 1
Pat was added
They are player number 2
Chet is the current player
They have rolled a 4
Chet's new location is 4
The category is Pop
Pop Question 0
Answer was corrent!!!!
Chet now has 1 Gold Coins.
Pat is the current player
They have rolled a 6
Pat's new location is 6
The category is Sports
Sports Question 0
Question was incorrectly answered
Pat was sent to the penalty box
Chet is the current player
They have rolled a 5
Chet's new location is 9
The category is Science
Science Question 0
Question was incorrectly answered
Chet was sent to the penalty box
Pat is the current player
They have rolled a 4
Pat is not getting out of the penalty box
Question was incorrectly answered
Pat was sent to the penalty box
Chet is the current player
They have rolled a 6
Chet is not getting out of the penalty box
Pat is the current player
They have rolled a 3
Pat is getting out of the penalty box
Pat's new location is 8
The category is Pop
Pop Question 1
Answer was correct!!!!
Pat now has 1 Gold Coins.
Chet is the current player
They have rolled a 5
Chet is getting out of the penalty box
Chet's new location is 1
The category is Science
Science Question 1
Question was incorrectly answered
Chet was sent to the penalty box
Pat is the current player
They have rolled a 1
Pat is getting out of the penalty box
Pat's new location is 8
The category is Pop
Pop Question 2
Answer was correct!!!!
Pat now has 2 Gold Coins.";
    }
}
