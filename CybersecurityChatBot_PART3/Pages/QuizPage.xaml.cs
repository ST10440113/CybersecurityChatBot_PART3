using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CybersecurityChatBot_PART3.Pages
{
    public partial class QuizPage : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int qNum = 0;
        int i;
        int score = 0;
        string correctAnswer = "";

        public QuizPage()
        {
            InitializeComponent();
            StartGame();
           
        }

        private void AddBotMessage(string message)
        {
            ChatBox.Items.Add($"ChatBot: {message}");
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
           
            checkAnswer();
        }

        private void DisplayQuestion()
        {
            
            if (qNum < questionNumbers.Count)
            {
                i = questionNumbers[qNum];
            }
            else
            {
                return;
            }


            switch (i)
            {
                
                case 1:
                    ChatBox.Items.Add("Question 1: Phishing is the most common type of cyber attack");
                    ChatBox.Items.Add("A) True");
                    ChatBox.Items.Add("B) False");
                    
                    correctAnswer = "A";
                    break;
                case 2:
                    ChatBox.Items.Add("\n\nQuestion 2: Which of the following is NOT a strong password?");
                    ChatBox.Items.Add("A) P@ssw0rd123!");
                    ChatBox.Items.Add("B) 123456");
                    ChatBox.Items.Add("C) 9x!Qw#2Lp");
                    ChatBox.Items.Add("D) $ecureP@ss!");

                    correctAnswer = "B";
                    break;
                case 3:
                    ChatBox.Items.Add("\n\nQuestion 3: VPN stands for Virtual Private Network");
                    ChatBox.Items.Add("A) True");
                    ChatBox.Items.Add("B) False");
                    

                    correctAnswer = "A";
                    break;
                case 4:
                    ChatBox.Items.Add("\n\nQuestion 4: What is ransomware?");
                    ChatBox.Items.Add("A) A type of firewall");
                    ChatBox.Items.Add("B) A type of malware that encrypts files and demands payment");
                    ChatBox.Items.Add("C) A password manager");
                    ChatBox.Items.Add("D) A network protocol");
                    correctAnswer = "B";
                    break;
                case 5:
                    ChatBox.Items.Add("\n\nQuestion 5: Social engineering is a type of antivirus");
                    ChatBox.Items.Add("A) True");
                    ChatBox.Items.Add("B) False");
                    
                    correctAnswer = "A";
                    break;
                case 6:
                    ChatBox.Items.Add("\n\nQuestion 6: What is a DDoS attack?");
                    ChatBox.Items.Add("A) Distributed Denial of Service");
                    ChatBox.Items.Add("B) Data Download Over System");
                    ChatBox.Items.Add("C) Direct Data Output Service");
                    ChatBox.Items.Add("D) Digital Denial of Security");
                    correctAnswer = "A";
                    break;
                case 7:
                    ChatBox.Items.Add("\n\nQuestion 7: Which is a good practice for online security?");
                    ChatBox.Items.Add("A) Use the same password everywhere");
                    ChatBox.Items.Add("B) Share your password with friends");
                    ChatBox.Items.Add("C) Use two-factor authentication");
                    ChatBox.Items.Add("D) Click on all email links");
                    correctAnswer = "C";
                    break;
                case 8:
                    ChatBox.Items.Add("\n\nQuestion 8: What is a zero-day exploit?");
                    ChatBox.Items.Add("A) An attack on the first day of the month");
                    ChatBox.Items.Add("B) A vulnerability exploited before a fix is available");
                    ChatBox.Items.Add("C) A type of backup");
                    ChatBox.Items.Add("D) A firewall update");
                    correctAnswer = "B";
                    break;
                case 9:
                    ChatBox.Items.Add("\n\nQuestion 9: Which is a sign of a phishing email?");
                    ChatBox.Items.Add("A) Urgent request for personal info");
                    ChatBox.Items.Add("B) Email from a known contact");
                    ChatBox.Items.Add("C) No spelling errors");
                    ChatBox.Items.Add("D) Secure website link");
                    correctAnswer = "A";
                    break;
                case 10:
                    ChatBox.Items.Add("\n\nQuestion 10: What is multi-factor authentication?");
                    ChatBox.Items.Add("A) Using multiple devices at once");
                    ChatBox.Items.Add("B) Using more than one method to verify identity");
                    ChatBox.Items.Add("C) Changing passwords monthly");
                    ChatBox.Items.Add("D) Encrypting your files");
                    correctAnswer = "B";
                    break;
            }
        }

       
        public void checkAnswer()
        {
            
            
            string input = UserInput.Text.Trim().ToUpper();

            if (input == correctAnswer)
            {
                
                AddBotMessage("Correct!");
                score++;
            }
            else
            {
                AddBotMessage("Incorrect! The correct answer was: " + correctAnswer);
            }

            qNum++;
           

            if (qNum >= questionNumbers.Count)
            {
                if (score >= 5)
                {
                    AddBotMessage($"Your final score is: {score}/{questionNumbers.Count}\nNice Work!");
                }
                else
                {
                    AddBotMessage($"Your final score is: {score}/{questionNumbers.Count}\nBetter luck next time!");
                }


                AddBotMessage("Would you like to play again? (yes/no)");
                string option = UserInput.Text.Trim().ToLower();
                if (option == "yes")
                {
                    ResetGame();
                }
                else if (option == "no")
                {
                    AddBotMessage("Thank you for playing!");
                    return;
                }
                score = 0;
                qNum = 0;
                return;
                
                
            }
            NextQuestion();
        }

        private void ResetGame()
        {
            score = 0;
            qNum = 0;
            
            StartGame();
        }

        private void StartGame()
        {
            
            qNum = 0;
            score = 0;
           
            NextQuestion();
        }

        private void NextQuestion()
        {
            DisplayQuestion();
        }
    }
}