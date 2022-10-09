using System;

namespace src
{
    public class User
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public User()
        {
            firstName = $"Name_{new Random().Next(10000)}";
            lastName = $"Surname_{new Random().Next(10000)}";
            email = $"Email_{new Random().Next(10000)}@testemail.com";
            password = "password";
        }

    }
}