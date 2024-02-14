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
    public class OpenEditRecipeCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly RecipesListingItemViewModel _recipesListingItemViewModel;
        private readonly RecipesStore _recipeStore;

        public OpenEditRecipeCommand(RecipesListingItemViewModel recipesListingItemViewModel, RecipesStore recipeStore, ModalNavigationStore modalNavigationStore)
        {
            _recipesListingItemViewModel = recipesListingItemViewModel;
            _recipeStore = recipeStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            Recipe _recipe = _recipesListingItemViewModel.Recipe;

            EditRecipeViewModel editRecipeViewModel = new EditRecipeViewModel(_recipe, _recipeStore , _modalNavigationStore);

            _modalNavigationStore.CurrentViewModel = editRecipeViewModel;
        }
    }
}
