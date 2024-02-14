using Cookbook.Domain.Models;
using Cookbook.Domain.Queries;
using Cookbook.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.EntityFramework.Queries
{
    public class GetAllRecipesQuery : IGetAllRecipesQuery
    {
        private readonly RecipesDbContextFactory _contextFactory;

        public GetAllRecipesQuery(RecipesDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Recipe>> Execute()
        {
            using(RecipesDbContext context = _contextFactory.Create())
            {
                IEnumerable<RecipeDTO> recipeDTOs = await context.Recipes.ToListAsync();

                return recipeDTOs.Select(r => new Recipe(r.Id, r.Dish, r.Description, r.Link));
            }
        }
    }
}
