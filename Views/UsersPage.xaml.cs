using ClubApplication.Entity;
using ClubApplication.Models;
using ClubApplication.Views.Edit;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ClubApplication.Views
{
	/// <summary>
	/// Логика взаимодействия для UsersPage.xaml
	/// </summary>
	public partial class UsersPage : Page
	{
		public UsersPage()
		{
			InitializeComponent();
		}
		private void BtnEdit_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new UserEditPage((sender as Button)?.DataContext as User));

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var usersForRemoving = DGrid.SelectedItems.Cast<User>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemoving.Count()} элементов?", "Внимание",
				    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				ClubEntities.GetContext().Users.RemoveRange(usersForRemoving);
				ClubEntities.GetContext().SaveChanges();
				MessageBox.Show("Данные удалены!");
				DGrid.ItemsSource = ClubEntities.GetContext().Users.ToList();
			}
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new UserEditPage());

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			DGrid.ItemsSource = ClubEntities.GetContext().Users.ToList();
		}
	}
}
