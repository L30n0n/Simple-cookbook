using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.Models
{
    public class Recipe
    {
        public Guid Id { get; } 
        public string Dish { get; }
        public string Description { get; }
        public string Link { get; }

        public Recipe(Guid id, string dish, string description, string link)
        {
            Id = id;
            Dish = dish;
            Description = description;
            Link = link;
        }
    }
}
