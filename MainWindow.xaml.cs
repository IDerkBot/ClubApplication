using ClubApplication.Models;
using ClubApplication.Views;
using System;
using System.Windows;

namespace ClubApplication
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Manager.MainFrame = MainFrame;
			Manager.Navigate(new AuthPage());
		}

		private void MainFrame_ContentRendered(object sender, EventArgs e)
		{
			BtnBack.Visibility = Manager.MainFrame.CanGoBack ? Visibility.Visible : Visibility.Hidden;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Manager.Back();
		}
	}
}
