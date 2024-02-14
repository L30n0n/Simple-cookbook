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
    public class EditRecipeCommand : AsyncCommandBase
    {
        private readonly EditRecipeViewModel _editRecipeViewModel;
        private readonly RecipesStore _recipeStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public EditRecipeCommand(EditRecipeViewModel editRecipeViewModel, RecipesStore recipeStore, ModalNavigationStore modalNavigationStore)
        {
            _editRecipeViewModel = editRecipeViewModel;
            _recipeStore = recipeStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            RecipeDetailsFormViewModel formViewModel = _editRecipeViewModel.RecipeDetailsFormViewModel;

            formViewModel.IsSubmitting = true;

            Recipe recipe = new Recipe(_editRecipeViewModel.RecipeId, formViewModel.Dish, formViewModel.Description, formViewModel.Link);

            try
            {
                await _recipeStore.Update(recipe);
                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                formViewModel.IsSubmitting = false;
            }
        }
    }
}
