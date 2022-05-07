using System.Windows.Controls;

namespace ClubApplication.Models
{
	internal class Manager
	{
		public static Frame MainFrame { get; set; }
		public static void Navigate(Page titlePage) => MainFrame.Navigate(titlePage);
		public static void Back() { if (MainFrame.CanGoBack) MainFrame.GoBack(); }
	}
}