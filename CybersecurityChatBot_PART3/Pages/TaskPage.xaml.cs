using System;
using System.Collections.Generic;
using System.IO;
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

namespace CybersecurityChatBot_PART3.Pages
{
    /// <summary>
    /// Interaction logic for TaskPage.xaml
    /// </summary>
    public partial class TaskPage : Page
    {
        static List<string> TaskList = new List<string>();
        public TaskPage()
        {
            InitializeComponent();
        }
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string taskName = TaskNameTextBox.Text;
            string description = DescriptionTextBox.Text;
            string reminder = ReminderBox.Text;

            string task = "\nTask Name: " + taskName + "\nDescription: " + description + "\nReminder: " + reminder;
            TaskList.Add(task);

            MessageBox.Show("Task Added!", "Task Addition Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            SaveTaskHistory();
        }

        private void DisplayTasks_Click(object sender, RoutedEventArgs e)
        {
            LoadTaskHistory();


            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Task History:");
            foreach (var task in TaskList)
            {
                sb.AppendLine(task);
            }

            MessageBox.Show(sb.ToString(), "Tasks Displayed", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void SaveTaskHistory()
        {
            string filePath = "tasks.txt";

            File.WriteAllLines(filePath, TaskList);


        }
        private void LoadTaskHistory()
        {
            string filePath = "tasks.txt";
            if (File.Exists(filePath))
            {
                TaskList = File.ReadAllLines(filePath).ToList();
            }
            else
            {
                TaskList = new List<string>();
            }
        }


    }
}
