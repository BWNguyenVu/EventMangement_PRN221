using System.Collections.Generic;
using System.Windows;
using Services;
using Services.Interfaces;
using BusinessObjects.Models;

namespace WpfApp_Assignment_SE173139_DoHuynhNguyenVu
{
    public partial class AssignUserToEventWindow : Window
    {
        private readonly IEventService eventService;
        private readonly IUserService userService;
        private readonly IUserEventService userEventService;

        public AssignUserToEventWindow(UserEvent userClass = null)
        {
            InitializeComponent();
            eventService = new EventService();
            userService = new UserService();
            userEventService = new UserEventService();

            this.LoadClasses();
            this.LoadEvents();
        }

        private void LoadClasses()
        {
            this.cbClasses.ItemsSource = this.eventService.GetAllEvents();
        }

        private void LoadEvents()
        {
            this.lbCustomers.ItemsSource = this.userService.GetUsersByRole((int)RoleName.Customer);
        }

        private void cbClasses_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
        }

        private void btnAssign_Click(object sender, RoutedEventArgs e)
        {
            if (this.cbClasses.SelectedItem == null)
            {
                MessageBox.Show("Please select a class!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Event selectedClass = this.cbClasses.SelectedItem as Event;

            List<User> selectedStudents = new List<User>();
            foreach (User student in lbCustomers.SelectedItems)
            {
                selectedStudents.Add(student);
            }

            if (selectedStudents.Count == 0)
            {
                MessageBox.Show("Please select at least one student to assign!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            foreach (User student in selectedStudents)
            {
                if (this.userEventService.GetUserEventByUserIdAndEventId(student.UserId, selectedClass.EventId) != null)
                {
                    MessageBox.Show($"The student {student.Name} has already been assigned to the class!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                UserEvent userClass = new UserEvent
                {
                    UserId = student.UserId,
                    EventId = selectedClass.EventId,
                };

               this.userEventService.AddUserEvent(userClass);
            }

            MessageBox.Show("Students have been successfully assigned to the class!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            UserEventManagementWindow userEventManagementWindow = new UserEventManagementWindow();
            userEventManagementWindow.Show();
            this.Close();
        }
    }
}
