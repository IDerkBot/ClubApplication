using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ClubApplication.Models;
using ClubApplication.Models.Entity;

namespace ClubApplication.Views.Pages
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
			if (ClubEntities.GetContext().Users.Any(x => x.Login == Login.Text))
            {
                var user = ClubEntities.GetContext().Users
                    .Single(x => x.Login == Login.Text);
                if (user.Password == PbPassword.Password)
                {
                    Data.Access = user.Access;
                    PageManager.Navigate(new MenuPage());
				}
                else AlertManager.Alert("Пароль не верный!");
			}
			else AlertManager.Alert("Такого пользователя не существует!");
		}

		private void Reg_Click(object sender, RoutedEventArgs e)
		{
			PageManager.Navigate(new RegPage());
		}
	}
}
