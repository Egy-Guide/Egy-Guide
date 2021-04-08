using HtmlAgilityPack;
using System;
using System.Linq;

namespace EgyGuide.Utility
{
    public static class SD
    {
        public const string Role_User_Admin = "Admin";
        public const string Role_User_Tourist = "Tourist";
        public const string Role_User_Tour_Guide = "Tour Guide";
        public const string Role_User_Suspended_Guide = "Suspended Guide";

        public static string StripHtml(string htmlDescription)
        {
            var mainDoc = new HtmlDocument();
            mainDoc.LoadHtml(htmlDescription);

            return mainDoc.DocumentNode.InnerText;
        }

        public static string SubstringByWords(string text, int wordsNumber)
        {
            string newString = string.Join(" ", text.Split(" ").Take(wordsNumber));
            return newString.TrimEnd('.');
        }
    }    
}
