using System;
using System.Collections.Generic;


namespace CardGame
{
    public class CardGameGenerator
    {
        private ICardTypeScore _cardTypeScore;

        public CardGameGenerator() {

            _cardTypeScore = new CardTypeScoreRule();
        }
        public int ScoreDeck(List<string> input)
        {
            if (input == null) {
                throw new ArgumentNullException("Deck of cards is null");
            }

            int result = 0;
            int iteration = 0;
            while (iteration < input.Count)
            {
                switch (input[iteration])
                {

                    case "A":
                        _cardTypeScore.ScoreAceRules(input, ref iteration,ref result);
                        break;
                    case "J":
                        _cardTypeScore.ScoreJackRules(input, ref iteration,ref result);
                        break;
                    case "Q":
                        _cardTypeScore.ScoreQueenRules(input,ref iteration,ref result);
                        break;
                    case "K":
                        _cardTypeScore.ScoreKingRules(input,ref iteration,ref result);
                        break;
                    default:
                        bool isParseAble = int.TryParse(input[iteration], out int res);
                        if (isParseAble)
                        {
                            result += res;
                        }

                        break;

                }
                iteration++;
            }
            return result;
        }
    }
}

