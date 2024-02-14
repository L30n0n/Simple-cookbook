using Cookbook.Domain.Models;
using CookbookWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookbookWPF.ViewModels
{
    public class RecipesDetailsViewModel : ViewModelBase
    {
        private readonly SelectedRecipeStore _selectedRecipeStore;

        private Recipe SelectedRecipe => _selectedRecipeStore.SelectedRecipe;

        public bool HasSelectedRecipe => SelectedRecipe != null;
        public string Dish => SelectedRecipe?.Dish ?? "Unknown";
        public string Description => SelectedRecipe?.Description ?? "Unknown";
        public string Link => SelectedRecipe?.Link ?? "Unknown";

        public RecipesDetailsViewModel(SelectedRecipeStore selectedRecipeStore)
        {
            _selectedRecipeStore = selectedRecipeStore;

            _selectedRecipeStore.SelectedRecipeChanged += SelectedRecipeStore_SelectedRecipeChanged;
        }

        protected override void Dispose()
        {
            _selectedRecipeStore.SelectedRecipeChanged -= SelectedRecipeStore_SelectedRecipeChanged;

            base.Dispose();
        }

        private void SelectedRecipeStore_SelectedRecipeChanged()
        {
            OnPropertyChanged(nameof(HasSelectedRecipe));
            OnPropertyChanged(nameof(Dish));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(Link));
        }
    }
}
