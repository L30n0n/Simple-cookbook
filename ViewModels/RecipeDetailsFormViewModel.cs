using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CookbookWPF.ViewModels
{
    public class RecipeDetailsFormViewModel : ViewModelBase
    {
        private string _dish;
        
        public string Dish
        {
            get { return _dish; }
            set
            {
                _dish = value;
                OnPropertyChanged(nameof(Dish));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }
        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string _link;

        public string Link
        {
            get { return _link; }
            set
            {
                _link = value;
                OnPropertyChanged(nameof(Link));
            }
        }

        private bool _isSubmitting;
        public bool IsSubmitting
        {
            get
            {
                return _isSubmitting;
            }
            set
            {
                _isSubmitting = value;
                OnPropertyChanged(nameof(IsSubmitting));
            }
        }

        public bool CanSubmit => !string.IsNullOrEmpty(Dish);

        public ICommand SubmitCommand { get; }

        public ICommand CancelCommand { get; }

        public RecipeDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }
    }
}
