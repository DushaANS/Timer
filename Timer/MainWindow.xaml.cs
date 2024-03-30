using System.Diagnostics.Metrics;
using System.Windows;
using System.Windows.Threading;

namespace Timer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DispatcherTimer timerSecond;
        public DispatcherTimer timerMinute;
        public DispatcherTimer timerHour;
        public DispatcherTimer timerDay;

        public int counterSecond;
        public int counterMinute;
        public int counterHour;
        public int counterDay;
        public int counterStop;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Windows_Loaded(object sender, RoutedEventArgs e)
        {
            timerSecond = new DispatcherTimer();
            timerSecond.Interval = TimeSpan.FromSeconds(1);
            timerSecond.Tick += Timer_Tick;
            timerSecond.Start();

            timerMinute = new DispatcherTimer();
            timerMinute.Interval = TimeSpan.FromMinutes(1);
            timerMinute.Tick += Timer_Tick;
            timerMinute.Start();

            timerHour = new DispatcherTimer();
            timerHour.Interval = TimeSpan.FromMinutes(1);
            timerHour.Tick += Timer_Tick;
            timerHour.Start();

            timerDay = new DispatcherTimer();
            timerDay.Interval = TimeSpan.FromMinutes(1);
            timerDay.Tick += Timer_Tick;
            timerDay.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            counterSecond++;
            TimerTickSecondLabel.Content = counterSecond.ToString();
            secondaryMinute();
            secondaryHour();
            secondaryDay();

            void secondaryMinute()
            {
                if (counterSecond == 60)
                {
                    {
                        counterSecond = 0;
                        counterMinute++;
                        TimerTickMinuteLabel.Content = counterMinute.ToString();
                    }
                }
            }
            void secondaryHour()
            {
                if (counterMinute == 60)
                {
                    {
                        counterMinute = 0;
                        counterHour++;
                        TimerTickHourLabel.Content = counterHour.ToString();
                    }
                }
            }
            void secondaryDay()
            {
                if (counterHour == 24)
                {
                    {
                        counterHour = 0;
                        counterDay++;
                        TimerTickDayLabel.Content = counterDay.ToString();
                    }
                }
            }
        }

        private void StopClick(object sender, RoutedEventArgs e)
        {
            timerSecond.Stop();
            timerMinute.Stop();
            timerHour.Stop();
            timerDay.Stop();
            counterStop++;

            if(counterStop == 2)
            {
                counterStop = 0;
                timerSecond.Start();
                timerMinute.Start();
                timerHour.Start();
                timerDay.Start();
            }
        }
    }
}