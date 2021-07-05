using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EgyGuide.Utility
{
    public static class SD
    {
        public const string Role_User_Admin = "Admin";
        public const string Role_User_Tourist = "Tourist";
        public const string Role_User_Tour_Guide = "Tour Guide";
        public const string Role_User_Suspended_Guide = "Suspended Guide";

        // Guide Status
        public const string GuideStatusApproved = "Approved";
        public const string GuideStatusPending = "Pending";
        public const string GuideStatusLocked = "Locked";

        // Booking Status
        public const string BookingStatusPending = "Pending";
        public const string BookingStatusConfirmation = "Confirmation";
        public const string BookingStatusCompleted = "Completed";
        public const string BookingStatusCancelled = "Cancelled";

        // Payment Status
        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusRejected = "Rejected";
        public const string PaymentStatusRefunded = "Refunded";

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

        // Generete Unique BookingId
        public static string GenBookingNo(List<string> ReservedBookingIds)
        {
            var rand = new Random();
            int randId = rand.Next(1, 10000);
            string bookingNo = "EGYGUIDE-BK" + randId.ToString();

            while (ReservedBookingIds.Contains(bookingNo))
            {
                randId = rand.Next(1, 10000);
                bookingNo = "EGYGUIDE-BK" + randId.ToString();
            }

            return bookingNo;
        }
        
}    
}
