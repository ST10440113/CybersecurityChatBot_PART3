The Cybersecurity Awareness Chatbot WPF App
-----------------------------------
1. MainWindow
------------------
The interface in the MainWindow involves navigation in the form of a side bar. Each button in the side bar allows the user to access diferent pages or sections of the app.
The different pages are the ChatPage, the QuizPage, the TaskPage and, the LogPage.


2. Chatbot Page
-----------------
This is basically where the chatbot structure from part one and two, is represented as a GUI rather than in a console window.
The interface shows a black screen or sorts where the conversation between the user and the chatbot will take place. 
Below that, it shows a text box for where the user is going to enter their input and a button next to it that says "Send".
This button will be used to allow the user to interact with the chatbot.
The chatbot works by playing an audible welcome message and then displays an ASCII art logo for the chatbot. 
The user is then prompted for their name so that the chatbot can use it when it responds to give a more friendly appeal to the conversation.
The chatbot then greets the user using the name that the user inputed. 
This is saved to a variable called userName. 
Then, the chatbot displays a 'security tip of the day' which is chosen randomly from a list of tips stored in a method called DisplayTipOfTheDay() . 
Beneath the security tip, the chatbot also displays a list of cybersecurity topics that the user will be able to ask about. 
The user can now enter a question or statement for the chatbot can answer to. 
If the user asks about a topic that was displayed in the previous list, the chatbot will display a response that is stored in a method called HandleUserQuery() . 
If the user does not ask about a topic that was displayed in the previous list, the chatbot will display a message telling the user that it did not understand and that they can enter the word 'help' to see what the user can ask about.
However, before the error message displays, the chatbot will display a message saying that it will remember what the user asked about for another conversation, as this will help the conversation feel more natural.
Everything that the chatbot and the user says in a conversation is saved to a text document so that the chatbot history will be saved for referencing in for another conversation.
If the user enters a topic that is from the list of topics that chatbot can answer and they have asked about this topic in before, 
the chatbot will give its predetermined response from HandleUserQuery() after the chatbot mentions that they have had previous interest in this topic before 
If the user enters the word 'exit' or 'quit', the program will end.



2. Quiz Page
---------------
This is a mini game that tests the user on various cybersecurity topics.
It has 10 questions which has a mix of true/false questions and multiple choice questions
As the use playes the game, their score gets tracked to be displayed at the end of the quiz
If the  final score is greater than or equal to 5, a message will be displayed alongside the score that says "Nice Work!"
If the final score is less than 5, then a message will be displayed alongside the score that says "Better luck next time!"
Each time the user gets an answer right, a message will be displayed below that says "Correct!"
Each time the user gets an answer wrong, a message will be displayed below that says "Incorrect!", and tells the user what was the correct answer was, as instant feedback
The interface for this page is the same as the chatbot page




3. Task Page
---------------
The ASII art is displayed first, then the user can start interacting with the chatbot
This is where the user can add tasks, reminders and descriptions for the tasks,through different commands.
The user can also use  commands, which are specified in the interface, to view all of the tasks, reminders and descriptions they have set.
It is implemented in the chatbot structure.
The interface for this page is the same as the chatbot page



4. Activity Log page
---------------------
This page is where the user will be able to see all of their recent activities throughout the application, such as their chatbot conversations or details of the tasks they have added.
The user will be able to view their recent activities by typing commands that are specified on the interface.
It is implemented in the chatbot structure.
The interface for this page is the same as the chatbot page
