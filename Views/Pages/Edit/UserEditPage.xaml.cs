using System.Windows;
using System.Windows.Controls;
using ClubApplication.Models;
using ClubApplication.Models.Entity;

namespace ClubApplication.Views.Pages.Edit
{
	/// <summary>
	/// Логика взаимодействия для UserEditPage.xaml
	/// </summary>
	public partial class UserEditPage : Page
	{
		private readonly User _currentUser;
		public UserEditPage(User selectedUser = null)
		{
			InitializeComponent();
			_currentUser = selectedUser ?? new User();
			DataContext = _currentUser;
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (_currentUser.ID == 0) ClubEntities.GetContext().Users.Add(_currentUser);
			ClubEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные сохранены!");
			PageManager.GoBack();
		}
	}
}
