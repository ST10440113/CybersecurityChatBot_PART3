using System.IO;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CybersecurityChatBot_PART3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.ChatPage());  //Default page
        }

        private void GoToChatPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.ChatPage());
        }

        private void GoToLogPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.LogPage());
        }

        private void GoToQuizPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.QuizPage());
        }

        private void GoToTaskPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.TaskPage());
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
