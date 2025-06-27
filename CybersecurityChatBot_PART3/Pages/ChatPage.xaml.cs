﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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
    /// Interaction logic for ChatPage.xaml
    /// </summary>
    public partial class ChatPage : Page
    {

        static List<string> chatHistory = new List<string>();
       
        static Random random = new Random();
        private string userName = string.Empty;

      
        public ChatPage()
        {
            InitializeComponent();
            DisplayAsciiLogo();
            PlayGreetingAudio("Recording.wav");
            AddBotMessage("Welcome to your Personal Cybersecurity Awareness ChatBot! I'm here to help you stay safe online.");
            DisplayTipOfTheDay();
            AddBotMessage("What's your name?");
        }


         
        private void Send_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(input)) return;
            AddUserMessage(input);
            UserInput.Clear();

            if (string.IsNullOrEmpty(userName))
            {
                userName = input;
                AddBotMessage($"Nice to meet you, {userName}! You can ask me about:" +
                    $"\n" +
                    $"\n-Cybersecurity" +
                    $"\n-Phishing" +
                    $"\n-Malware" +
                    $"\n-Ransomware" +
                    $"\n-Firewall" +
                    $"\n-Antivirus" +
                    $"\n-Password" +
                    $"\n-Social Engineering" +
                    $"\n-Data Breaches" +
                    $"\n-Multi-Factor Authentication" +
                    $"\n" +
                    $"\nIf you wish to leave, you can enter the word 'exit' or 'quit'" +
                    $"\nIf you need a reminder about what you can ask about, type the word 'help'");
                return;
            }

            if (input == "exit" || input == "quit")
            {
                AddBotMessage(" Stay safe and think before you click online. Goodbye!");
                SaveChatHistory();
                Application.Current.Shutdown();
                return;
            }
            SaveChatHistory();
            CompareChatHistoryToInput(input);
            HandleUserQuery(input, userName);

        }



        private void AddBotMessage(string message)
        {
           
            ChatBox.Items.Add($"ChatBot: {message}");
            chatHistory.Add($"ChatBot: {message}");
            SaveChatHistory();


        }

       
        private void AddUserMessage(string message)
        {
            ChatBox.Items.Add($"{userName}: {message}");
            chatHistory.Add($"{userName}: {message}");
            SaveChatHistory();

        }

        public void DisplayTipOfTheDay()
        {
            string[] tips = new string[]
            {
                "Always use strong and unique passwords for each of your accounts.",
                "Enable two-factor authentication wherever possible.",
                "Be cautious of unsolicited emails and messages asking for personal information.",
                "Keep your software and operating system up to date.",
                "Regularly back up your important data to an external drive or cloud storage."
            };
            int tipIndex = random.Next(tips.Length);


            ChatBox.Items.Add($"\nCybersecurity Tip of the Day: {tips[tipIndex]}");


        }


        private void DisplayAsciiLogo()
        {
            string logo = @"
                                                                                                                                                                  
                                                                                                                                                                  
  ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______ 
 /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/ 
                                                                                                                                                                  
                                                                                                                                                                  
_________        ___.                                                  .__  __                _____                                                                 
\_   ___ \___.__.\_ |__   ___________  ______ ____   ____  __ _________|__|/  |_ ___.__.     /  _  \__  _  _______ _______   ____   ____   ____   ______ ______     
/    \  \<   |  | | __ \_/ __ \_  __ \/  ___// __ \_/ ___\|  |  \_  __ \  \   __<   |  |    /  /_\  \ \/ \/ /\__  \\_  __ \_/ __ \ /    \_/ __ \ /  ___//  ___/     
\     \___\___  | | \_\ \  ___/|  | \/\___ \\  ___/\  \___|  |  /|  | \/  ||  |  \___  |   /    |    \     /  / __ \|  | \/\  ___/|   |  \  ___/ \___ \ \___ \      
 \______  / ____| |___  /\___  >__|  /____  >\___  >\___  >____/ |__|  |__||__|  / ____|   \____|__  /\/\_/  (____  /__|    \___  >___|  /\___  >____  >____  >     
        \/\/          \/     \/           \/     \/     \/                       \/              \/             \/            \/     \/     \/     \/     \/      
                                                                                                                                                                  
                                                                                                                                                                  
  ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______   ______ 
 /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/  /_____/ 
                                                                                                                                                                  
                                                                                                                                                                  

";
            ChatBox.Items.Add(logo);
        }

        private void PlayGreetingAudio(string filePath)
        {
            try
            {
                string fullPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), filePath);  //gets the full path

                if (File.Exists(fullPath))
                {
                    SoundPlayer player = new SoundPlayer(fullPath);
                    player.PlaySync();  //Play the audio synchronously
                }
                else
                {

                    AddBotMessage($"Error: The file '{filePath}' was not found at the specified location. ");

                }
            }
            catch (Exception ex)
            {

                AddBotMessage($"Error playing audio: {ex.Message}");

            }
        }
        public void CompareChatHistoryToInput(string input)
        {
            string filePath = "chat_history.txt";
            if (!File.Exists(filePath) || string.IsNullOrWhiteSpace(input))
                return;

            string[] history = File.ReadAllLines(filePath);
            bool found = false;

            foreach (string line in history)
            {
                if (line.ToLower().Contains(input.ToLower()))
                {
                    
                    string chatHistoryMatch = $"Since you have mentioned '{input}' in our previous conversation, you will be interested to know that";
                    AddBotMessage($"Chatbot: {chatHistoryMatch}\n");
                    
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                
                string chatHistoryNoMatch = $"Since you're interested in {input}' I'll remember it for our next conversation";
                AddBotMessage($"Chatbot: {chatHistoryNoMatch}\n");
               

            }
        }
        public void SaveChatHistory()
        {
            string filePath = "chat_history.txt";

            File.WriteAllLines(filePath, chatHistory);

           
           
        }
        public void HandleUserQuery(string input, string userName)
        {
            string preparedInput = input.Trim().ToLower();
            Dictionary<string, string> responses = new Dictionary<string, string>
            {
            { "cybersecurity", "Cybersecurity is the practice of protecting systems, networks, and programs from digital attacks." },
            { "phishing", "Phishing is a type of cyber attack where attackers impersonate legitimate organizations to steal sensitive information." },
            { "malware", "Malware is malicious software designed to harm or exploit any programmable device or network." },
            { "ransomware", "Ransomware is a type of malware that encrypts files and demands payment for the decryption key." },
            { "firewall", "A firewall is a network security system that monitors and controls incoming and outgoing network traffic." },
            { "antivirus", "Antivirus software is designed to detect and destroy computer viruses and other malicious software." },
            { "password", "A strong password should be at least 12 characters long and include a mix of letters, numbers, and symbols." },
            { "social engineering", "Social engineering is the psychological manipulation of people into performing actions or divulging confidential information." },
            { "data breaches", "A data breach is an incident where sensitive, protected, or confidential data is accessed or disclosed without authorization." },
            { "multi-factor authentication", "Multi-factor authentication (MFA) adds an extra layer of security by requiring two or more verification methods to access an account." },
            { "How are you?"," I'm good thanks. How can I assist you today?" },
            { "What's your purpose?","I'm here to help you stay safe online by giving cybersecurity advice" },
            { "What can I ask you about?", "You can ask me about cybersecurity, phishing,malware,ransomeware,firewall,antiviruses, passwords ,and social engineering" },
            { "help", "You can ask about cybersecurity, phishing,malware,ransomeware,firewall,antiviruses, passwords ,and social engineering" },
            
//cybersecurity follow up questions
{ "What are the most common cyber threats", "The most common cyber threats include phishing, malware, ransomware, social engineering, and denial-of-service attacks." },
{ "How can I protect my personal information online?", "Protect your personal information by using strong passwords, enabling two-factor authentication, avoiding suspicious links, and keeping your software updated." },
{ "What is the importance of cybersecurity in daily life?", "Cybersecurity is important to protect your personal data, financial information, and privacy from cybercriminals and online threats." },

//cybersecurity statements with emotion
{ "I feel overwhelmed by cybersecurity threats", "It's understandable to feel overwhelmed. Cybersecurity can be complex, but taking small steps can help you feel more secure." },
{ "I'm worried about my online privacy", "Your concerns are valid. Online privacy is crucial, and there are many ways to enhance it." },
{ "I don't know where to start with cybersecurity", "Starting with the basics is a great approach. Focus on strong passwords and being cautious with emails." },



//phishing follow up questions
{ "How can I recognize a phishing email", "Phishing emails often have urgent messages, suspicious links, spelling errors, and ask for sensitive information. Always verify the sender's address." },
{ "What should I do if I clicked a phishing link", "If you clicked a phishing link, disconnect from the internet, run a security scan, change your passwords, and monitor your accounts for suspicious activity." },
{ "Are there tools to help prevent phishing attacks", "Yes, use email filters, browser security extensions, and keep your antivirus software updated to help prevent phishing attacks." },

//phishing statements with emotion
{ "I feel anxious about phishing attacks", "It's normal to feel anxious. Staying informed and cautious can help you feel more secure." },
{ "I'm frustrated with all the phishing emails I receive", "I understand your frustration. Phishing attacks are common, but being vigilant can help you avoid them." },
{ "I don't trust emails anymore", "It's wise to be cautious with emails. Always verify the sender and avoid clicking on suspicious links." },



//malware follow up questions 
{ "What are the signs of a malware infection", "Signs of malware infection include slow performance, unexpected pop-ups, new toolbars, and programs opening or closing automatically." },
{ "How do I remove malware from my computer", "To remove malware, run a full scan with updated antivirus software and follow its removal instructions. In severe cases, seek professional help." },
{ "What types of malware exist", "Common types of malware include viruses, worms, trojans, ransomware, spyware, and adware." },

//malware statements with emotion
{ "I'm scared of getting malware on my computer", "It's understandable to be scared. Regular updates and antivirus software can help protect you." },
{ "I feel helpless against malware attacks", "You are not helpless. Educating yourself and using security tools can empower you." },
{ "I don't know how to check for malware", "You can use antivirus software to scan your system for malware. Many programs offer free versions." },




//ransomware follow up questions
{ "What should I do if my files are encrypted by ransomware", "Disconnect from the network, do not pay the ransom, and seek professional help. Restore files from backups if available." },
{ "How can I prevent ransomware attacks", "Prevent ransomware by keeping backups, updating software, avoiding suspicious links, and using strong security tools." },
{ "Should I pay the ransom if infected", "It is not recommended to pay the ransom, as it does not guarantee file recovery and encourages further attacks." },

//ransomware statements with emotion
{ "I feel hopeless if I get ransomware", "It's understandable to feel hopeless. Regular backups and security measures can help you recover from such attacks." },
{ "I'm worried about losing my files to ransomware", "Your concern is valid. Regular backups and security practices can help protect your files." },
{ "I don't know how to back up my data", "Backing up data can be done using external drives or cloud storage services. It's a good practice to do it regularly." },



//firewall follow up questions
{ "What is the difference between hardware and software firewalls", "Hardware firewalls protect your entire network, while software firewalls protect individual devices. Both are important for layered security." },
{ "How do I configure a firewall", "Configure a firewall by following the manufacturer's instructions, blocking unnecessary ports, and allowing only trusted applications." },
{ "Can a firewall block all cyber attacks", "A firewall is a strong defense, but it cannot block all attacks. Use it alongside other security measures for best protection." },

//firewall statements with emotion
{ "I feel confused about firewalls", "It's normal to feel confused. Firewalls are complex, but they are essential for network security." },
{ "I'm worried my firewall isn't enough", "Your concern is valid. A firewall is a crucial part of security, but it should be combined with other measures." },
{ "I don't know how to check if my firewall is working", "You can check your firewall settings in your operating system's security settings or use online tools to test its effectiveness." },



//antivirus follow up questions
{ "How often should I run antivirus scans", "Run antivirus scans at least once a week and enable real-time protection for continuous monitoring." },
{ "What features should I look for in antivirus software", "Look for real-time protection, automatic updates, malware removal, and web protection features in antivirus software." },
{ "Can antivirus software detect all threats", "No antivirus can detect all threats, but keeping it updated and using safe browsing habits greatly reduces your risk." },

//antivirus statements with emotion
{ "I feel overwhelmed by antivirus options", "It's understandable to feel overwhelmed. Research and reviews can help you choose the right antivirus for your needs." },
{ "I'm worried my antivirus isn't enough", "Your concern is valid. Regular updates and safe browsing habits are essential for comprehensive protection." },
{ "I don't know how to update my antivirus software", "Most antivirus programs have an automatic update feature. You can also check for updates in the software settings." },



//password follow up questions
{ "How do I create a strong password", "Create a strong password by using at least 12 characters, mixing uppercase, lowercase, numbers, and symbols, and avoiding common words." },
{ "What is a password manager", "A password manager is a tool that securely stores and manages your passwords, helping you use unique passwords for every account." },
{ "How often should I change my passwords", "Change your passwords regularly, especially if you suspect a breach or if the service recommends it." },

//password statements with emotion
{ "I feel stressed about remembering passwords", "It's normal to feel stressed. Using a password manager can help you manage and remember your passwords." },
{ "I'm worried about my password security", "Your concern is valid. Using strong, unique passwords and enabling two-factor authentication can enhance security." },
{ "I don't know how to create a strong password", "Creating a strong password involves using a mix of characters and avoiding easily guessable information." },



//social engineering follow up questions
{ "What are common social engineering techniques","Common techniques include phishing, pretexting, baiting, and impersonation to trick people into revealing information." },
{ "How can I avoid falling victim to social engineering","Be cautious with unsolicited requests, verify identities, and never share sensitive information without confirmation." },
{ "Can social engineering happen over the phone","Yes, attackers often use phone calls to impersonate trusted individuals and extract confidential information." },

 //social engineering statements with emotion
 { "I feel vulnerable to social engineering attacks", "It's normal to feel vulnerable. Awareness and caution can help you avoid falling victim." },
 { "I'm worried about sharing personal information", "Your concern is valid. Always verify the identity of the person requesting information." },
 { "I don't know how to spot social engineering attempts", "Look for unusual requests, urgency, and verify the source before sharing any information." },

//data breach follow up questions
{ "How can I protect myself from data breaches?", "To protect yourself, use strong passwords, enable two-factor authentication, and monitor your accounts for suspicious activity." },
{ "What should I do if my data is breached?", "If your data is breached, change your passwords immediately, monitor your accounts for unusual activity, and consider credit monitoring services." },
{ "What are the consequences of a data breach?", "The consequences of a data breach can include financial loss, identity theft, reputational damage, and legal penalties for organizations." },

//data breach statements with emotion
{ "I feel violated if my data is breached", "It's completely understandable to feel violated. Data breaches can have serious implications, and it's important to take steps to protect yourself." },
{ "I'm worried about my personal information being exposed", "Your concern is valid. Data breaches can expose sensitive information, so it's crucial to stay vigilant and take preventive measures." },
{ "I don't know how to check if my data has been breached", "You can check if your data has been breached by using services which allow you to see if your email or personal information has been compromised." },

//MFA follow up questions
{ "What are examples of multi-factor authentication", "Examples of MFA include receiving a code via SMS, using an authenticator app, or providing a fingerprint or facial recognition in addition to your password." },
{ "How do I set up multi-factor authentication", "You can set up MFA in your account security settings, usually by linking your phone, installing an authenticator app, or registering a hardware token." },
{ "How does multi-factor authentication protect my accounts", "MFA protects your accounts by requiring more than just a password, making it much harder for attackers to gain access even if your password is stolen." },

//MFA statements with emotion
{ "I feel confused about multi-factor authentication", "It's normal to feel confused at first. MFA just means using more than one way to prove your identity, and it gets easier with practice." },
{ "I'm worried about losing access to my MFA device", "That's a valid concern. Most services provide backup codes or alternative methods, so be sure to set those up and keep them safe." },
{ "I feel overwhelmed by setting up multi-factor authentication", "Setting up MFA can seem overwhelming, but most services guide you step by step. Taking it one step at a time can help." },

  };


            Dictionary<string, List<string>> keywordGroups = new Dictionary<string, List<string>>
{
{ "cybersecurity", new List<string> { "cyber security", "online safety", "information security", "cyber attack" } },
{ "phishing", new List<string> { "phishing emails", "phishing", "fake emails", "email scam", "spear phishing", "phishing attack" } },
{ "malware", new List<string> { "malicious software", "virus", "trojan", "worm", "spyware", "adware", "malware infection" } },
{ "ransomware", new List<string> { "ransomware attack", "encrypted files", "pay ransom", "ransom demand" } },
{ "firewall", new List<string> { "network firewall", "firewall protection", "block traffic", "security firewall" } },
{ "antivirus", new List<string> { "antivirus software", "virus protection", "antimalware", "scan for viruses" } },
{ "password", new List<string> { "strong password", "password security", "password manager", "password protection" } },
{ "social engineering", new List<string> { "social engineering attack", "manipulation", "pretexting", "baiting", "impersonation" } },
{ "data breaches", new List<string> { "data breach", "personal data exposure", "data leak", "information theft" } },
{ "multi-factor authentication", new List<string> { "MFA", "two-factor authentication", "2FA", "authentication app", "security token" } },

//cybersecurity follow up question synonyms
{ "What are the most common cyber threats", new List<string> { "common cyber threats", "most common cyber threats","cyber threats" } },
{ "How can I protect my personal information online?", new List<string> { "protect personal information", "protect my personal information" } },
{ "What is the importance of cybersecurity in daily life?", new List<string> { "importance of cybersecurity", "importance of cyber security" } },

//cybersecurity emotional statement synonyms
{ "I feel overwhelmed by cybersecurity threats", new List<string> { "overwhelmed by cybersecurity threats", "overwhelmed by cyber threats" } },
{ "I'm worried about my online privacy", new List<string> { "worried about online privacy", "concerned about online privacy" } },
{ "I don't know where to start with cybersecurity", new List<string> { "start with cybersecurity", "begin with cybersecurity" } },



//phishing follow up question synonyms
{ "How can I recognize a phishing email", new List<string> { "recognize phishing email", "phishing email signs" } },
{ "What should I do if I clicked a phishing link", new List<string> { "clicked phishing link", "clicked on a phishing link" } },
{ "Are there tools to help prevent phishing attacks", new List<string> { "tools to prevent phishing", "prevent phishing attacks" } },

//phishing emotional statement synonyms
{ "I feel anxious about phishing attacks", new List<string> { "anxious about phishing attacks", "worried about phishing attacks" } },
{ "I'm frustrated with all the phishing emails I receive", new List<string> { "frustrated with phishing emails", "tired of phishing emails" } },
{ "I don't trust emails anymore", new List<string> { "don't trust emails", "suspicious of emails" } },



//malware follow up question synonyms
{ "What are the signs of a malware infection", new List<string> { "signs of malware infection", "malware infection signs" } },
{ "How do I remove malware from my computer", new List<string> { "remove malware from computer", "remove malware" } },
{ "What types of malware exist", new List<string> { "types of malware", "different types of malware" } },

//malware emotional statement synonyms
{ "I'm scared of getting malware on my computer", new List<string> { "scared of malware", "worried about malware" } },
{ "I feel helpless against malware attacks", new List<string> { "helpless against malware", "powerless against malware" } },
{ "I don't know how to check for malware", new List<string> { "check for malware", "scan for malware" } },



//ransomware follow up question synonyms
{ "What should I do if my files are encrypted by ransomware", new List<string> { "files encrypted by ransomware", "ransomware encrypted files" } },
{ "How can I prevent ransomware attacks", new List<string> { "prevent ransomware attacks", "ransomware prevention" } },
{ "Should I pay the ransom if infected", new List<string> { "pay ransom if infected", "pay ransom" } },

//ransomware emotional statement synonyms
{ "I feel hopeless if I get ransomware", new List<string> { "hopeless about ransomware", "worried about ransomware" } },
{ "I'm worried about losing my files to ransomware", new List<string> { "worried about losing files", "concerned about losing files" } },
{ "I don't know how to back up my data", new List<string> { "back up data", "how to back up data" } },




//firewall follow up question synonyms
{ "What is the difference between hardware and software firewalls", new List<string> { "difference between hardware and software firewalls", "hardware vs software firewall" } },
{ "How do I configure a firewall", new List<string> { "configure a firewall", "firewall configuration" } },
{ "Can a firewall block all cyber attacks", new List<string> { "firewall block all cyber attacks", "firewall protection" } },

//firewall emotional statement synonyms
{ "I feel confused about firewalls", new List<string> { "confused about firewalls", "uncertain about firewalls" } },
{ "I'm worried my firewall isn't enough", new List<string> { "worried about firewall", "concerned about firewall" } },
{ "I don't know how to check if my firewall is working", new List<string> { "check if firewall is working", "test firewall" } },



//antivirus follow up question synonyms
{ "How often should I run antivirus scans", new List<string> { "run antivirus scans", "antivirus scan frequency" } },
{ "What features should I look for in antivirus software", new List<string> { "features of antivirus software", "antivirus software features" } },
{ "Can antivirus software detect all threats", new List<string> { "antivirus detect all threats", "antivirus software detection" } },

//antivirus emotional statement synonyms
{ "I feel overwhelmed by antivirus options", new List<string> { "overwhelmed by antivirus", "confused about antivirus options" } },
{ "I'm worried my antivirus isn't enough", new List<string> { "worried about antivirus", "concerned about antivirus" } },
{ "I don't know how to update my antivirus software", new List<string> { "update antivirus software", "how to update antivirus" } },



//password follow up question synonyms
{ "How do I create a strong password", new List<string> { "create strong password", "strong password tips" } },
{ "What is a password manager", new List<string> { "password manager", "what is a password manager" } },
{ "How often should I change my passwords", new List<string> { "change passwords frequency", "how often to change passwords" } },

//password emotional statement synonyms
{ "I feel stressed about remembering passwords", new List<string> { "stressed about passwords", "worried about remembering passwords" } },
{ "I'm worried about my password security", new List<string> { "worried about password security", "concerned about password security" } },
{ "I don't know how to create a strong password", new List<string> { "create strong password", "how to create strong password" } },



//social engineering follow up question synonyms

{ "What are common social engineering techniques", new List<string> { "common social engineering techniques", "social engineering techniques" } },
{ "How can I avoid falling victim to social engineering", new List<string> { "avoid social engineering", "prevent social engineering" } },
{ "Can social engineering happen over the phone", new List<string> { "social engineering over the phone", "phone social engineering" } },

//social engineering emotional statement synonyms
{ "I feel vulnerable to social engineering attacks", new List<string> { "vulnerable to social engineering", "worried about social engineering" } },
{ "I'm worried about sharing personal information", new List<string> { "worried about sharing information", "concerned about sharing information" } },
{ "I don't know how to spot social engineering attempts", new List<string> { "spot social engineering", "identify social engineering" } },

//data breach follow up question synonyms
{ "How can I protect myself from data breaches", new List<string> { "protect from data breaches", "data breach protection" } },
{ "What should I do if my data is breached", new List<string> { "data breach response", "what to do if data is breached" } },
{ "What are the consequences of a data breach", new List<string> { "consequences of data breach", "data breach impact" } },

//data breach emotional statement synonyms
{ "I feel violated if my data is breached", new List<string> { "violated by data breach", "feel violated data breach", "data breach makes me feel violated" } },
{ "I'm worried about my personal information being exposed", new List<string> { "worried about personal information exposure", "concerned about personal data exposure", "afraid my data is exposed" } },
{ "I don't know how to check if my data has been breached", new List<string> { "don't know if data breached", "how to check data breach", "unsure if my data is breached" } },


//MFA follow up question synonyms
{ "What are examples of multi-factor authentication", new List<string> { "examples of multi-factor authentication", "MFA examples" } },
{ "How do I set up multi-factor authentication", new List<string> { "set up multi-factor authentication", "how to set up MFA" } },
{ "How does multi-factor authentication protect my accounts", new List<string> { "MFA account protection", "multi-factor authentication security" } },

//MFA emotional statement synonyms
{ "I feel confused about multi-factor authentication", new List<string> { "confused about MFA", "uncertain about multi-factor authentication" } },
{ "I'm worried about losing access to my MFA device", new List<string> { "worried about MFA device", "concerned about losing MFA access" } },
{ "I feel overwhelmed by setting up multi-factor authentication", new List<string> { "overwhelmed by MFA setup", "setting up multi-factor authentication is overwhelming" } }


};
            bool foundResponse = false;
            chatHistory.Add($"{userName}: {input}");


            foreach (var entry in responses)
            {
                if (string.Equals(preparedInput, entry.Key, StringComparison.OrdinalIgnoreCase))
                {
                    ChatBox.Items.Add(entry.Value);
                    foundResponse = true;
                    break;
                }
            }


            if (!foundResponse)
            {
                foreach (var entry in responses)
                {
                    if (preparedInput.Contains(entry.Key))
                    {
                        ChatBox.Items.Add(entry.Value);
                        foundResponse = true;
                        break;
                    }
                }
            }


            if (!foundResponse)
            {
                foreach (var group in keywordGroups)
                {
                    foreach (var synonym in group.Value)
                    {
                        if (preparedInput.Contains(synonym.ToLower()))
                        {
                            ChatBox.Items.Add(responses[group.Key]);
                            foundResponse = true;
                            break;
                        }
                    }
                    if (foundResponse) break;
                }
            }


            if (!foundResponse)
            {
                ChatBox.Items.Add("Sorry, I don't understand. Type 'help' to see what you can ask.");
            }
        }

    }
}
