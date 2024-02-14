using CookbookWPF.Commands;
using Cookbook.Domain.Models;
using CookbookWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookbookWPF.ViewModels
{
    public class EditRecipeViewModel : ViewModelBase
    {
        public Guid RecipeId { get; }
        
        public RecipeDetailsFormViewModel RecipeDetailsFormViewModel { get; }

        public EditRecipeViewModel(Recipe recipe, RecipesStore _recipeStore, ModalNavigationStore modalNavigationStore)
        {
            RecipeId = recipe.Id;

            ICommand submitCommand = new EditRecipeCommand(this, _recipeStore , modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            RecipeDetailsFormViewModel = new RecipeDetailsFormViewModel(submitCommand, cancelCommand)
            {
                Dish = recipe.Dish,
                Description = recipe.Description,
                Link = recipe.Link
            };
        }

    }
}
