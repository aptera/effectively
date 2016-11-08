using effectively.BreakoutClass;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UglyTrivia {
    public class Game {


        public List<string> players = new List<string>();

        public int[] places = new int[6];
        int[] purses = new int[6];

        bool[] inPenaltyBox = new bool[6];

        LinkedList<string> popQuestions = new LinkedList<string>();
        LinkedList<string> scienceQuestions = new LinkedList<string>();
        LinkedList<string> sportsQuestions = new LinkedList<string>();
        LinkedList<string> rockQuestions = new LinkedList<string>();

        int currentPlayer = 0;
        bool isGettingOutOfPenaltyBox;

        public Game() {
            for (int i = 0; i < 50; i++) {
                popQuestions.AddLast("Pop Question " + i);
                scienceQuestions.AddLast(("Science Question " + i));
                sportsQuestions.AddLast(("Sports Question " + i));
                rockQuestions.AddLast(createRockQuestion(i));
            }
        }

        public String createRockQuestion(int index) {
            return "Rock Question " + index;
        }

        public bool isPlayable() {
            return (howManyPlayers() >= 2);
        }

        public bool addPlayer(String playerName) {
            players.Add(playerName);
            addDefaultPlayer();

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + players.Count);
            return true;
        }

        private void addDefaultPlayer() {
            places[howManyPlayers()] = 0;
            purses[howManyPlayers()] = 0;
            inPenaltyBox[howManyPlayers()] = false;
        }

        public int howManyPlayers() {
            return players.Count;
        }

        public void roll(int roll) {
            Console.WriteLine(players[currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (inPenaltyBox[currentPlayer]) {
                GettingOutOfPenaltyBox(roll);
            } else {
                MakeNormalMove(roll, false);
            }

        }

        private void MakeNormalMove(int roll, bool isGettingOutOfPenaltyBox) {
            new Mover(this).MakeNormalMove(roll, currentPlayer, isGettingOutOfPenaltyBox);
            askQuestion();
        }

        private void GettingOutOfPenaltyBox(int roll) {
            if (isOdd(roll)) {
                isGettingOutOfPenaltyBox = true;

                Console.WriteLine(players[currentPlayer] + " is getting out of the penalty box");
                MakeNormalMove(roll, isGettingOutOfPenaltyBox);
            } else {
                Console.WriteLine(players[currentPlayer] + " is not getting out of the penalty box");
                isGettingOutOfPenaltyBox = false;
            }
        }

        private static bool isOdd(int roll) {
            return roll % 2 != 0;
        }

        private void askQuestion() {
            Console.WriteLine("The category is " + currentCategory());
            if (currentCategory() == "Pop") {
                Console.WriteLine(popQuestions.First());
                popQuestions.RemoveFirst();
            }
            if (currentCategory() == "Science") {
                Console.WriteLine(scienceQuestions.First());
                scienceQuestions.RemoveFirst();
            }
            if (currentCategory() == "Sports") {
                Console.WriteLine(sportsQuestions.First());
                sportsQuestions.RemoveFirst();
            }
            if (currentCategory() == "Rock") {
                Console.WriteLine(rockQuestions.First());
                rockQuestions.RemoveFirst();
            }
        }


        private String currentCategory() {
            if (places[currentPlayer] == 0)
                return "Pop";
            if (places[currentPlayer] == 4)
                return "Pop";
            if (places[currentPlayer] == 8)
                return "Pop";
            if (places[currentPlayer] == 1)
                return "Science";
            if (places[currentPlayer] == 5)
                return "Science";
            if (places[currentPlayer] == 9)
                return "Science";
            if (places[currentPlayer] == 2)
                return "Sports";
            if (places[currentPlayer] == 6)
                return "Sports";
            if (places[currentPlayer] == 10)
                return "Sports";
            return "Rock";
        }

        public bool wasCorrectlyAnswered() {
            if (inPenaltyBox[currentPlayer]) {
                if (isGettingOutOfPenaltyBox) {
                    Console.WriteLine("Answer was correct!!!!");
                    purses[currentPlayer]++;
                    Console.WriteLine(players[currentPlayer]
                            + " now has "
                            + purses[currentPlayer]
                            + " Gold Coins.");

                    bool winner = didPlayerWin();
                    currentPlayer++;
                    if (currentPlayer == players.Count)
                        currentPlayer = 0;

                    return winner;
                } else {
                    currentPlayer++;
                    if (currentPlayer == players.Count)
                        currentPlayer = 0;
                    return true;
                }



            } else {

                Console.WriteLine("Answer was corrent!!!!");
                purses[currentPlayer]++;
                Console.WriteLine(players[currentPlayer]
                        + " now has "
                        + purses[currentPlayer]
                        + " Gold Coins.");

                bool winner = didPlayerWin();
                currentPlayer++;
                if (currentPlayer == players.Count)
                    currentPlayer = 0;

                return winner;
            }
        }

        public bool wrongAnswer() {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(players[currentPlayer] + " was sent to the penalty box");
            inPenaltyBox[currentPlayer] = true;

            currentPlayer++;
            if (currentPlayer == players.Count)
                currentPlayer = 0;
            return true;
        }


        private bool didPlayerWin() {
            return !(purses[currentPlayer] == 6);
        }
    }

}