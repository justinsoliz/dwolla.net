using System;

namespace Dwolla.Services
{
    public class RegisterOptions
    {
        /// <summary>
        /// Consumer key for the application
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Consumer secret for the application
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// 
        /// Email address for the new Dwolla account
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password for the new Dwolla account with at least 8 characters containing 
        /// at least 1 upper case letter, at least 1 lower case letter, and at least 
        /// 1 number
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Pin for the new Dwolla account
        /// </summary>
        public string Pin { get; set; }

        /// <summary>
        /// First name of the user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Line one of user address. Precise data & proper formatting critical to users' 
        /// geo-location data
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Line two of user address. Precise data & proper formatting critical to user's 
        /// geo-location data
        /// </summary>
        public string Address2 { get; set; }

        public string City { get; set; }

        /// <summary>
        /// USA state or territory two character code
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Postal code or zip code
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// Primary phone number of the user
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Date of birth of the user
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Account type of the new user. Defaults to 'Personal'. Options are Personal, 
        /// Commerical, and NonProfit.
        /// </summary>
        public string AccountType { get; set; }

        /// <summary>
        /// Company name for a commercial or non-profit account
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// Federal employer identification number, commercial or non-profit accounts
        /// </summary>
        public string Ein { get; set; }

        /// <summary>
        /// Applications must present the new user the Dwolla terms of service and 
        /// present a way for the user to accept the terms
        /// </summary>
        public bool AcceptTerms { get; set; }
    }
}
