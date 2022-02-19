﻿using Fluent;
using System;
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

namespace DeckWebV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        private readonly WebViewV2Controller wv2Controller = new();
        public MainWindow()
        {
            InitializeComponent();
            Quit_BT.Icon = iconlib.getIcon_Large("imageres.dll", 161);
            Reload_BT.Icon = iconlib.getIcon_Large("wmploc.dll", 132);
            HomeBT.Icon = iconlib.getIcon_Large("inetcpl.cpl", 0);
            wv2Controller.PageTitleChanged += (sender, e) => this.Title = e;
            this.DockPanelkun.Children.Add(wv2Controller.getWebView());
            wv2Controller.Navigate("https://tweetdeck.twitter.com/");
        }

        private void Quit_BT_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Reload_BT_Click(object sender, RoutedEventArgs e)
        {
            wv2Controller.Reload();
        }

        private void HomeBT_Click(object sender, RoutedEventArgs e)
        {

            wv2Controller.Navigate("https://tweetdeck.twitter.com/");
        }
    }
}
