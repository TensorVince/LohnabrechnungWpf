﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


namespace LohnabrechnungWpf
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.Navigate("file:///C:/Users/somebody/Desktop/Test.html");
            webBrowser.InvokeScript("execScript", new object[] { "window.print();", "JavaScript" });
        }

        private void BtnShowThirdPartyContent_Click(object sender, RoutedEventArgs e)
        {
            new winThirdPartyStuff().ShowDialog();
        }
    }
}
