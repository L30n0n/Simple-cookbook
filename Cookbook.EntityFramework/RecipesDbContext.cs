using Cookbook.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.EntityFramework
{
    public class RecipesDbContext : DbContext
    {
        public RecipesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RecipeDTO> Recipes { get; set; }
    }
}
