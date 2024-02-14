using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.EntityFramework
{
    public class RecipesDesignTimeDbContextFactory : IDesignTimeDbContextFactory<RecipesDbContext>
    {

        public RecipesDbContext CreateDbContext(string[] args = null)
        {
            return new RecipesDbContext(new DbContextOptionsBuilder().UseSqlite("Data Source=Recipes.db").Options);
        }
    }
}
