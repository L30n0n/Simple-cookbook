using Cookbook.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookbookWPF.Stores
{
    public class SelectedRecipeStore
    {
        private readonly RecipesStore _recipeStore;
        private Recipe _selectedRecipe;
        public Recipe SelectedRecipe
        {
            get
            {
                return _selectedRecipe;
            }
            set
            {
                _selectedRecipe = value;
                SelectedRecipeChanged?.Invoke();
            }
        }
        public event Action SelectedRecipeChanged;

        public SelectedRecipeStore(RecipesStore recipeStore)
        {
            _recipeStore = recipeStore;

            _recipeStore.RecipeUpdated += RecipeStore_RecipeUpdated;
        }

        private void RecipeStore_RecipeUpdated(Recipe recipe)
        {
            if (recipe.Id == SelectedRecipe?.Id)
            {
                SelectedRecipe = recipe;
            }
        }
    }
}
