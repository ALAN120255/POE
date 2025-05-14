using MemoryRecallGeneric;
using POE;
using POEPart1;
using System.Drawing;

public class Program
{
    static ConsoleTypingEffect consoleTyping = new ConsoleTypingEffect();
    static VoiceGreeting voiceGreeting = new VoiceGreeting();
    static MemoryRecall memoryRecall = null;
    static Random random = new Random();

    //Recognizes certain words in the user's input and displays an appropriate response
    static Dictionary<string, string> cyberChatbotResponses = new Dictionary<string, string>()
        {
            { "purpose", "My purpose is to help you tackle every cyber threat you face. What issues are you currently facing?" },
            { "phishing tips", "Phishing is a type of cyber attack where attackers trick people into revealing sensitive information, such as passwords, credit card numbers, or personal details. They often do this by disguising themselves as trustworthy entities, like banks, social media platforms, or government agencies. \nCheck sender email – Look for misspellings or odd domains.\r\n\r\nDon’t click unknown links – Hover to preview before clicking.\r\n\r\nAvoid urgent requests – Scammers create fake urgency.\r\n\r\nLook for poor grammar – Common in phishing messages.\r\n\r\nVerify with the source – Contact them directly via official channels.\r\n\r\nDon’t download unknown attachments – May contain malware.\r\n\r\nUse 2FA – Adds security even if credentials are stolen.\r\n\r\nUpdate software – Keeps security defenses strong.\r\n\r\nReport suspicious messages – Help others stay safe." },
            { "password", "Strong passwords are your first line of defense. Use a mix of uppercase, lowercase, numbers, and symbols. Avoid using personal information, and never reuse passwords across different accounts. Consider using a password manager to help you create and store complex passwords securely." },
            { "How are you", "I'm doing well, thanks and you?" },
            { "you good", "I'm doing well, thanks and you?" },
            { "I'm okay", "That's good to hear! How can I assist you?" },
            { "I'm alright", "That's good to hear! How can I assist you?" },
            { "I'm good", "That's good to hear! How can I assist you?" },
            { "I'm not okay", "Oh no! What could be the issue?   it cyber related?" },
            { "I'm not good", "Oh no! What could be the issue? Is it cyber related?" },
            { "I'm not feeling well", "Oh no! What could be the issue? Is it cyber related?" },
            { "I'm not feeling okay", "Oh no! What could be the issue? Is it cyber related?" },
            { "I'm not feeling good", "I know what you need, you just need help with cybersecurity!" },
            { "Hello", "Hey! How are you?" },
            { "Hey", "Hi! How are you?" }
        };

    static void ChatbotInterface()
    {
        //Contains random facts about cybersecurity.
        List<string> randomResponses = new List<string>()
        {
            "Always use two-factor authentication (2FA) to add an extra layer of security to your accounts.",
            "Phishing attacks account for over 80% of reported security incidents worldwide.",
            "A strong password should be at least 12 characters long and include a mix of letters, numbers, and symbols.",
            "Public Wi-Fi networks are not secure. Avoid accessing sensitive information while connected to them.",
            "Keep your software and operating system updated to protect against the latest vulnerabilities.",
            "Over 90% of malware is delivered via email. Be cautious of unexpected attachments or links.",
            "Using the same password across multiple accounts increases your risk of being hacked.",
            "Back up your data regularly to protect against ransomware attacks.",
            "Cybercriminals often impersonate trusted organizations. Always verify the sender before sharing sensitive information.",
            "Avoid clicking on pop-up ads or suspicious links—they may lead to malware infections."
        };

        //The main program
        try
        {
            DisplayMessage("Before we go any further, let's get to know each other. I'm Chatbot, and you are?", ConsoleColor.Green);
            string username = StoresUserInput();

            string goodbyeMessage = "goodbye";

            DisplayMessage($"Hello, {username}. How may I assist you with cybersecurity today?", ConsoleColor.Green);

            bool chatbotConversation = true;
            while (chatbotConversation)
            {
                RandomCyberMessageDisplayer(randomResponses);
                
                Console.Write($"{username}: ");
                string response = StoresUserInput();

                //Ends the whole program when the user says goodbye, bye bye, exit and quit
                if (ValidateUserInput(response, "goodbye") || ValidateUserInput(response, "bye bye")
                    || ValidateUserInput(response, "exit") || ValidateUserInput(response, "quit"))
                {
                    EndConversation();
                    chatbotConversation = false;
                    break;
                }

                //Checks if user memory is present using the response variable (which stores user input)
                if (ValidateUserInput(response, "show memory") || ValidateUserInput(response, "remember"))
                {
                    DisplayMessage($"Which memory can I recall for you, {username}", ConsoleColor.Blue);

                    Console.Write($"{username}: ");
                    response = StoresUserInput();

                    new MemoryRecall(response);

                    DisplayMessage($"Is there anything about {response} that you want me to emphasize?", ConsoleColor.Blue);

                    Console.Write($"{username}: ");
                    response = StoresUserInput();

                    if (response.Contains("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        CheckKeyword(response, cyberChatbotResponses);
                        continue;
                    }
                    else
                    {
                        DisplayMessage("No worries. Is there anything else you need?", ConsoleColor.Yellow);
                        response = StoresUserInput();
                    }

                    RandomCyberMessageDisplayer(randomResponses);
                }

                //For keyword validation
                CheckKeyword(response, cyberChatbotResponses);

            }
        }
        catch (FormatException ex)
        {
            DisplayMessage(ex.Message, ConsoleColor.Red);
        }
    }

    static void RandomCyberMessageDisplayer(List<string> chatbotResponses)
    {
        int index = random.Next(0, chatbotResponses.Count);
        DisplayMessage(chatbotResponses[index], ConsoleColor.Green);
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

        return input;
    }

    //Displays message of the chatbot
    static void DisplayMessage(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write("Chatbot:");
        consoleTyping.TypingEffect(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    /* Checks if the user's input matches with what's in the chatbotResponses Dictionary.
     * If the keyword is not found in the Dictionary, It returns a message notifying the user
     * that it cannot provide information concerning what the user said or asked for.
     */
    static bool CheckKeyword(string response, Dictionary<string, string> chatbotResponses)
    {
        bool keywordFound = false;
        foreach (var keyword in chatbotResponses.Keys)
        {
            if (ValidateUserInput(response, keyword))
            {
                DisplayMessage(chatbotResponses[keyword], ConsoleColor.Green);
                keywordFound = true;
                break;
            }
        }

        if (!keywordFound)
        {
            DisplayMessage("I cannot provide an answer concerning that, but I can help you with cybersecurity related issues.", ConsoleColor.Yellow);
        }

        return keywordFound;
    }

    //Validates if the chatbot can provide answers concerning cybersecurity
    static bool ValidateUserInput(string response, string keyword)
    {
        return response.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0;
    }

    //Displays an end conversation message
    static void EndConversation()
    {
        DisplayMessage("Thank you for your time. Have a great day!", ConsoleColor.Yellow);
    }

    public static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Blue;

        new ASCIIArt() { };

        DisplayMessage("Hello! Welcome to the Cybersecurity Awareness Bot! How can I assist you today?", ConsoleColor.Green);
        voiceGreeting.PlayVoiceGreeting();
        ChatbotInterface();
    }
}
