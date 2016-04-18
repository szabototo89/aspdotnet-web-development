using System;
using System.Net.Sockets;

namespace GreetingsService.Models
{
    public class Person
    {
        public String Name { get; set; }

        public Address Address { get; set; }
    }
}