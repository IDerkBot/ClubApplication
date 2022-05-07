using System.Linq;
using ClubApplication.Entity;
using ClubApplication.Models;
using System.Windows;
using System.Windows.Controls;

namespace ClubApplication.Views.Edit
{
	/// <summary>
	/// Логика взаимодействия для ChildrenEditPage.xaml
	/// </summary>
	public partial class ChildrenEditPage : Page
	{
		private readonly Child _currentChild;
		public ChildrenEditPage(Child selectedChild = null)
		{
			InitializeComponent();
			CbParents.ItemsSource = ClubEntities.GetContext().Parents.ToList();
			_currentChild = selectedChild ?? new Child();
			DataContext = _currentChild;
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (_currentChild.ID == 0) ClubEntities.GetContext().Children.Add(_currentChild);
			ClubEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные сохранены!");
			Manager.Back();
		}
	}
}
