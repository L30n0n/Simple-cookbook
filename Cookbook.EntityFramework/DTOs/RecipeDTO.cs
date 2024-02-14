using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.EntityFramework.DTOs
{
    public class RecipeDTO
    {
        public Guid Id { get; set; }
        public string Dish { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}
