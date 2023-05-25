using MusicPlayerConsoleApp.Files;
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
           [ ] user should select the song by name
           [ ] can pause songs
           [ ] can stop songs
           [ ] will play next song in list
           [ ] can have option to shuffle the songs
           [ ] can play song on loop
           [ ] can exit the player and the song will stop
        
           =============================================================
           =============================================================
        */

        Console.WriteLine("------------------------ SCRIPT STARTED ------------------------");

        UserInput userInput = new UserInput();
        FileHandler fileHandler = new FileHandler();

        Console.WriteLine("Please add the path from where do you want to play the songs: ");

        string path = userInput.getUserInput();

        if (!String.IsNullOrEmpty(path))
        {
            List<FileSong> files = fileHandler.listAllFiles(path);

            fileHandler.displayAllSongs(files);

        }
        else
        {
            Console.WriteLine("Path is empty or null. Please add again...");
        }
       

        Console.WriteLine("------------------------ SCRIPT FINISHED ------------------------");
    }
}