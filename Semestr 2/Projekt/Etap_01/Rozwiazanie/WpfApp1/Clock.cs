using System.ComponentModel;
using System.Windows.Threading;

namespace WpfApp1
{
    public class Clock : INotifyPropertyChanged
    {
        public string CurrentTime => DateTime.Now.ToLongTimeString();

        //public string CurrentTime
        //{
        //    get { return DateTime.Now.ToLongTimeString(); }
        //}

        public event PropertyChangedEventHandler? PropertyChanged;


        private DispatcherTimer _timer;
        public Clock()
        {
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += (sender, o) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentTime)));
            _timer.Start();
        }
    }
}
