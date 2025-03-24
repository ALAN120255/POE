using System;
using System.Linq;
using POEPart1;

namespace POEDraft
{
    public class Program
    {
        static ConsoleTypingEffect consoleTyping = new ConsoleTypingEffect();
        static VoiceGreeting voiceGreeting = new VoiceGreeting();

        static void ChatbotInterface()
        {
            List<string> chatbotResponses = new List<string>()
            {
                "My purpose is to help you tackle every cyber threat you face. What issues are you currently facing?",
                "Phishing is a type of cyber attack where attackers trick people into revealing sensitive information, such as passwords, credit card numbers, or personal details. They often do this by disguising themselves as trustworthy entities, like banks, social media platforms, or government agencies.",
                "Strong passwords are your first line of defense. Use a mix of uppercase, lowercase, numbers, and symbols. Avoid using personal information, and never reuse passwords across different accounts. Consider using a password manager to help you create and store complex passwords securely.",
                "I'm good, thanks and you?",
                "Great! How can I assist you?",
                "Oh no! What could be the issue? Is it cyber related?"
            };

            try
            {
                DisplayMessage("Before we go any further, let's get to know each other. I'm Chatbot, and you are?", ConsoleColor.Green);
                string username = StoresUserInput();

                string goodbyeMessage = "goodbye";

                DisplayMessage($"Hello, {username}. How may I assist you with cybersecurity today?", ConsoleColor.Green);

                bool chatbotConversation = true;
                while (chatbotConversation)
                {

                    Console.Write($"{username}: ");
                    string response = StoresUserInput();

                    //The conversation ends when the user enters goodbye
                    if (ValidateUserInput(response, "goodbye"))
                    {
                        EndConversation();//Contains conversation ending message
                        chatbotConversation = false;//Ends the loop
                        continue;
                    }

                    if (ValidateUserInput(response, "phishing"))
                    {
                        DisplayMessage(chatbotResponses[1], ConsoleColor.Green);
                    }
                    else if (ValidateUserInput(response, "password"))
                    {
                        DisplayMessage(chatbotResponses[2], ConsoleColor.Green);
                    }
                    else if (ValidateUserInput(response, "purpose"))
                    {
                        DisplayMessage(chatbotResponses[0], ConsoleColor.Green);
                    }
                    else if (ValidateUserInput(response, "thank you"))
                    {
                        DisplayMessage("You're welcome.", ConsoleColor.Green);
                    }
                    else if (ValidateUserInput(response, "how are you"))
                    {
                        DisplayMessage(chatbotResponses[3], ConsoleColor.Green);

                        Console.Write($"{username}: ");
                        response = StoresUserInput();

                        if (ValidateUserInput(response, "I'm good") || ValidateUserInput(response, "I'm okay"))
                        {
                            DisplayMessage(chatbotResponses[4], ConsoleColor.Green);
                        }
                        else if (ValidateUserInput(response, "I'm not good") || ValidateUserInput(response, "I'm not okay"))
                        {
                            DisplayMessage(chatbotResponses[5], ConsoleColor.Magenta);
                        }
                        else
                        {
                            DisplayMessage($"I do not understand your input, {username}", ConsoleColor.DarkYellow);
                        }
                    }
                    else
                    {
                        DisplayMessage("I cannot provide any information concerning that, but you can ask about phishing, passwords, or my purpose.", ConsoleColor.Yellow);
                    }
                }
            }
            catch (FormatException ex)
            {
                DisplayMessage(ex.Message, ConsoleColor.Red);
            }
        }

        //Stores the user input and loops when the user does not enter an input
        static string StoresUserInput()
        {
            string input = Console.ReadLine();

            while (string.IsNullOrEmpty(input))
            {
                DisplayMessage("Please enter a valid input", ConsoleColor.Red);
                input = Console.ReadLine();
            }
            return input;//Stores data into the method using this variable
        }

        //Displays message of the chatbot
        static void DisplayMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write("Chatbot:");
            consoleTyping.TypingEffect(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Validates if the chatbot can provide answers concerning cybersecurity
        static bool ValidateUserInput(string response, string keyword)
        {
            //Checks if the response variable contains the requirement using the keyword variable
            return response.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        //Displays a message below when you end the conversation
        static void EndConversation()
        {
            DisplayMessage("Thank you for your time. Have a great day!", ConsoleColor.Yellow);
        }

        public static void Main(string[] args)
        {
            string filePath = @"C:\Users\Alan Chauke\POE\ascii-text-art (2).txt";

            //validates the existence of the ASCII art file
            if (File.Exists(filePath))
            {
                string ASCII_art = File.ReadAllText(filePath);
                Console.WriteLine(ASCII_art);
            }
            else
            {
                //Prints this statement when ASCII text file is not found.
                Console.Write("ASCII art file not found");
            }

            DisplayMessage("Hello! Welcome to the Cybersecurity Awareness Bot! How can I assist you today?", ConsoleColor.Green);
            voiceGreeting.PlayVoiceGreeting();
            ChatbotInterface();
        }
    }
}