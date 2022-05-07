using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClubApplication.Entity;
using ClubApplication.Models;
using ClubApplication.Views.Edit;

namespace ClubApplication.Views
{
	/// <summary>
	/// Логика взаимодействия для Parents.xaml
	/// </summary>
	public partial class Parents : Page
	{
		public Parents()
		{
			InitializeComponent();
		}
		private void BtnEdit_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new ParentEditPage((sender as Button)?.DataContext as Parent));

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var usersForRemoving = DGrid.SelectedItems.Cast<Parent>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemoving.Count()} элементов?", "Внимание",
				    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				ClubEntities.GetContext().Parents.RemoveRange(usersForRemoving);
				ClubEntities.GetContext().SaveChanges();
				MessageBox.Show("Данные удалены!");
				DGrid.ItemsSource = ClubEntities.GetContext().Parents.ToList();
			}
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new ParentEditPage());

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			DGrid.ItemsSource = ClubEntities.GetContext().Parents.ToList();
		}
	}
}
