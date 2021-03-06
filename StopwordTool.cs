﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Detecting_Similarities
{
    static class StopwordTool
    {
        static Dictionary<string, bool> _stops = new Dictionary<string, bool>
        {
            { "a", true },
            { "about", true },
            { "above", true },
            { "across", true },
            { "after", true },
            { "afterwards", true },
            { "again", true },
            { "against", true },
            { "all", true },
            { "almost", true },
            { "alone", true },
            { "along", true },
            { "already", true },
            { "also", true },
            { "although", true },
            { "always", true },
            { "am", true },
            { "amn't", true },
            { "amnt", true },
            { "among", true },
            { "amongst", true },
            { "amoungst", true },
            { "amount", true },
            { "an", true },
            { "and", true },
            { "another", true },
            { "any", true },
            { "anyhow", true },
            { "anyone", true },
            { "anything", true },
            { "anyway", true },
            { "anywhere", true },
            { "are", true },
            { "aren't", true },
            { "arent", true },
            { "around", true },
            { "as", true },
            { "at", true },
            { "back", true },
            { "be", true },
            { "became", true },
            { "because", true },
            { "become", true },
            { "becomes", true },
            { "becoming", true },
            { "been", true },
            { "before", true },
            { "beforehand", true },
            { "behind", true },
            { "being", true },
            { "below", true },
            { "beside", true },
            { "besides", true },
            { "between", true },
            { "beyond", true },
            { "bill", true },
            { "both", true },
            { "bottom", true },
            { "but", true },
            { "by", true },
            { "call", true },
            { "can", true },
            { "cannot", true },
            { "cant", true },
            { "can't", true },
            { "cann't", true },
            { "co", true },
            { "computer", true },
            { "con", true },
            { "could", true },
            { "couldnt", true },
            { "couldn't", true },
            { "cry", true },
            { "de", true },
            { "describe", true },
            { "detail", true },
            { "do", true },
            { "don't", true },
            { "dont", true },
            { "does", true },
            { "doesn't", true },
            { "did", true },
            { "didn't", true },
            { "done", true },
            { "down", true },
            { "due", true },
            { "during", true },
            { "each", true },
            { "eg", true },
            { "eg.", true },
            { "e.g.", true },
            { "eight", true },
            { "either", true },
            { "eleven", true },
            { "else", true },
            { "elsewhere", true },
            { "empty", true },
            { "enough", true },
            { "etc", true },
            { "etc.", true },
            { "even", true },
            { "ever", true },
            { "every", true },
            { "everyone", true },
            { "everything", true },
            { "everywhere", true },
            { "except", true },
            { "few", true },
            { "fifteen", true },
            { "fify", true },
            { "fill", true },
            { "find", true },
            { "fire", true },
            { "first", true },
            { "five", true },
            { "for", true },
            { "former", true },
            { "formerly", true },
            { "forty", true },
            { "found", true },
            { "four", true },
            { "from", true },
            { "front", true },
            { "full", true },
            { "further", true },
            { "get", true },
            { "give", true },
            { "go", true },
            { "had", true },
            { "hadn't", true },
            { "hadnt", true },
            { "has", true },
            { "hasnt", true },
            { "hasn't", true },
            { "have", true },
            { "haven't", true },
            { "havent", true },
            { "he", true },
            { "he's", true },
            { "hence", true },
            { "her", true },
            { "here", true },
            { "hereafter", true },
            { "hereby", true },
            { "herein", true },
            { "hereupon", true },
            { "hers", true },
            { "herself", true },
            { "him", true },
            { "himself", true },
            { "his", true },
            { "how", true },
            { "however", true },
            { "hundred", true },
            { "i", true },
            { "i'm", true },
            { "ie", true },
            { "i.e.", true },
            { "ie.", true },
            { "if", true },
            { "in", true },
            { "inc", true },
            { "indeed", true },
            { "interest", true },
            { "into", true },
            { "is", true },
            { "isn't", true },
            { "isnt", true },
            { "it", true },
            { "its", true },
            { "it's", true },
            { "it'd", true },
            { "it'll", true },
            { "itself", true },
            { "keep", true },
            { "last", true },
            { "latter", true },
            { "latterly", true },
            { "least", true },
            { "less", true },
            { "ltd", true },
            { "ltd.", true },
            { "made", true },
            { "many", true },
            { "may", true },
            { "me", true },
            { "meanwhile", true },
            { "might", true },
            { "mill", true },
            { "mine", true },
            { "more", true },
            { "moreover", true },
            { "most", true },
            { "mostly", true },
            { "move", true },
            { "much", true },
            { "must", true },
            { "my", true },
            { "myself", true },
            { "name", true },
            { "namely", true },
            { "neither", true },
            { "never", true },
            { "nevertheless", true },
            { "next", true },
            { "nine", true },
            { "no", true },
            { "nobody", true },
            { "none", true },
            { "noone", true },
            { "nor", true },
            { "not", true },
            { "n't", true },
            { "nothing", true },
            { "now", true },
            { "nowhere", true },
            { "of", true },
            { "off", true },
            { "often", true },
            { "on", true },
            { "once", true },
            { "one", true },
            { "only", true },
            { "onto", true },
            { "or", true },
            { "other", true },
            { "others", true },
            { "other's", true },
            { "otherwise", true },
            { "our", true },
            { "ours", true },
            { "our's", true },
            { "ourselves", true },
            { "out", true },
            { "over", true },
            { "own", true },
            { "part", true },
            { "per", true },
            { "perhaps", true },
            { "please", true },
            { "put", true },
            { "rather", true },
            { "re", true },
            { "re.", true },
            { "same", true },
            { "see", true },
            { "seem", true },
            { "seemed", true },
            { "seeming", true },
            { "seems", true },
            { "serious", true },
            { "several", true },
            { "she", true },
            { "should", true },
            { "show", true },
            { "side", true },
            { "since", true },
            { "sincere", true },
            { "six", true },
            { "sixty", true },
            { "so", true },
            { "some", true },
            { "somehow", true },
            { "someone", true },
            { "something", true },
            { "sometime", true },
            { "sometimes", true },
            { "somewhere", true },
            { "still", true },
            { "such", true },
            { "system", true },
            { "take", true },
            { "ten", true },
            { "than", true },
            { "that", true },
            { "that's", true },
            { "the", true },
            { "their", true },
            { "theirs", true },
            { "their's", true },
            { "them", true },
            { "themselves", true },
            { "then", true },
            { "thence", true },
            { "there", true },
            { "thereafter", true },
            { "thereby", true },
            { "therefore", true },
            { "therein", true },
            { "thereupon", true },
            { "these", true },
            { "they", true },
            { "they're", true },
            { "they'll", true },
            { "they've", true },
            { "they'd", true },
            { "thick", true },
            { "thin", true },
            { "third", true },
            { "this", true },
            { "those", true },
            { "though", true },
            { "three", true },
            { "through", true },
            { "throughout", true },
            { "thru", true },
            { "thus", true },
            { "to", true },
            { "together", true },
            { "too", true },
            { "top", true },
            { "toward", true },
            { "towards", true },
            { "twelve", true },
            { "twenty", true },
            { "two", true },
            { "un", true },
            { "under", true },
            { "until", true },
            { "up", true },
            { "upon", true },
            { "us", true },
            { "very", true },
            { "via", true },
            { "was", true },
            { "we", true },
            { "well", true },
            { "were", true },
            { "what", true },
            { "whatever", true },
            { "when", true },
            { "whence", true },
            { "whenever", true },
            { "where", true },
            { "whereafter", true },
            { "whereas", true },
            { "whereby", true },
            { "wherein", true },
            { "whereupon", true },
            { "wherever", true },
            { "whether", true },
            { "which", true },
            { "while", true },
            { "whither", true },
            { "who", true },
            { "whoever", true },
            { "whole", true },
            { "whom", true },
            { "whose", true },
            { "why", true },
            { "will", true },
            { "won't", true },
            { "with", true },
            { "within", true },
            { "without", true },
            { "would", true },
            { "yet", true },
            { "you", true },
            { "you'll", true },
            { "you're", true },
            { "you'd", true },
            { "your", true },
            { "yours", true },
            { "your's", true },
            { "yourself", true },
            { "yourselves", true }
        };

        static char[] _delimiters = new char[]
        {
            ' ',
            ',',
            ';',
            '.',
            '?',
            '-',
            '[',
            ']',
            '(',
            ')',
            '@',
            '#',
            '/',
            '%',
            '&', 
            '+',
            '_',
            '$',
            ':',
            '"',
            '=',
            '<',
            '>'
        };

        public static string RemoveStopwords(string input)
        {
            var words = input.Split(_delimiters, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder builder = new StringBuilder();

            foreach (string currentWord in words)
            {
                string lowerWord = currentWord.ToLower();
                if (!_stops.ContainsKey(lowerWord))
                {
                    builder.Append(currentWord).Append(' ');
                }
            }
            return builder.ToString().Trim();
        }
    }
}
