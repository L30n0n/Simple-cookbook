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
    public class DeleteRecipeCommand : IDeleteRecipeCommand
    {
        private readonly RecipesDbContextFactory _contextFactory;

        public DeleteRecipeCommand(RecipesDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Guid id)
        {
            using (RecipesDbContext context = _contextFactory.Create())
            {
                RecipeDTO recipeDTO = new RecipeDTO()
                {
                    Id = id,
                };

                context.Recipes.Remove(recipeDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
