/*
 * Created by SharpDevelop.
 * User: Rasyid
 * Date: 14/12/2016
 * Time: 17.31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace AEGIS
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent(); 
            DataContext = new MainWindowViewModel();

        } 
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuListBox_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void DockPanel_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Hamburger.IsChecked = false;
        }
    }
}