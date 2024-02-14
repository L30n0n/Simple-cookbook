using Cookbook.Domain.Commands;
using Cookbook.Domain.Queries;
using Cookbook.EntityFramework;
using Cookbook.EntityFramework.Commands;
using Cookbook.EntityFramework.Queries;
using CookbookWPF.Stores;
using CookbookWPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CookbookWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly SelectedRecipeStore _selectedRecipeStore;
        private readonly RecipesDbContextFactory _recipesDbContextFactory;
        private readonly IGetAllRecipesQuery _getAllRecipesQuery;
        private readonly ICreateRecipeCommand _createRecipeCommand;
        private readonly IUpdateRecipeCommand _updateRecipeCommand;
        private readonly IDeleteRecipeCommand _deleteRecipeCommand;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly RecipesStore _recipeStore;
        
        public App()
        {
            string _connectionString = "Data Source=Recipes.db";

            _modalNavigationStore = new ModalNavigationStore();
            _recipesDbContextFactory = new RecipesDbContextFactory(
                new DbContextOptionsBuilder().UseSqlite(_connectionString).Options
                );
            _getAllRecipesQuery = new GetAllRecipesQuery(_recipesDbContextFactory);
            _createRecipeCommand = new CreateRecipeCommand(_recipesDbContextFactory);
            _updateRecipeCommand = new UpdateRecipeCommand(_recipesDbContextFactory);
            _deleteRecipeCommand = new DeleteRecipeCommand(_recipesDbContextFactory);
            _recipeStore = new RecipesStore(_getAllRecipesQuery, _createRecipeCommand, _updateRecipeCommand, _deleteRecipeCommand);
            _selectedRecipeStore = new SelectedRecipeStore(_recipeStore);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (RecipesDbContext context = _recipesDbContextFactory.Create())
            {
                context.Database.Migrate();
            }
            CookbookViewModel cookbookViewModel = CookbookViewModel.LoadViewModel(_recipeStore, _selectedRecipeStore, _modalNavigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, cookbookViewModel)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
