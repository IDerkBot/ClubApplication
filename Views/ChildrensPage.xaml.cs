using ClubApplication.Entity;
using ClubApplication.Models;
using ClubApplication.Views.Edit;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ClubApplication.Views
{
	/// <summary>
	/// Логика взаимодействия для ChildrensPage.xaml
	/// </summary>
	public partial class ChildrensPage : Page
	{
		public ChildrensPage()
		{
			InitializeComponent();
		}
		private void BtnEdit_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new ChildrenEditPage((sender as Button)?.DataContext as Child));

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var usersForRemoving = DGrid.SelectedItems.Cast<Child>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemoving.Count()} элементов?", "Внимание",
				    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				ClubEntities.GetContext().Children.RemoveRange(usersForRemoving);
				ClubEntities.GetContext().SaveChanges();
				MessageBox.Show("Данные удалены!");
				DGrid.ItemsSource = ClubEntities.GetContext().Children.ToList();
			}
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new ChildrenEditPage());

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			DGrid.ItemsSource = ClubEntities.GetContext().Children.ToList();
		}
	}
}
