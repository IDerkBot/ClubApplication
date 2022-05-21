using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ClubApplication.Models;
using ClubApplication.Models.Entity;

namespace ClubApplication.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для RegPage.xaml
	/// </summary>
	public partial class RegPage : Page
	{
		public RegPage()
		{
			InitializeComponent();
		}

		private void Reg_Click(object sender, RoutedEventArgs e)
		{
			if (!ClubEntities.GetContext().Users.Any(x => x.Login == Login.Text))
			{
				ClubEntities.GetContext().Users.Add(new User() {Login = Login.Text, Password = Password.Password});
				ClubEntities.GetContext().SaveChanges();
				PageManager.GoBack();
			}
			else
				MessageBox.Show("Пользователь уже существует");
		}
	}
}
