using Cookbook.Domain.Commands;
using Cookbook.Domain.Models;
using Cookbook.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.EntityFramework.Commands
{
    public class UpdateRecipeCommand : IUpdateRecipeCommand
    {
        private readonly RecipesDbContextFactory _contextFactory;

        public UpdateRecipeCommand(RecipesDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Recipe recipe)
        {
            using (RecipesDbContext context = _contextFactory.Create())
            {
                RecipeDTO recipeDTO = new RecipeDTO()
                {
                    Id = recipe.Id,
                    Dish = recipe.Dish,
                    Description = recipe.Description,
                    Link = recipe.Link
                };

                context.Recipes.Update(recipeDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
