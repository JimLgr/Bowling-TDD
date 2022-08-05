using ClassLibraryBowling;

namespace ClassLibraryBowling
{
    public class Game
    {
        public int score;
        public int CurrentFrame { get; private set; } = 1;
        private bool isFrameFirstThrow = true;
        private Scorer scorer = new Scorer();
        public int Score
        {
            get { return scorer.ScoreForFrame(this.CurrentFrame); }
        }

        public Game()
        {

        }

        public void Add(int pins)
        {
            scorer.AddThrow(pins);
            AdjustCurrentFrame(pins);

        }


        private void AdjustCurrentFrame(int pins)
        {
            if (AdjustFrameForStrike(pins) || (!isFrameFirstThrow))
                AdvanceFrame();
            else
                isFrameFirstThrow = false;

        }


        private bool AdjustFrameForStrike(int pins)
        {
            if (pins == 10)
            {
                AdvanceFrame();
                return true;
            }
            return false;
        }

        private void AdvanceFrame()
        {
            CurrentFrame++;
            if (CurrentFrame > 10)
                CurrentFrame = 10;
        }
    }
}