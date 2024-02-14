using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.EntityFramework
{
    public class RecipesDbContextFactory
    {
        private readonly DbContextOptions _options;

        public RecipesDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public RecipesDbContext Create()
        {
            return new RecipesDbContext(_options);
        }
    }
}
