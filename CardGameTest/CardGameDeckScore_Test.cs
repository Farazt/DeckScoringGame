using CardGame;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGameTest
{
    public class CardGameTest
    {

        private CardGameGenerator cardgameGenerator;

        [SetUp]
        public void Setup() {

            cardgameGenerator = new CardGameGenerator();
        }

        [TearDown]
        public void TearDown() {
            cardgameGenerator = null;
        }

        [Test]
        public void When_DeckCards_Null_ThrowsArgumentNullException() {
            Assert.Throws<ArgumentNullException>(() => cardgameGenerator.ScoreDeck(null));
        }

        [Test]
        [TestCase("1,2,5,8")]
        [TestCase("9,A,3,Q,Q,2,25")]
        [TestCase("K,3,5,J,A,Q,8,K,0")]
        [TestCase("2,A,A,A,16")]
        [TestCase("4,K,3,K,5,K,Q,9")]
        [TestCase("2,K,3,K,A,4,8")]
        [TestCase("2,A,A,A,J,0")]
        [TestCase("K,J,3,K,3")]
        public void When_DeckScored_ReturnCorrectScore(string Cards)
        {
            //arrange
            List<string> cards = Cards.Split(',').Select(s => s).ToList();
            int actual = int.Parse(cards[cards.Count - 1]);
            cards.RemoveAt(cards.Count - 1);
            //act
            var output = cardgameGenerator.ScoreDeck(cards);
            //assert
            Assert.AreEqual(actual,output);
        }
    }
}