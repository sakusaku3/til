using System.Collections.ObjectModel;
using Calculator.Models;

namespace Calculator.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<TermViewModel> Terms { get; } 
            = new ObservableCollection<TermViewModel>();

        public int Result 
        {
            get { return this.model.Result; }
            set { this.model.Result = value; }
        }

        public DelegateCommand AddCommand { get; }

        public DelegateCommand AddTermCommand { get; }

        public DelegateCommand DeleteTermCommand { get; }

        private readonly Adder model;

        public MainViewModel() 
        {
            this.model = new Adder();

            this.model.AddPropertyChanged(
                nameof(this.model.Result), 
                () => this.OnPropertyChanged(nameof(this.Result)));

            this.Terms.SynchronizeWith(
                this.model.Terms,
                x => new TermViewModel(x));

            this.AddCommand = new DelegateCommand(
                this.model.AddExecute,
                this.model.CanAddExecute);

            this.AddTermCommand = new DelegateCommand(
                this.model.AddNewTerm);

            this.DeleteTermCommand = new DelegateCommand(
                this.model.DeleteTerm);
        }
    }
}
