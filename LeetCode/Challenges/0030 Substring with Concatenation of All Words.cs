using System.Data.SqlTypes;

namespace LeetCode.Challenges.SubstringWithConcatenationOfAllWords0030;

public class Solution
{
    public IList<int> FindSubstring(string s, string[] words)
    {
        var indices = new List<int>();
        int wordLength = words[0].Length;
        int totalWords = words.Length;
        int concatLength = wordLength * totalWords;
        int lastIndex = s.Length - concatLength;

        var wordCount = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (!wordCount.ContainsKey(word)) wordCount[word] = 0;
            wordCount[word]++;
        }

        for (int i = 0; i <= lastIndex; i++)
        {
            var seenWords = new Dictionary<string, int>();

            int concatWords = 0;

            while (concatWords < totalWords)
            {
                string currentWord = s.Substring(i + concatWords * wordLength, wordLength);

                if (!wordCount.ContainsKey(currentWord)) break;

                if (!seenWords.TryGetValue(currentWord, out int seenWordCount)
                    || seenWordCount < wordCount[currentWord])
                {
                    if (!seenWords.ContainsKey(currentWord)) seenWords[currentWord] = 0;
                    seenWords[currentWord]++;
                    concatWords++;
                }
                else
                {
                    break;
                }
            }

            if (concatWords == totalWords)
            {
                indices.Add(i);
            }
        }

        return indices;
    }
}

public static class SubstringWithConcatenationOfAllWords0030
{
    private static List<string> Inputs = new List<string>() 
    {
        "thethethethe",
        "ababababab",
        "wordgoodgoodgoodbestword",
        "barfoothefoobarman",
        "wordgoodgoodgoodbestword",
        "barfoofoobarthefoobarman"
    };
    private static List<string[]> Words = new List<string[]>()
    {
        new string[] { "foo","foo","the","man" },
        new string[] { "ababa","babab" },
        new string[] { "word","good","best","good" },
        new string[] { "foo", "bar" },
        new string[] { "word","good","best","word" },
        new string[] { "bar","foo","the" },
    };
    private static List<List<int>> ExpectedOutputs= new List<List<int>>()
    {
        new List<int>{},
        new List<int>{0},
        new List<int>{8},
        new List<int>{0,9},
        new List<int>{},
        new List<int>{6,9,12},
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var words = Words[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.FindSubstring(input, words);
            Console.WriteLine($"Input: {input}, Words: {string.Join(',', words)}, Expected Output: {string.Join(',', expectedOutput)}, Actual Output: {string.Join(',', actualOutput)}");
        }
    }
}