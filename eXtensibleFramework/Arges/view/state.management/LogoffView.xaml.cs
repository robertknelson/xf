﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace Arges
{
    /// <summary>
    /// Interaction logic for LogoffView.xaml
    /// </summary>
    public partial class LogoffView : UserControl
    {
        private System.Timers.Timer _Timer = null;

        public LogoffView()
        {
            InitializeComponent();
            _Timer = new System.Timers.Timer(1000.00);
            _Timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            _Timer.Enabled = true;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _Timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _Timer.Stop();

            Dispatcher.Invoke((Action)(() =>
            {
                Application.Current.Shutdown();
            }));
        }
    }
}
