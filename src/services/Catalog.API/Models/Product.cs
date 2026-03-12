using Core.DomainObjects;
using System;

namespace Catalog.API.Models
{
    public class Product : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public decimal Price { get; set; }
        public DateTime Registration { get; set; }
        public string Image { get; set; }
        public int StockQuantity { get; set; }
    }
}
