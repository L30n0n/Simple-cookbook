using CookbookWPF.Stores;
using CookbookWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookbookWPF.Commands
{
    public class LoadRecipeCommand : AsyncCommandBase
    {
        private readonly CookbookViewModel _cookbookViewModel;
        private readonly RecipesStore _recipeStore;

        public LoadRecipeCommand(CookbookViewModel cookbookViewModel, RecipesStore recipeStore)
        {
            _cookbookViewModel = cookbookViewModel;
            _recipeStore = recipeStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _cookbookViewModel.IsLoading = true;

            try
            {
            await _recipeStore.Load();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _cookbookViewModel.IsLoading = false;
            }
        }
    }
}
