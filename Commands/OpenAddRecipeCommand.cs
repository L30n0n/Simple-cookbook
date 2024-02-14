using CookbookWPF.Stores;
using CookbookWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookbookWPF.Commands
{
    public class OpenAddRecipeCommand : CommandBase
    {
        private readonly RecipesStore _recipeStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddRecipeCommand(RecipesStore recipeStore, ModalNavigationStore modalNavigationStore)
        {
            _recipeStore = recipeStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            AddRecipeViewModel addRecipeViewModel = new AddRecipeViewModel(_recipeStore, _modalNavigationStore);

            _modalNavigationStore.CurrentViewModel = addRecipeViewModel;
        }
    }
}
