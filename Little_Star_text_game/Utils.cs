using System;
using System.Collections.Generic;

namespace Little_Star_text_game
{
    public static class Utils
    {
        public static string RemoveArticles(string input)
        {
            List<string> articles = new List<string> { "a", "an", "the" };
            List<string> words = new List<string>(input.Split(' '));
            words.RemoveAll(word => articles.Contains(word));
            return string.Join(" ", words);
        }
    }
}
