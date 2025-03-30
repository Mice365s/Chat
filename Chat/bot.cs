using System;
using System.Collections;

namespace Chat
{
    // Bot class that handles user interaction and processes questions
    public class Bot
    {
        // Store predefined replies
        private ArrayList reply = new ArrayList();   
        // Store words to ignore
        private ArrayList ignore = new ArrayList(); 
        private string name;

        public Bot()
        {
            // Ask for the user's name
            Console.WriteLine("Welcome! Please write your name:");
            name = Console.ReadLine();

            // Greet the user
            Console.WriteLine($"Hello {name}!");

            // Populate the replies and ignore lists
            store_replies();
            store_ignore();

            // Loop to keep asking questions until user types 'exit'
            while (true)
            {
                // Ask the user to enter a question
                Console.WriteLine("Please enter your question (or type 'exit' to quit):");
                string question = Console.ReadLine();

                if (question.ToLower() == "exit")
                {
                    break;
                }

                // Process the question and filter out ignored words
                string[] filteredWords = FilterQuestion(question);

                // Get and display a reply based on the filtered question
                string message = GetReply(filteredWords);

                if (!string.IsNullOrEmpty(message))
                {
                    // Display relevant reply
                    Console.WriteLine(message); 
                }
                else
                {
                    Console.WriteLine("Sorry, I couldn't find an answer to your question.");
                }
            }

            Console.WriteLine("Thank you for using the Cybersecurity Awareness Program. Stay safe online!");
        }

        // Method to store replies
        private void store_replies()
        {
            reply.Add("Password is a combination of characters created by users to verify identity and grant access to a computer system, online account, or other protected resource. A strong password must be at least 8 characters long, contain a mixture of numbers, letters, and special characters.");
            reply.Add("Phishing is an attack that attempts to obtain sensitive information like passwords or account details. It usually comes in the form of fraudulent emails, text messages, or websites.");
            reply.Add("Ransomware is a type of malicious software that encrypts a user's files or locks their system, demanding payment (ransom) to restore access.");
            reply.Add("Cybersecurity involves protecting computer systems, networks, and data from digital attacks, theft, or damage. It is important to use firewalls, encryption, and strong authentication practices.");
            reply.Add("Social Engineering is a method of hacking which is based on spoofing a person’s identity and getting their details using socializing skill. \r\n\r\nSocial engineering doesn’t appear to be a genuine danger, yet it can prompt hefty misfortunes for associations. The impact of social engineering attack on organizations include: financial loss, harm of goodwill, loss of privacy, danger of terrorism. This is how you defend against social engineering by keeping software and firmware regularly updated, particularly security patches. Don't run your phone rooted, or your network or PC in administrator mode. Even if a social engineering attack gets your user password for your 'user' account, it won't let them reconfigure your system or install software on it. ");
            reply.Add("DDoS(Distributed denial of service) is a type of DOS attack where multiple systems, which are trojan infected, target a particular system which causes a DoS attack. \r\n\r\nA DDoS attack uses multiple servers and Internet connections to flood the targeted resource. A DDoS attack is one of the most powerful weapons on the cyber platform. When you come to know about a website being brought down, it generally means it has become a victim of a DDoS attack.");
            reply.Add("Outdated software ");
        }

        // Method to store words to ignore
        private void store_ignore()
        {
            ignore.Add("the");
            ignore.Add("is");
            ignore.Add("a");
            ignore.Add("of");
            ignore.Add("to");
            ignore.Add("and");
            ignore.Add("in");
            ignore.Add("for");
        }

        // Method to filter the user's question and remove ignored words
        private string[] FilterQuestion(string question)
        {
            string[] questionWords = question.Split(new char[] { ' ', '.', '?', '!', ',' }, StringSplitOptions.RemoveEmptyEntries);
            ArrayList filteredWords = new ArrayList();

            // Add words to filtered list that are not in the ignore list
            foreach (string word in questionWords)
            {
                if (!ignore.Contains(word.ToLower()))
                {
                    filteredWords.Add(word.ToLower());
                }
            }

            // Convert ArrayList to an array and return
            return (string[])filteredWords.ToArray(typeof(string));
        }

        // Method to get a reply based on the filtered words
        private string GetReply(string[] filteredWords)
        {
            string message = string.Empty;

            // Check if any of the filtered words match a predefined reply
            foreach (string word in filteredWords)
            {
                foreach (string replyMessage in reply)
                {
                    // Case insensitive comparison
                    if (replyMessage.ToLower().Contains(word.ToLower())) 
                    {
                        message += replyMessage + "\n";
                        break;  
                    }
                }
            }

            return message;
        }
    }
}
