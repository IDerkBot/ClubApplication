using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ClubApplication.Models;
using ClubApplication.Models.Entity;
using ClubApplication.Views.Pages.Edit;

namespace ClubApplication.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для TeachersPage.xaml
	/// </summary>
	public partial class TeachersPage : Page
	{
		public TeachersPage()
		{
			InitializeComponent();
		}
		private void BtnEdit_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new TeacherEditPage((sender as Button)?.DataContext as Teacher));

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var usersForRemoving = DGrid.SelectedItems.Cast<Teacher>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemoving.Count()} элементов?", "Внимание",
				    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				ClubEntities.GetContext().Teachers.RemoveRange(usersForRemoving);
				ClubEntities.GetContext().SaveChanges();
				MessageBox.Show("Данные удалены!");
				DGrid.ItemsSource = ClubEntities.GetContext().Teachers.ToList();
			}
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new TeacherEditPage());

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			DGrid.ItemsSource = ClubEntities.GetContext().Teachers.ToList();
		}
	}
}
