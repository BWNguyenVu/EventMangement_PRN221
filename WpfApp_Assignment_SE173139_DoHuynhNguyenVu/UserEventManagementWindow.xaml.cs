using System.Collections.Generic;
using System.Windows;
using Services;
using Services.Interfaces;
using BusinessObjects.Models;
using System.Windows.Controls;

namespace WpfApp_Assignment_SE173139_DoHuynhNguyenVu
{
    public partial class UserEventManagementWindow : Window
    {
        private readonly IUserEventService userEventService;
        private UserEvent? selectedUserEvent;

        public UserEventManagementWindow()
        {
            InitializeComponent();
            userEventService = new UserEventService();
            LoadUserEvents();
        }

        private void LoadUserEvents()
        {
            List<UserEvent> userEvents = userEventService.GetAllUserEvents();
            dgUserEvent.ItemsSource = userEvents;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.selectedUserEvent == null)
            {
                MessageBox.Show("Please select a user event!", "Warning Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this user event?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.userEventService.DeleteUserEvent(this.selectedUserEvent.UserEventId);
                LoadUserEvents();
            }
        } 

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }

        private void dgUserEvent_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;

            if (dataGrid.SelectedItem == null)
                return;

            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(dataGrid.SelectedItem);
            if (row == null)
                return;

            DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            if (RowColumn == null)
                return;

            int id = int.Parse(((TextBlock)RowColumn.Content).Text);
            UserEvent userEvent = this.userEventService.GetUserEventById(id);
            this.selectedUserEvent = userEvent;

        }

        private void btnAssign_Click(object sender, RoutedEventArgs e)
        {
            AssignUserToEventWindow assignUserToClassWindow = new AssignUserToEventWindow();
            assignUserToClassWindow.Show();
            this.Close();
        }
    }
}
