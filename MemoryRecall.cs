using System;
using System.Collections.Generic;
using System.IO;

namespace MemoryRecallGeneric
{
    public class MemoryRecall
    {
        public MemoryRecall(string userInput)
        {
            //Getting full path of the project
            string fullPath = AppDomain.CurrentDomain.BaseDirectory;

            //Replacing bin and Debug
            string newPath = fullPath.Replace("bin\\Debug\\net9.0\\", "");

            //Combining the new path with the file name
            string path = Path.Combine(newPath, "memory_recall.txt");

            //Assigning memory to check for users
            List<string> memoryStored = LoadMemory(path);

            if (memoryStored.Count > 0)
            {

                foreach (var line in memoryStored)
                {
                    if (line.Contains(userInput, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine("No memory found");
            }
    
            //Demo data to check the file
            memoryStored.Add(userInput);

            //...then store all fav for history
            File.WriteAllLines(path, memoryStored);

        }//end of constructor

        private List<string> LoadMemory(string path)
        {
            if (File.Exists(path))
            {
                //return all history
                return new List<string>(File.ReadAllLines(path));
            }
            else
            {
                //Create the text file if not found
                File.CreateText(path).Dispose();
                return new List<string>();
            }
        }//end of LoadMemory List
    }//end of class
}//end of namespace