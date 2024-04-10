﻿using System.Collections.Generic;

namespace Motora.Domain.Models
{
    public sealed class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        // Навигационное свойство
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }

}