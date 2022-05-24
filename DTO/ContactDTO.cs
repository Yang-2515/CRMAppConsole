using System;

namespace CRMApplication.DTO
{
    public class ContactDTO
    {
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public void Show()
        {
            Console.WriteLine("Address " + Type + ":");
            Console.WriteLine("Address: " + Address);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("Phone " + Phone);
            Console.WriteLine("\n");
        }
    }
}
