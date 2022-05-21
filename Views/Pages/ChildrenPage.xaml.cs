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
	/// Логика взаимодействия для ChildrenPage.xaml
	/// </summary>
	public partial class ChildrenPage : Page
	{
		public ChildrenPage()
		{
			InitializeComponent();
		}
		private void BtnEdit_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new ChildrenEditPage((sender as Button)?.DataContext as Child));

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

		private void BtnAdd_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new ChildrenEditPage());

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			Update();
		}

        public void Update()
        {
            DGrid.ItemsSource = ClubEntities.GetContext().Children.ToList();
		}

        private void BtnSend_OnClick(object sender, RoutedEventArgs e)
        {
            var send = new SendWindows(this, (sender as Button)?.DataContext as Child);
			send.Show();
        }
    }
}
