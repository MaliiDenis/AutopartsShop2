using System.Collections.Generic;

namespace Motora.Domain.Models
{
    public sealed class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        // Навигационное свойство
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }

}