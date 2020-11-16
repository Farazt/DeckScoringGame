using System.Collections.Generic;


namespace CardGame
{
    class CardTypeScoreRule : ICardTypeScore
    {
        public void ScoreAceRules(List<string> input, ref int iteration,ref int result)
        {
            bool isParsed = int.TryParse(input[iteration - 1], out int output);
            if (isParsed)
            {
                result = result - output;
                var stackCount = CountStack(input, iteration, "A");
                result += output * GetCount(stackCount);
                iteration += stackCount - 1;
            }
        }

        public void ScoreJackRules(List<string> input,ref int iteration, ref int result)
        {
            if (iteration == input.Count - 1)
            {
                result = 0;
            }
            input.RemoveAt(iteration);
            if (iteration != 0)
            {
                input.RemoveAt(iteration - 1);
            }
        }

        public void ScoreKingRules(List<string> input,ref int iteration, ref int result)
        {
            if (iteration + 1 == input.Count)
            {
                return;
            }

            if (input[iteration + 1].Equals("J"))
            {
                input.RemoveAt(iteration);
                input.RemoveAt(iteration);
                iteration = iteration - 1;
            }
            else { 
                int response = input.IndexOf("K", iteration + 1);
                if (response != -1)
                {
                    input.RemoveRange(iteration, response);
                    iteration = iteration - 1;
                }
            }
        }

        public void ScoreQueenRules(List<string> input,ref int iteration, ref int result)
        {
            if (!(iteration + 1 == input.Count) && !input[iteration + 1].Equals("A"))
            {
                var stackCount = CountStack(input, iteration, "Q");
                result += stackCount;
                iteration += stackCount - 1;
            }
        }

        private int CountStack(List<string> list, int index, string cardName)
        {
            int count = 0;
            for (int i = index; i < list.Count; i++)
            {
                if (!list[i].Equals(cardName))
                {
                    break;
                }
                count++;
            }
            return count;
        }

        private int GetCount(int stackCount)
        {
            int multiple = 1;
            for (int i = 0; i < stackCount; i++)
            {
                multiple = multiple * 2;
            }
            return multiple;

        }
    }
}
