using HtmlAgilityPack;
using System;
using System.Linq;

namespace EgyGuide.Utility
{
    public static class SD
    {
        public const string Role_Admin = "Admin";
        public const string Role_Tourist = "Tourist";
        public const string Role_TourGuide = "Tour Guide";
        public static string SubstringByWords(string text, int wordsNumber)
        {
            string newString = String.Join(" ", text.Split(" ").Take(wordsNumber));
            return newString.TrimEnd('.');
        }
        public static string StripHtml(string htmlDescription)
        {
            var mainDoc = new HtmlDocument();
            mainDoc.LoadHtml(htmlDescription);

            return mainDoc.DocumentNode.InnerText;
        }


    }
    
}
