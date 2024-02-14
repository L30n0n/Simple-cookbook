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
    public class RecipesListingItemViewModel : ViewModelBase
    {
        public Recipe Recipe { get; private set; }

        public string Dish => Recipe.Dish;
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        
        

        public RecipesListingItemViewModel(Recipe recipe, ModalNavigationStore modalNavigationStore, RecipesStore recipeStore)
        {
            Recipe = recipe;

            EditCommand = new OpenEditRecipeCommand(this, recipeStore, modalNavigationStore);
            DeleteCommand = new DeleteRecipeCommand(this, recipeStore);
        }

        public  void Update(Recipe recipe)
        {
            Recipe = recipe;
            
            OnPropertyChanged(nameof(Dish));
        }
    }
    
}
