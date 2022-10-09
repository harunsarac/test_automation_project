using System;
using System.Linq;

namespace UI.Test.Helpers
{
    public static class StringHelpers
    {

        /// <summary>
        /// Generates a random string of the desired length
        /// </summary>
        /// <param name="length"></param>
        public static string GenerateRandomString(int length = 10)
        {
            var random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        ///  Generates a random string of digits with the desired length
        /// </summary>
        /// <param name="numberOfDigits"></param>
        /// <returns></returns>
        public static string GenerateRandomNumber(int numberOfDigits = 10)
        {
            var random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, numberOfDigits)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Generates a random email
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomEmail()
        {
            var email = GenerateRandomString(15) + "@test.com";
            return email;
        }

    }
}
