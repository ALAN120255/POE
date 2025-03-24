using System;
using System.Collections;
using System.Linq;
using System.Threading;

namespace POEPart1
{
    public class ConsoleTypingEffect
    {
        //Implements a typing effect of the chatbot.
        //The delay variable implements the time (in milliseconds) the typing effect should take
        public void TypingEffect(string message, int delay = 50)
        {
            //The character variable 'c' checks every character stored in the variable 'message' through the foreach loop
            foreach (char c in message)
            {

                Console.Write(c);//Prints out the characters one at a time
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }
    }
}
