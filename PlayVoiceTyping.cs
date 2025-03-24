using System;
using System.Media;

namespace POEPart1
{
    public class VoiceGreeting
    {
        public void PlayVoiceGreeting()
        {
            //Path to the audio file
            string audioFilePath = @"C:\Users\Alan Chauke\POE\Recording.wav";

            //The try-catch block ensures that the program does not crash if the audio file is not found
            try
            {
                //Ensures that the audio file is disposed after use
                using (SoundPlayer player = new SoundPlayer(audioFilePath))
                {
                    // PlaySync ensures the greeting is played before proceeding
                    player.PlaySync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing audio: {ex.Message}");
            }
        }
    }
}
