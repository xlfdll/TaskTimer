﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace TaskTimer
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromTicks(TimeSpan.TicksPerSecond)
            };

            Timer.Tick += Timer_Tick;
        }

        private void TimerTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Only when timer is not running

            if (Timer != null && !Timer.IsEnabled)
            {
                OriginalTime = TimeSpan.Zero;
            }
        }

        private void TimerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Timer.IsEnabled)
            {
                try
                {
                    CurrentTime = TimeSpan.Parse(TimerTextBox.Text);
                }
                catch
                {
                    MessageBox.Show(this, "Time format is invalid!", this.Title, MessageBoxButton.OK, MessageBoxImage.Warning);

                    CurrentTime = TimeSpan.Zero;
                }

                if (CurrentTime <= TimeSpan.Zero)
                {
                    return;
                }

                // Avoid overriding OriginalTime after a sequence of pause / resume operations

                if (OriginalTime == TimeSpan.Zero)
                {
                    OriginalTime = CurrentTime;
                }

                Timer.Start();
            }
            else
            {
                Timer.Stop();
            }

            TimerButtonImage.Source = this.FindResource(!Timer.IsEnabled ? "TimerStartIcon" : "TimerStopIcon") as DrawingImage;

            TimerTextBox.IsReadOnly = Timer.IsEnabled;
            TaskTextBox.IsReadOnly = Timer.IsEnabled;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CurrentTime = CurrentTime.Subtract(Timer.Interval);

            TimerTextBox.Text = CurrentTime.ToString();

            if (CurrentTime.Equals(TimeSpan.Zero))
            {
                Timer.Stop();

                this.Activate();

                MessageBox.Show(this, "Time is up!", this.Title, MessageBoxButton.OK, MessageBoxImage.Information);

                TimerTextBox.Text = OriginalTime.ToString();

                TimerButtonImage.Source = this.FindResource("TimerStartIcon") as DrawingImage;

                TimerTextBox.IsReadOnly = Timer.IsEnabled;
                TaskTextBox.IsReadOnly = Timer.IsEnabled;
            }
        }

        private TimeSpan OriginalTime { get; set; }
        private TimeSpan CurrentTime { get; set; }
        private DispatcherTimer Timer { get; set; }
    }
}