using CookbookWPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookbookWPF.ViewModels
{
    public class AddRecipeViewModel : ViewModelBase
    {
        public RecipeDetailsFormViewModel RecipeDetailsFormViewModel { get; }

        public AddRecipeViewModel(Stores.RecipesStore recipeStore, Stores.ModalNavigationStore modalNavigationStore)
        {
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            ICommand submitCommand = new AddRecipeCommand(this, recipeStore, modalNavigationStore);
            RecipeDetailsFormViewModel = new RecipeDetailsFormViewModel(submitCommand, cancelCommand);
        }
    }
}
