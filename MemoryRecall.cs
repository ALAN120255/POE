using System;
using System.Collections.Generic;
using System.IO;

namespace MemoryRecallGeneric
{
    public class MemoryRecall
    {
        public MemoryRecall()
        {
            //Getting full path of the project
            string fullPath = AppDomain.CurrentDomain.BaseDirectory;

            //Replacing bin and Debug
            string newPath = fullPath.Replace("bin\\Debug\\net9.0\\", "");

            //combine the new path with the file name
            string path = Path.Combine(newPath, "memory_recall.txt");

            //Assign memory to check for users
            List<string> memoryStored = LoadMemory(path);

            //Check memory using forach loop
            foreach (var check in memoryStored)
            {
                Console.WriteLine(check);
            }

            //Demo data to check the file
            memoryStored.Add("Owen, what is password");

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
                File.CreateText(path);
                return new List<string>();
            }
        }//end of LoadMemory List
    }//end of class
}//end of namespace