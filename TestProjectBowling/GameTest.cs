using ClassLibraryBowling;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryBowling;
namespace TestProjectBowling
{
    [TestClass]
    public class GameTest
    {
        Game game;
        Scorer scorer;
        [TestInitialize]
        public void Initialize()
        {
            game = new Game();
            scorer = new Scorer();
            
        }
        //[TestMethod]
        //public void TestOneThrow()
        //{

        //    game.Add(5);
        //    Assert.AreEqual(5, game.Score);
        //    Assert.AreEqual(1, game.CurrentFrame);
        //}

        [TestMethod]
        public void TestTwoThrowsNoMark()
        {

            game.Add(5);
            game.Add(4);
            Assert.AreEqual(9, game.Score);
            Assert.AreEqual(2, game.CurrentFrame);
        }

        [TestMethod]
        public void TestFourThrowsNoMark()
        {
            //Arrangement

            game.Add(5);
            game.Add(4);
            game.Add(7);
            game.Add(2);
            //Action
            int scoreFrame1 = scorer.ScoreForFrame(1);
            int scoreFrame2 = scorer.ScoreForFrame(2);
            //Affirmation
            Assert.AreEqual(18, game.Score);
            Assert.AreEqual(9, scoreFrame1);
            Assert.AreEqual(18, scoreFrame2);
            Assert.AreEqual(3, game.CurrentFrame);
        }

        [TestMethod]
        public void TestSimpleSpare()
        {
            game.Add(3);
            game.Add(7);
            game.Add(3);
            Assert.AreEqual(13, scorer.ScoreForFrame(1));
            Assert.AreEqual(2, game.CurrentFrame);
        }

        [TestMethod]
        public void TestSimpleFrameAfterSpare()
        {
            game.Add(3);
            game.Add(7);
            game.Add(3);
            game.Add(2);
            Assert.AreEqual(13, scorer.ScoreForFrame(1));
            Assert.AreEqual(18, scorer.ScoreForFrame(2));
            Assert.AreEqual(18, game.Score);
            Assert.AreEqual(3, game.CurrentFrame);

        }

        [TestMethod]
        public void TestSimpleStrike()
        {
            game.Add(10);
            game.Add(3);
            game.Add(6);
            Assert.AreEqual(19, scorer.ScoreForFrame(1));
            Assert.AreEqual(28, game.Score);
            Assert.AreEqual(3, game.CurrentFrame);
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            for (int i = 0; i < 12; i++)
            {
                game.Add(10);
            }
            Assert.AreEqual(300, game.Score);
            Assert.AreEqual(10, game.CurrentFrame);
        }

        [TestMethod]
        
        public void TestEndOfArray()
        {
            for (int i = 0; i < 9; i++)
            {
                game.Add(0);
                game.Add(0);
            }
            game.Add(2);
            game.Add(8); // 10th frame spare
            game.Add(10); // Strike in last position of array.
            Assert.AreEqual(20, game.Score);
        }

        [TestMethod]
        public void TestSampleGame()
        {
            game.Add(1);
            game.Add(4);
            game.Add(4);
            game.Add(5);
            game.Add(6);
            game.Add(4);
            game.Add(5);
            game.Add(5);
            game.Add(10);
            game.Add(0);
            game.Add(1);
            game.Add(7);
            game.Add(3);
            game.Add(6);
            game.Add(4);
            game.Add(10);
            game.Add(2);
            game.Add(8);
            game.Add(6);
            Assert.AreEqual(133, game.Score);
        }

        [TestMethod]
        public void TestHeartBreak()
        {
            for (int i = 0; i < 11; i++)
                game.Add(10);
            game.Add(9);
            Assert.AreEqual(299, game.Score);
        }

        [TestMethod]
        public void TestTenthFrameSpare()
        {
            for (int i = 0; i < 9; i++)
                game.Add(10);
            game.Add(9);
            game.Add(1);
            game.Add(1);
            Assert.AreEqual(270, game.Score);
        }



    }
}
