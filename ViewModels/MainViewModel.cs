using CookbookWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookbookWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public ViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
        public bool IsModalOpen => _modalNavigationStore.IsOpen;
        public CookbookViewModel CookbookViewModel { get; }
        public MainViewModel(ModalNavigationStore modalNavigationStore, CookbookViewModel cookbookViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            CookbookViewModel = cookbookViewModel;

            _modalNavigationStore.CurrentViewModelChanged += _modalNavigationStore_CurrentViewModelChanged;
        }

        protected override void Dispose()
        {
            _modalNavigationStore.CurrentViewModelChanged -= _modalNavigationStore_CurrentViewModelChanged;

            base.Dispose();
        }

        private void _modalNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}
