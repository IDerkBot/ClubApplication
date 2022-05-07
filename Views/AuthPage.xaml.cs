using ClubApplication.Entity;
using ClubApplication.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ClubApplication.Views
{
	/// <summary>
	/// Логика взаимодействия для AuthPage.xaml
	/// </summary>
	public partial class AuthPage : Page
	{
		public AuthPage()
		{
			InitializeComponent();
		}
		private void Auth_Click(object sender, RoutedEventArgs e)
		{
			if (ClubEntities.GetContext().Users.Any(x => x.Login == Login.Text && x.Password == Password.Password))
			{
				Manager.Navigate(new MenuPage());
			}
			else
			{
				MessageBox.Show("Логин или пароль введены не верно");
			}
		}

		private void Reg_Click(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new RegPage());
		}
	}
}
