using Cookbook.Domain.Commands;
using Cookbook.Domain.Models;
using Cookbook.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CookbookWPF.Stores
{
    public class RecipesStore
    {
        private readonly IGetAllRecipesQuery _getAllRecipesQuery;
        private readonly ICreateRecipeCommand _createRecipeCommand;
        private readonly IUpdateRecipeCommand _updateRecipeCommand;
        private readonly IDeleteRecipeCommand _deleteRecipeCommand;
        
        private readonly List<Recipe> _recipes;

        public IEnumerable<Recipe> Recipes => _recipes;

        public event Action RecipesLoaded;
        public event Action<Recipe> RecipeAdded;
        public event Action<Recipe> RecipeUpdated;
        public event Action<Guid> RecipeDeleted;

        public RecipesStore(IGetAllRecipesQuery getAllRecipesQuery, ICreateRecipeCommand createRecipeCommand, IUpdateRecipeCommand updateRecipeCommand, IDeleteRecipeCommand deleteRecipeCommand)
        {
            _getAllRecipesQuery = getAllRecipesQuery;
            _createRecipeCommand = createRecipeCommand;
            _updateRecipeCommand = updateRecipeCommand;
            _deleteRecipeCommand = deleteRecipeCommand;

            _recipes = new List<Recipe>();
        }



        public async Task Load()
        {
            IEnumerable<Recipe> recipe = await _getAllRecipesQuery.Execute();

            _recipes.Clear();
            _recipes.AddRange(recipe);

            RecipesLoaded?.Invoke();
        }

        public async Task Add(Recipe recipe)
        {
            await _createRecipeCommand.Execute(recipe);

            _recipes.Add(recipe);

            RecipeAdded?.Invoke(recipe);
        }

        public async Task Update(Recipe recipe)
        {
            await _updateRecipeCommand.Execute(recipe);

            int currentIndex = _recipes.FindIndex(r => r.Id == recipe.Id);

            if(currentIndex != -1)
            {
                _recipes[currentIndex] = recipe;
            }
            else
            {
                _recipes.Add(recipe);
            }
            RecipeUpdated?.Invoke(recipe);
        }

        public async Task Delete(Guid id)
        {
            await _deleteRecipeCommand.Execute(id);

            _recipes.RemoveAll(r => r.Id == id);

            RecipeDeleted?.Invoke(id);
        }
    }
}
