using Cookbook.Domain.Models;
using CookbookWPF.Stores;
using CookbookWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookbookWPF.Commands
{
    public class DeleteRecipeCommand : AsyncCommandBase
    {
        private readonly RecipesListingItemViewModel _recipesListingItemViewModel;
        private readonly RecipesStore _recipeStore;

        public DeleteRecipeCommand(RecipesListingItemViewModel recipesListingItemViewModel, RecipesStore recipeStore)
        {
            _recipesListingItemViewModel = recipesListingItemViewModel;
            _recipeStore = recipeStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Recipe _recipe = _recipesListingItemViewModel.Recipe;

            try
            {
                await _recipeStore.Delete(_recipe.Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
     }
}
