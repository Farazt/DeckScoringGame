using System.Collections.Generic;


namespace CardGame
{
    public interface ICardTypeScore
    {
        void ScoreAceRules(List<string> list, ref int iterator,ref int result);
        void ScoreQueenRules(List<string> list,ref int iterator, ref int result);
        void ScoreKingRules(List<string> list, ref int iterator, ref int result);
        void ScoreJackRules(List<string> list, ref int iterator, ref int result);
    }
}
