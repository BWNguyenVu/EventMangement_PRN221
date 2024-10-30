using BusinessObjects.Models;
using System.Windows;


namespace WpfApp_Assignment_SE173139_DoHuynhNguyenVu
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void BtnUserManagement_Click(object sender, RoutedEventArgs e)
        {
            UserManagementWindow userManagementWindow = new UserManagementWindow();
            userManagementWindow.Show();
            this.Close(); // Đóng cửa sổ Menu
        }

        private void BtnClassManagement_Click(object sender, RoutedEventArgs e)
        {
            EventManagementWindow eventManagement = new EventManagementWindow();
            eventManagement.Show();
            this.Close(); // Đóng cửa sổ Menu
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnAssignStudentToClass_Click(object sender, RoutedEventArgs e)
        {
            UserEventManagementWindow userClassManagementWindow = new UserEventManagementWindow();
            userClassManagementWindow.Show();
            this.Close();
        }
    }
}
