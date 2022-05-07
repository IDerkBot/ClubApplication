using ClubApplication.Entity;
using ClubApplication.Models;
using System.Windows;
using System.Windows.Controls;

namespace ClubApplication.Views.Edit
{
	/// <summary>
	/// Логика взаимодействия для ClubEditPage.xaml
	/// </summary>
	public partial class ClubEditPage : Page
	{
		private readonly Club _currentClub;
		public ClubEditPage(Club selectedClub = null)
		{
			InitializeComponent();
			_currentClub = selectedClub ?? new Club();
			DataContext = _currentClub;
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (_currentClub.ID == 0) ClubEntities.GetContext().Clubs.Add(_currentClub);
			ClubEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные сохранены!");
			Manager.Back();
		}
	}
}
