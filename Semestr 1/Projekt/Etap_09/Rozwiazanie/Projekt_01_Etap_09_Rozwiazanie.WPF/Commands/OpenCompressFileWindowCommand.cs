using System.Windows.Input;

namespace Projekt_01_Etap_09_Rozwiazanie.WPF.Commands
{
    public class OpenCompressFileWindowCommand : ICommand
    {
        private bool _isBusy = false;

        public bool CanExecute(object parameter)
        {
            return !_isBusy;
        }

        public void Execute(object parameter)
        {
            _isBusy = true;
            CanExecuteChanged?.Invoke(this, new EventArgs());

            CompressForm comp = new CompressForm();
            comp.ShowDialog();

            _isBusy = false;
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged;
    }
}
