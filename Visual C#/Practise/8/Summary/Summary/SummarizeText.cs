using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summary
{
    public class SummarizeText
    {
        public static string Summarize(string sentence, int maxLength = 20)
        {
            var wordArr = sentence.Split(' ');
            var wordList = new List<string>();
            if (sentence.Length < maxLength) return sentence;
            for (int i = 0; i < wordArr.Length; i++)
            {
                wordList.Add(wordArr[i]);
                var summarizedText = String.Join(' ', wordList);
                if (summarizedText.Length < maxLength)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            var summary = String.Join(' ', wordList);
            return "Your Summarized Text : " + summary + "..." + "With Length : " + summary.Length;
        }

    }
}
