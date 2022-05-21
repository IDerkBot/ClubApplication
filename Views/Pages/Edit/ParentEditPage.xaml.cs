using System.Windows;
using System.Windows.Controls;
using ClubApplication.Models;
using ClubApplication.Models.Entity;

namespace ClubApplication.Views.Pages.Edit
{
	/// <summary>
	/// Логика взаимодействия для ParentEditPage.xaml
	/// </summary>
	public partial class ParentEditPage : Page
	{
		private readonly Parent _currentParent;
		public ParentEditPage(Parent selectedParent = null)
		{
			InitializeComponent();
			_currentParent = selectedParent ?? new Parent();
			DataContext = _currentParent;
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (_currentParent.ID == 0) ClubEntities.GetContext().Parents.Add(_currentParent);
			ClubEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные сохранены!");
			PageManager.GoBack();
		}
	}
}
