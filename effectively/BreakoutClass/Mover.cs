using System;
using UglyTrivia;

namespace effectively.BreakoutClass {
    public class Mover {
        private Game mygame;
        public Mover(Game G) {
            this.mygame = G;
        }


        public void MakeNormalMove(int roll, int currentPlayer, bool isGettingOutOfPenaltyBox) {
            if (isGettingOutOfPenaltyBox)
                roll--;

            mygame.places[currentPlayer] = mygame.places[currentPlayer] + roll;
            if (mygame.places[currentPlayer] > 11)
                mygame.places[currentPlayer] = mygame.places[currentPlayer] - 12;

            Console.WriteLine(mygame.players[currentPlayer]
                    + "'s new location is "
                    + mygame.places[currentPlayer]);

        }
    }
}
