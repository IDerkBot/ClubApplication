using ClubApplication.Models;
using System.Windows;
using System.Windows.Controls;

namespace ClubApplication.Views
{
	/// <summary>
	/// Логика взаимодействия для MenuPage.xaml
	/// </summary>
	public partial class MenuPage : Page
	{
		public MenuPage() => InitializeComponent();

		private void BtnClubsMove_OnClick(object sender, RoutedEventArgs e) => Manager.Navigate(new ClubsPage());

		private void BtnChildrenMove_OnClick(object sender, RoutedEventArgs e) => Manager.Navigate(new ChildrensPage());

		private void BtnParentsMove_OnClick(object sender, RoutedEventArgs e) => Manager.Navigate(new Parents());

		private void BtnUsersMove_OnClick(object sender, RoutedEventArgs e) => Manager.Navigate(new UsersPage());

		private void MenuPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			BtnChildrenMove.Visibility = Data.IsParent ? Visibility.Collapsed : Visibility.Visible;
			BtnParentsMove.Visibility = Data.IsParent ? Visibility.Collapsed : Visibility.Visible;
			BtnUsersMove.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
		}
	}
}
