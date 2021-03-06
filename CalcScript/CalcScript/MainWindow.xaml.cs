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

namespace CalcScript
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            codeTextBox.Focus();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Enter) && e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Control))
            {
                if (calcButton.Command?.CanExecute(calcButton.CommandParameter) ?? false)
                {
                    calcButton.Command?.Execute(calcButton.CommandParameter);
                }
            }
        }
    }
}
