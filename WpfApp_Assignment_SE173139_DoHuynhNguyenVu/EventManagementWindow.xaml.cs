using BusinessObjects.Models;
using Microsoft.Win32;
using Services;
using Services.Interfaces;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_Assignment_SE173139_DoHuynhNguyenVu
{
    public partial class EventManagementWindow : Window
    {
        private readonly IEventService eventService;
        private Event? selectedEvent;

        public EventManagementWindow()
        {
            InitializeComponent();
            eventService = new EventService();
            LoadEventData();
        }

        private void LoadEventData()
        {
            dtgEvents.ItemsSource = eventService.GetAllEvents();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgEvents.SelectedItem == null)
                return;

            selectedEvent = dtgEvents.SelectedItem as Event;
            if (selectedEvent == null)
                return;

            txtEventName.Text = selectedEvent.EventName;
            txtLocation.Text = selectedEvent.Location;
            txtImageUrl.Text = selectedEvent.ImageUrl;
        }

        private void btnUploadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                string imagesFolder = Path.Combine(projectPath, "Images");

                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }

                string imageName = Path.GetFileName(openFileDialog.FileName);
                string destFilePath = Path.Combine(imagesFolder, imageName);
                File.Copy(openFileDialog.FileName, destFilePath, true);

                txtImageUrl.Text = destFilePath;
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEventName.Text) || string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please provide all event details!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Event newEvent = new Event
            {
                EventName = txtEventName.Text,
                Location = txtLocation.Text,
                ImageUrl = txtImageUrl.Text,
                CreatedAt = DateTime.Now // Setting CreatedAt to now
            };

            eventService.AddEvent(newEvent);
            LoadEventData();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (selectedEvent == null)
            {
                MessageBox.Show("Please select an event to update!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Event updatedEvent = eventService.GetEventById(this.selectedEvent.EventId);
            updatedEvent.EventName = txtEventName.Text;
            updatedEvent.Location = txtLocation.Text;
            updatedEvent.ImageUrl = txtImageUrl.Text;

            eventService.UpdateEvent(updatedEvent);
            LoadEventData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedEvent == null)
            {
                MessageBox.Show("Please select an event to delete!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this event?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                eventService.DeleteEvent(selectedEvent.EventId);
                LoadEventData();
                ResetData();
            }
        }

        private void ResetData()
        {
            selectedEvent = null;
            txtEventName.Text = string.Empty;
            txtLocation.Text = string.Empty;
            txtImageUrl.Text = string.Empty;
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }
    }
}
