using System;

namespace effectively
{
    public class PlayerMover
    {
        public PlayerMover(int currentPlace, int roll, bool isInPentalyBox)
        {
            CurrentPlace = currentPlace;
            Roll = roll;
            IsInPenaltyBox = isInPentalyBox;
        }

        public int CurrentPlace { get; }
        public int Roll { get; }
        public bool IsInPenaltyBox { get; }

        public int GetNextPlace()
        {
            int nextPlace = CurrentPlace + Roll;
            if (nextPlace > 11) nextPlace = nextPlace - 12;
            return nextPlace;
        }
    }
}
