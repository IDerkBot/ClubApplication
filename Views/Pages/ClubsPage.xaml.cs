using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ClubApplication.Models;
using ClubApplication.Models.Entity;
using ClubApplication.Views.Pages.Edit;
using ClubApplication.Views.Windows;

namespace ClubApplication.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для ClubsPage.xaml
	/// </summary>
	public partial class ClubsPage : Page
	{
		public ClubsPage()
		{
			InitializeComponent();
		}
		private void BtnEdit_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new ClubEditPage((sender as Button)?.DataContext as Club));

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var usersForRemoving = DGrid.SelectedItems.Cast<Club>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemoving.Count()} элементов?", "Внимание",
				    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				ClubEntities.GetContext().Clubs.RemoveRange(usersForRemoving);
				ClubEntities.GetContext().SaveChanges();
				MessageBox.Show("Данные удалены!");
				DGrid.ItemsSource = ClubEntities.GetContext().Clubs.ToList();
			}
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new ClubEditPage());

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			DGrid.ItemsSource = ClubEntities.GetContext().Clubs.ToList();
			BtnReport.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
		}

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            new ReportWindow().Show();
        }
    }
}
