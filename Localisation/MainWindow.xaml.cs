﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Localisation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Thread.CurrentThread.CurrentUICulture.Equals(CultureInfo.CreateSpecificCulture("en-US")))
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
            else
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");


            //this.UpdateLayout();

            (new MainWindow()).Show();

            this.Close();
        }
    }
}
