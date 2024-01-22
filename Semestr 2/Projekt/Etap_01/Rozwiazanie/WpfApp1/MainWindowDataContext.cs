using System.ComponentModel;

namespace WpfApp1
{
    public class MainWindowDataContext : INotifyPropertyChanged
    {
        public string? UserName { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindowDataContext()
        {
        }

        private bool _isNameNeeded = true;

        public bool IsNameNeeded
        {
            get { return _isNameNeeded; }
            set
            {
                if (value != _isNameNeeded)
                {
                    _isNameNeeded = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsNameNeeded)));
                }
            }
        }
    }
}
