﻿using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Automatic_Fan_Controller
{
    public partial class MainWindow : Window
    {
        private readonly Controller _controller = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _controller;
            _controller.ConnectArduinoPortAsync();
        }

        private void RadioAutoMode_Checked(object sender, RoutedEventArgs e)
        {
            _controller.IsManualMode = false;
            _controller.IsAutoMode = true;
        }

        private void RadioManualMode_Checked(object sender, RoutedEventArgs e)
        {
            _controller.IsManualMode = true;
            _controller.IsAutoMode = false;
        }

        private void BtnMinusTemperature_Click(object sender, RoutedEventArgs e)
        {
            _controller.ActivationTemp--;
        }

        private void BtnAddTemperature_Click(object sender, RoutedEventArgs e)
        {
            _controller.ActivationTemp++;
        }

        private void BtnMinusStartFanSpeed_Click(object sender, RoutedEventArgs e)
        {
            _controller.StartFanSpeed--;
        }

        private void BtnAddStartFanSpeed_Click(object sender, RoutedEventArgs e)
        {
            _controller.StartFanSpeed++;
        }

        private void BtnFanSpeed_Off_Click(object sender, RoutedEventArgs e)
        {
            _controller.FanSpeed = 0;
        }

        private void BtnFanSpeed_Max_Click(object sender, RoutedEventArgs e)
        {
            _controller.FanSpeed = 99;
        }

        private void BtnFanSpeed_30_Click(object sender, RoutedEventArgs e)
        {
            _controller.FanSpeed = 30;
        }

        private void BtnFanSpeed_50_Click(object sender, RoutedEventArgs e)
        {
            _controller.FanSpeed = 50;
        }

        private void BtnFanSpeed_70_Click(object sender, RoutedEventArgs e)
        {
            _controller.FanSpeed = 70;
        }

        private void BtnFanSpeed_90_Click(object sender, RoutedEventArgs e)
        {
            _controller.FanSpeed = 90;
        }

        private void LblStartFanSpeed_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^1-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void LblActivationTemperature_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Toolbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
