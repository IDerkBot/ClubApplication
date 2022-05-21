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
using System.Windows.Shapes;
using ClubApplication.Models.Entity;

namespace ClubApplication.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
            var clubs = ClubEntities.GetContext().Clubs.ToList();
            var TvItems = new List<object>();
            clubs.ForEach(club =>
            {
                TvItems.Add(new TreeViewItem()
                {
                    Header = $"Клуб: {club.Title} ({((club.Count == 0) ? "Детей в кружке нет" : $"Количество детей: {club.Count}")})",
                    ItemsSource = club.Children.Select(x => x.Fullname)
                });
            });
            SpClubs.ItemsSource = TvItems;
        }
    }
}
