using ClubApplication.Models.Entity;
using System.Linq;
using System.Windows;
using ClubApplication.Views.Pages;

namespace ClubApplication.Views.Windows
{
    /// <summary>
    /// Interaction logic for SendWindows.xaml
    /// </summary>
    public partial class SendWindows : Window
    {
        private readonly Child _currentChild;
        private readonly ChildrenPage _currentWindow;
        public SendWindows(ChildrenPage windows, Child selectedChild)
        {
            InitializeComponent();
            _currentChild = selectedChild;
            _currentWindow = windows;
            CbClubs.ItemsSource = ClubEntities.GetContext().Clubs.ToList();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (CbClubs.SelectedItem == null)
            {
                MessageBox.Show("Выберите клуб");
                return;
            }
            var club = (Club)CbClubs.SelectedItem;
            if (club.Children.Count == club.MaxChildren)
            {
                MessageBox.Show("Клуб заполнен");
                return;
            }
            _currentChild.Clubs.Add(club);
            ClubEntities.GetContext().SaveChanges();
            _currentWindow.Update();
            MessageBox.Show("Запись успешно прошла!");
            Close();
        }
    }
}
