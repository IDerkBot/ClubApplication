using ClubApplication.Entity;
using ClubApplication.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ClubApplication.Views
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
				Manager.Back();
			}
			else
				MessageBox.Show("Пользователь уже существует");
		}
	}
}
