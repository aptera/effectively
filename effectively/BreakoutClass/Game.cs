using effectively;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UglyTrivia
{
    public class Game
    {

        public enum QuestionType
        {
            Pop,
            Science,
            Rock,
            Sports
        }

        List<string> players = new List<string>();

        protected int[] places = new int[6];
        int[] purses = new int[6];

        protected bool[] inPenaltyBox = new bool[6];

        LinkedList<string> popQuestions = new LinkedList<string>();
        LinkedList<string> scienceQuestions = new LinkedList<string>();
        LinkedList<string> sportsQuestions = new LinkedList<string>();
        LinkedList<string> rockQuestions = new LinkedList<string>();

        int currentPlayer = 0;
        bool isGettingOutOfPenaltyBox;

        public Game()
        {
            for (int i = 0; i < 50; i++)
            {
                popQuestions.AddLast(createQuestion(i, QuestionType.Pop));
                scienceQuestions.AddLast(createQuestion(i, QuestionType.Science));
                sportsQuestions.AddLast(createQuestion(i, QuestionType.Sports));
                rockQuestions.AddLast(createQuestion(i, QuestionType.Rock));
            }
        }
        public String createQuestion(int index, QuestionType type)
        {
            return $"{nameof(type)} Question {index}";
        }

        public bool isPlayable()
        {
            return (howManyPlayers() >= 2);
        }

        public bool add(String playerName)
        {
            players.Add(playerName);
            places[howManyPlayers()] = 0;
            purses[howManyPlayers()] = 0;
            inPenaltyBox[howManyPlayers()] = false;

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + players.Count);
            return true;
        }

        public int howManyPlayers()
        {
            return players.Count;
        }

        public void roll(int rolledValue)
        {
            Console.WriteLine(players[currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + rolledValue);

            if (inPenaltyBox[currentPlayer])
            {
                rollingWhileInPenalty(rolledValue);
            }
            else
            {
                advancePlayer(rolledValue);
                nextRound();
            }
        }

        private void rollingWhileInPenalty(int rolledValue)
        {
            if (isOdd(rolledValue))
            {
                releasePlayerNextRound(rolledValue);
            }
            else
            {
                playerDoesNotGetOutOfPenaltyBox();
            }
        }

        private void releasePlayerNextRound(int rolledValue)
        {
            playerGetsOutOfPenaltyBox();
            advancePlayer(rolledValue);
            nextRound();
        }

        private bool isOdd(int number)
        {
            return (number % 2 != 0);
        }

        private void nextRound()
        {
            Console.WriteLine("The category is " + currentCategory());
            askQuestion();
        }
        private void playerDoesNotGetOutOfPenaltyBox()
        {
            Console.WriteLine(players[currentPlayer] + " is not getting out of the penalty box");
            isGettingOutOfPenaltyBox = false;
        }
        private void playerGetsOutOfPenaltyBox()
        {
            isGettingOutOfPenaltyBox = true;
            Console.WriteLine(players[currentPlayer] + " is getting out of the penalty box");
        }
        private void advancePlayer(int roll)
        {
            PlayerMover playerMover = new PlayerMover(places[currentPlayer], roll, isGettingOutOfPenaltyBox);
            places[currentPlayer] = playerMover.GetNextPlace();

            Console.WriteLine(players[currentPlayer] + "'s new location is " + places[currentPlayer]);
        }
        private void askQuestion()
        {
            if (currentCategory() == QuestionType.Pop)
            {
                getQuestion(popQuestions);
            }
            if (currentCategory() == QuestionType.Science)
            {
                getQuestion(scienceQuestions);
            }
            if (currentCategory() == QuestionType.Sports)
            {
                getQuestion(sportsQuestions);
            }
            if (currentCategory() == QuestionType.Rock)
            {
                getQuestion(rockQuestions);
            }
        }

        private void getQuestion(LinkedList<string> lists)
        {
            Console.WriteLine(lists.First());
            lists.RemoveFirst();
        }

        private QuestionType currentCategory()
        {
            if (places[currentPlayer] % 4 == 0) return QuestionType.Pop;

            if (places[currentPlayer] % 4 == 1) return QuestionType.Science;

            if (places[currentPlayer] % 4 == 2) return QuestionType.Sports;

            return QuestionType.Rock;
        }

        public bool wasCorrectlyAnswered()
        {
            if (inPenaltyBox[currentPlayer])
            {
                return checkInPenaltyBox();

            }
            else
            {

                return removePlayerFromPenaltyBox();

            }
        }

        private bool checkInPenaltyBox()
        {
            if (isGettingOutOfPenaltyBox)
            {
                return removePlayerFromPenaltyBox();
            }
            else
            {
                nextPlayer();

                return true;
            }
        }

        private bool removePlayerFromPenaltyBox()
        {
            awardCoins();

            bool winner = didPlayerWin();

            nextPlayer();

            return winner;
        }

        private void nextPlayer()
        {
            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;
        }

        private void awardCoins()
        {
            Console.WriteLine("Answer was correct!!!!");
            purses[currentPlayer]++;
            Console.WriteLine(players[currentPlayer]
                    + " now has "
                    + purses[currentPlayer]
                    + " Gold Coins.");
        }

        public bool wrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(players[currentPlayer] + " was sent to the penalty box");
            inPenaltyBox[currentPlayer] = true;

            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;
            return true;
        }


        private bool didPlayerWin()
        {
            return !(purses[currentPlayer] == 6);
        }
    }

}