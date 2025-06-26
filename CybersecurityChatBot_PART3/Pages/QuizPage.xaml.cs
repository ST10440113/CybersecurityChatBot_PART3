using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CybersecurityChatBot_PART3.Pages
{
    /// <summary>
    /// Interaction logic for QuizPage.xaml
    /// </summary>
    public partial class QuizPage : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int qNum = 0;
        int i;
        int score = 0;

        public QuizPage()
        {
            InitializeComponent();
            StartGame();
        }

        public void checkAnswer(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;

            bool isCorrect = senderButton.Tag.ToString() == "correct";
            if (isCorrect==true)
            {
                score++;
                MessageBox.Show("Correct!", "Quiz", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                string correctAnswer = "";


                if ( ans1.Tag == "correct") 
                correctAnswer = ans1.Content.ToString();

                else if (ans2.Tag == "correct") 
                correctAnswer = ans2.Content.ToString();

                else if (ans3.Tag == "correct") 
                correctAnswer = ans3.Content.ToString();

                else if (ans4.Tag == "correct") 
                correctAnswer = ans4.Content.ToString();

                MessageBox.Show("Incorrect! The correct answer was: " + correctAnswer, "Quiz", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            qNum++;
            scoreText.Content = $"Score: {score}/{questionNumbers.Count}";

            if (qNum >= questionNumbers.Count && score >= 5)
            {
                MessageBox.Show($" Your final is score: {score}/{questionNumbers.Count}" + "\nNice Work!", "Quiz Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                ResetGame();
                return;
            }
            else if (qNum >= questionNumbers.Count && score < 5)
            {
                MessageBox.Show($" Your final is score: {score}/{questionNumbers.Count}" + "\nBetter luck next time!", "Quiz Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                ResetGame();
                return;
            }
            NextQuestion();
        }

        private void ResetGame()
        {
            score = 0;
            qNum = 0;
            scoreText.Content = $"Score: {score}/{questionNumbers.Count}";
            StartGame();
        }

        private void StartGame()
        {
            var randomList = questionNumbers.OrderBy(a => Guid.NewGuid()).ToList();
            questionNumbers = randomList; 
            qNum = 0;
            score = 0;
            scoreText.Content = $"Score: {score}/{questionNumbers.Count}";
            NextQuestion();
        }

        private void NextQuestion()
        {
            if (qNum < questionNumbers.Count)
            {
                i = questionNumbers[qNum];
            }
           
            foreach (var x in myCanvas.Children.OfType<Button>())
            {
                x.Tag = "0";
                x.Background = Brushes.LightGray;
            }

           
            switch (i)
            {
                case 1:
                    txtQuestion.Text = "What is the most common type of cyber attack?";
                    ans1.Content = "Phishing";
                    ans2.Content = "DDoS";
                    ans3.Content = "Ransomware";
                    ans4.Content = "SQL Injection";
                    ans1.Tag = "correct"; 
                    
                    break;
                case 2:
                    txtQuestion.Text = "Antivirus software guarantees complete protection against all cyber threats";
                    ans1.Content = "True";
                    ans2.Content = "False";
                    ans3.Content = "Sometimes";
                    ans4.Content = "only on Windows";
                    ans2.Tag = "correct"; 
                   
                    break;
                case 3:
                    txtQuestion.Text = "What is the purpose of a firewall?";
                    ans1.Content = "To store passwords";
                    ans2.Content = "To speed up internet connection";
                    ans3.Content = "To encrypt data";
                    ans4.Content = "To block unauthorized access";
                    ans4.Tag = "correct"; 
                    break;
                case 4:
                    txtQuestion.Text = "What is social engineering?";
                    ans1.Content = "Manipulating people to divulge confidential information";
                    ans2.Content = "A type of malware";
                    ans3.Content = "A network protocol";
                    ans4.Content = "A programming language";
                    ans1.Tag = "correct"; 
                    break;
                case 5:
                    txtQuestion.Text = "What is multi-factor authentication?";
                    ans1.Content = "A security process that requires multiple forms of identification";
                    ans2.Content = "A type of encryption";
                    ans3.Content = "A method to speed up login processes";
                    ans4.Content = "A way to bypass firewalls";
                    ans1.Tag = "correct"; 
                    break;
                case 6:
                    txtQuestion.Text = "What is ransomware?";
                    ans1.Content = "Malware that encrypts files and demands payment for decryption";
                    ans2.Content = "A type of phishing attack";
                    ans3.Content = "A network security protocol";
                    ans4.Content = "A method to speed up internet connection";
                    ans1.Tag = "correct"; 
                    break;
                case 7:
                    txtQuestion.Text = "A strong password is a long, unique mix of letters, numbers, and symbols ";
                    ans1.Content = "True";
                    ans2.Content = "Depends on the application";
                    ans3.Content = "False";
                    ans4.Content = "Just letters are enough";
                    ans1.Tag = "correct"; 
                    break;
                case 8:
                    txtQuestion.Text = "What is phishing?";
                    ans1.Content = "A type of fishing";
                    ans2.Content = "A cyber attack to trick users into giving up information";
                    ans3.Content = "A network protocol";
                    ans4.Content = "A type of firewall";
                    ans2.Tag = "correct"; 
                    break;
                case 9:
                    txtQuestion.Text = "What is a DDoS attack?";
                    ans1.Content = "A Distributed Denial of Service attack that overwhelms a network with traffic";
                    ans2.Content = "A type of phishing attack";
                    ans3.Content = "A method to speed up internet connection";
                    ans4.Content = "A network security protocol";
                    ans1.Tag = "correct"; 
                    break;
                case 10:
                    txtQuestion.Text = "What is a zero-day exploit?";
                    ans1.Content = "A vulnerability that is exploited before the vendor releases a fix";
                    ans2.Content = "A type of phishing attack";
                    ans3.Content = "A method to speed up internet connection";
                    ans4.Content = "A network security protocol";
                    ans1.Tag = "correct"; 
                    break;
                
            }
        }
    }
}