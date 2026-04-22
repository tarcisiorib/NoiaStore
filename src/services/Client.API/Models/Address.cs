using Core.DomainObjects;
using System;

namespace Clients.API.Models
{
    public class Address : Entity
    {
        public Address(string line1,
                       string line2,
                       string city,
                       string state,
                       string zipCode,
                       string country)
        {
            Line1 = line1;
            Line2 = line2;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
        }

        public string Line1 { get; private set; }
        public string Line2 { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }
        public Guid ClientId { get; private set; }

        public Client Client { get; private set; }
    }
}
