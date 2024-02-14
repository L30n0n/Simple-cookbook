using CookbookWPF.Commands;
using Cookbook.Domain.Models;
using CookbookWPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookbookWPF.ViewModels
{
    public class RecipesListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<RecipesListingItemViewModel> _recipesListingItemViewModels;
        private readonly RecipesStore _recipeStore;
        private readonly SelectedRecipeStore _selectedRecipeStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public IEnumerable<RecipesListingItemViewModel> RecipesListingItemViewModels => _recipesListingItemViewModels;


        private RecipesListingItemViewModel _selectedRecipesListingItemViewModel;
        public RecipesListingItemViewModel SelectedRecipesListingItemViewModel
        {
            get
            {
                return _selectedRecipesListingItemViewModel;
            }
            set
            {
                _selectedRecipesListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedRecipesListingItemViewModel));

                _selectedRecipeStore.SelectedRecipe = _selectedRecipesListingItemViewModel?.Recipe;
            }
        }

        public ICommand LoadRecipesCommand { get; }

        public RecipesListingViewModel(RecipesStore recipeStore, SelectedRecipeStore selectedRecipeStore, ModalNavigationStore modalNavigationStore)
        {
            _recipeStore = recipeStore;
            _selectedRecipeStore = selectedRecipeStore;
            _modalNavigationStore = modalNavigationStore;
            _recipesListingItemViewModels = new ObservableCollection<RecipesListingItemViewModel>();


            _recipeStore.RecipesLoaded += RecipeStore_RecipesLoaded;
            _recipeStore.RecipeAdded += RecipesStore_RecipeAdded;
            _recipeStore.RecipeUpdated += _recipeStore_RecipeUpdated;
            _recipeStore.RecipeDeleted += _recipeStore_RecipeDeleted;
        }
        

        protected override void Dispose()
        {
            _recipeStore.RecipesLoaded -= RecipeStore_RecipesLoaded;
            _recipeStore.RecipeAdded -= RecipesStore_RecipeAdded;
            _recipeStore.RecipeUpdated -= _recipeStore_RecipeUpdated;
            _recipeStore.RecipeDeleted -= _recipeStore_RecipeDeleted;

            base.Dispose();
        }


        private void RecipeStore_RecipesLoaded()
        {
            _recipesListingItemViewModels.Clear();

            foreach (Recipe recipe in _recipeStore.Recipes)
            {
                AddRecipe(recipe);
            }
        }

        private void _recipeStore_RecipeUpdated(Recipe recipe)
        {
            RecipesListingItemViewModel recipeViewModel = _recipesListingItemViewModels.FirstOrDefault(r => r.Recipe.Id == recipe.Id);

            if(recipeViewModel != null)
            {
                recipeViewModel.Update(recipe);
            }
        }
        private void _recipeStore_RecipeDeleted(Guid id)
        {
            RecipesListingItemViewModel itemViewModel = _recipesListingItemViewModels.FirstOrDefault(r => r.Recipe.Id == id);

            if(itemViewModel != null)
            {
                _recipesListingItemViewModels.Remove(itemViewModel);
            }    
        }

        private void RecipesStore_RecipeAdded(Recipe recipe)
        {
            AddRecipe(recipe);
        }

        private void AddRecipe(Recipe recipe)
        {
            RecipesListingItemViewModel itemViewModel = new RecipesListingItemViewModel(recipe, _modalNavigationStore, _recipeStore);
            _recipesListingItemViewModels.Add(itemViewModel);
        }
    }
}
