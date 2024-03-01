using Microsoft.Win32;
using Projekt_01_Etap_09_Rozwiazanie.WPF.Presenters;
using System.IO;
using System.Text;
using System.Windows.Input;

namespace Projekt_01_Etap_09_Rozwiazanie.WPF.Commands
{
    public class AnalyzeTextCommand : ICommand
    {
        private RichTextBoxFormPresenter _model;

        public AnalyzeTextCommand(RichTextBoxFormPresenter model)
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

            string currentPath = Environment.CurrentDirectory;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = currentPath;
            if (openFileDialog.ShowDialog() == true)
            {
                var fileText = File.ReadAllText(openFileDialog.FileName, Encoding.GetEncoding("Windows-1250"));
                _model.InputText = fileText;
                _model.PerformTextAnalysis(fileText);
            }

            _isBusy = false;
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged;
    }
}
