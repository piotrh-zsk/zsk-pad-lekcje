using Microsoft.Win32;
using Projekt_01_Etap_09_Rozwiazanie.WPF.Presenters;
using System.IO;
using System.Windows.Input;

namespace Projekt_01_Etap_09_Rozwiazanie.WPF.Commands
{
    public class DecompressFileCommand : ICommand
    {
        private DecompressFormPresenter _model;

        public DecompressFileCommand(DecompressFormPresenter model)
        {
            _model = model;
        }

        private bool _isBusy = false;

        public bool CanExecute(object parameter)
        {
            return !_isBusy;
        }

        public void Execute(object parameter)
        {
            _isBusy = true;
            CanExecuteChanged?.Invoke(this, new EventArgs());

            string filename = "";
            byte[]? fileContents = null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ZSK Compressed File file|*.zcf";
            if (ofd.ShowDialog() == true)
            {
                filename = ofd.SafeFileName;
                fileContents = File.ReadAllBytes(ofd.FileName);
            }
            if (fileContents != null)
            {
                _model.PerformTextDecompression(filename, fileContents);
            }

            _isBusy = false;
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged;
    }
}
