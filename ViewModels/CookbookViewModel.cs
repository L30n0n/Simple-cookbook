using CookbookWPF.Commands;
using CookbookWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookbookWPF.ViewModels
{
    public class CookbookViewModel : ViewModelBase
    {
        public RecipesListingViewModel RecipesListingViewModel { get; }
        public RecipesDetailsViewModel RecipesDetailsViewModel { get; }

        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public ICommand AddRecipesCommand { get; }
        public ICommand LoadRecipesCommand { get; }

        public CookbookViewModel(RecipesStore recipeStore, SelectedRecipeStore selectedRecipeStore, ModalNavigationStore modalNavigationStore)
        {
            RecipesListingViewModel = new RecipesListingViewModel(recipeStore, selectedRecipeStore, modalNavigationStore);
            RecipesDetailsViewModel = new RecipesDetailsViewModel(selectedRecipeStore);

            LoadRecipesCommand = new LoadRecipeCommand(this, recipeStore);

            AddRecipesCommand = new OpenAddRecipeCommand(recipeStore, modalNavigationStore);
        }

        public static CookbookViewModel LoadViewModel(RecipesStore recipeStore, SelectedRecipeStore selectedRecipeStore, ModalNavigationStore modalNavigationStore)
        {
            CookbookViewModel viewModel = new CookbookViewModel(recipeStore, selectedRecipeStore, modalNavigationStore);

            viewModel.LoadRecipesCommand.Execute(null);

            return viewModel;
        }
    }
}
