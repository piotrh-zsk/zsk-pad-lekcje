using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfApp5
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand KlikniecieCMD { get; set; }

        public ButtonClickInfo Btn1ClickInfo { get; set; }
        public ButtonClickInfo Btn2ClickInfo { get; set; }

        private string buttonInfoClicks;
        public string ButtonInfoClicks
        {
            get => buttonInfoClicks;
            set
            {
                buttonInfoClicks = value;
                OnPropertyChanged("ButtonInfoClicks");
            }
        }

        public MainWindowViewModel()
        {
            ButtonInfoClicks = "start";
            KlikniecieCMD = new KlikniecieCommand();

            Btn1ClickInfo = new ButtonClickInfo();
            Btn1ClickInfo.ButtonName = "btn1";
            Btn1ClickInfo.ButtonClicks = 0;
            Btn1ClickInfo.PropertyChanged += BtnInfo_PropertyChanged;
            Btn2ClickInfo = new ButtonClickInfo();
            Btn2ClickInfo.ButtonName = "btn2";
            Btn2ClickInfo.ButtonClicks = 0;
            Btn2ClickInfo.PropertyChanged += BtnInfo_PropertyChanged;
        }

        private void BtnInfo_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            ButtonInfoClicks = Btn1ClickInfo.ButtonName + " clicks: " + Btn1ClickInfo.ButtonClicks + "  |||  " + Btn2ClickInfo.ButtonName + " clicks: " + Btn2ClickInfo.ButtonClicks;
            OnPropertyChanged("ButtonInfoClicks");
        }
    }

    public class ButtonClickInfo : INotifyPropertyChanged
    {
        private string buttonName;
        public string ButtonName
        {
            get => buttonName;
            set
            {
                buttonName = value;
                OnPropertyChanged(nameof(ButtonName));
            }
        }

        private int buttonClicks;
        public int ButtonClicks
        {
            get => buttonClicks;
            set
            {
                buttonClicks = value;
                OnPropertyChanged(nameof(ButtonClicks));
            }
        }


        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

    public class KlikniecieCommand : ICommand
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

            ButtonClickInfo ctx = (ButtonClickInfo)parameter;
            ctx.ButtonClicks++;

            _isBusy = false;
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        // Zdarzenie, które informuje o zmianach w możliwości wykonania polecenia
        public event EventHandler CanExecuteChanged;
    }
}
