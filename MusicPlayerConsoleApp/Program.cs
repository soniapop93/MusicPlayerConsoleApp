using MusicPlayerConsoleApp.Files;
using MusicPlayerConsoleApp.Player;
using MusicPlayerConsoleApp.User;

public class Program
{
    public static void Main(string[] args)
    {
        /*
           =============================================================
           =============================================================
            
            MusicPlayerConsoleApp

           [X] takes path from user where the files are
           [X] list all songs
           [X] user should select the song by name
           [X] can play songs
           [ ] can pause songs
           [ ] can stop songs
           [ ] will play next song in list
           [ ] show song that currently playing
           [ ] can have option to shuffle the songs
           [ ] can play song on loop
           [ ] can exit the player and the song will stop
        
           =============================================================
           =============================================================
        */

        Console.WriteLine("------------------------ SCRIPT STARTED ------------------------");

        UserInput userInput = new UserInput();
        FileHandler fileHandler = new FileHandler();
        PlayerLogic playerLogic = new PlayerLogic(); 

        while (true)
        {
            Console.WriteLine("Please add the path from where do you want to play the songs: ");

            string path = userInput.getUserInput();

            if (!String.IsNullOrEmpty(path))
            {
                List<FileSong> files = fileHandler.listAllFiles(path);

                fileHandler.displayAllSongs(files);

                Console.WriteLine("Select a song: ");

                string songInput = userInput.getUserInput();

                if (!String.IsNullOrEmpty(songInput))
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        if (files[i].name.Equals(songInput))
                        {
                            Console.WriteLine("----> Selected song: " + files[i].name);
                            FileSong songSelected = files[i];
                            playerLogic.playSong(songSelected);
                            
                            //TODO: logic to stop the song

                        }
                    }

                }
                else
                {
                    Console.WriteLine("No song selected...");
                }


            }
            else
            {
                Console.WriteLine("Path is empty or null. Please add again...");
            }

        }



        Console.WriteLine("------------------------ SCRIPT FINISHED ------------------------");
    }
}