using System.Windows;
using System.Windows.Controls;
using ClubApplication.Models;
using ClubApplication.Models.Entity;

namespace ClubApplication.Views.Pages.Edit
{
	/// <summary>
	/// Логика взаимодействия для TeacherEditPage.xaml
	/// </summary>
	public partial class TeacherEditPage : Page
	{
		private readonly Teacher _currentTeacher;
		public TeacherEditPage(Teacher selectedTeacher = null)
		{
			InitializeComponent();
			_currentTeacher = selectedTeacher ?? new Teacher();
			DataContext = _currentTeacher;
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (_currentTeacher.ID == 0) ClubEntities.GetContext().Teachers.Add(_currentTeacher);
			ClubEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные сохранены!");
			PageManager.GoBack();
		}
	}
}
