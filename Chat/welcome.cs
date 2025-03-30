using System.IO;
using System.Media;
using System;
namespace Chat
{

   
    public class welcome
    {
        public welcome()
        {
            string project_location = AppDomain.CurrentDomain.BaseDirectory;

            Console.WriteLine(project_location);

            string new_path = Directory.GetParent(project_location).Parent.Parent.FullName;
            //combine both the new path and wav name
            string full_path = Path.Combine(new_path, "sound.wav");

            play_Sound(full_path);

        }// end of constructor

        // method to play the audio
        public void play_Sound(string full_path)
        {
            //try and catch
            try
            {
                //play sound
                using(SoundPlayer play = new SoundPlayer(full_path))
                {
                    play.PlaySync();
                }
            }catch(Exception error)
            {
                //display error message
                Console.WriteLine(error.Message);
            }
        } 

    }//end of class
}//end of code