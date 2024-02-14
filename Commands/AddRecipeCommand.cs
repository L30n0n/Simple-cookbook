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
    public class AddRecipeCommand : AsyncCommandBase
    {
        private readonly AddRecipeViewModel addRecipeViewModel;
        private readonly RecipesStore _recipeStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public AddRecipeCommand(ViewModels.AddRecipeViewModel addRecipeViewModel, RecipesStore recipeStore, ModalNavigationStore modalNavigationStore)
        {
            this.addRecipeViewModel = addRecipeViewModel;
            _recipeStore = recipeStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            RecipeDetailsFormViewModel formViewModel = addRecipeViewModel.RecipeDetailsFormViewModel;

            formViewModel.IsSubmitting = true;

            Recipe recipe = new Recipe(Guid.NewGuid() , formViewModel.Dish, formViewModel.Description, formViewModel.Link);
            try
            {
                await _recipeStore.Add(recipe);
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
