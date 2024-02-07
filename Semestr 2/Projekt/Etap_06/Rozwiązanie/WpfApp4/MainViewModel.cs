using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace WpfApp1
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private int _button1Clicks;
        private int _button2Clicks;
        private string _clicksInfo;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SayHelloCommand { get; }
        public ICommand SayHelloWithNameCommand { get; }
        public ICommand ChangeBackgroundColorCommand { get; }
        public ICommand DisplayButtonNameCommand { get; }
        public ICommand CountButtonClicksCommand { get; }

        public MainViewModel()
        {
            SayHelloCommand = new RelayCommand(ShowHelloMessage);
            SayHelloWithNameCommand = new RelayCommand(ShowHelloMessageWithName);
            ChangeBackgroundColorCommand = new RelayCommand(ChangeBackgroundColor);
            DisplayButtonNameCommand = new RelayCommand(DisplayButtonName);
            CountButtonClicksCommand = new RelayCommand(CountButtonClicks);
        }

        private void ShowHelloMessage(object obj)
        {
            MessageBox.Show("Cześć!");
        }

        private void ShowHelloMessageWithName(object obj)
        {
            string userName = obj as string;
            MessageBox.Show($"Cześć, {userName}!");
        }

        private void ChangeBackgroundColor(object obj)
        {
            if (Application.Current.MainWindow != null)
            {
                Application.Current.MainWindow.Background = System.Windows.Media.Brushes.Red;
            }
        }

        private void DisplayButtonName(object obj)
        {
            string buttonName = obj as string;
            MessageBox.Show($"Nazwa przycisku: {buttonName}");
        }

        private void CountButtonClicks(object obj)
        {
            string buttonName = obj as string;
            if (buttonName == "Przycisk 1")
            {
                _button1Clicks++;
            }
            else if (buttonName == "Przycisk 2")
            {
                _button2Clicks++;
            }
            ClicksInfo = $"Przycisk 1 - {_button1Clicks}-kliknięć; Przycisk 2 - {_button2Clicks}-kliknięć";
        }

        public string ClicksInfo
        {
            get { return _clicksInfo; }
            set
            {
                _clicksInfo = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
