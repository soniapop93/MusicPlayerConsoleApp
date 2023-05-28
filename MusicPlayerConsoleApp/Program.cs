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
           [X] user should select the song by number
           [X] can play songs
           [X] can pause songs
           [X] can stop songs
           [X] will play next song in list
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
        MusicPlayer musicPlayer = new MusicPlayer();


        //string optionMenu = "Select option: \n " +
        //    "1 - Add folder \n" +
        //    "2 - Add song to playlist\n" +
        //    "3 - Play all songs \n" +
        //    "4 - Select song to play \n" +
        //    "5 - Pause song \n" +
        //    "6 - Stop song \n" +
        //    "7 - Play next song \n" +
        //    "8 - Delete song from playlist \n" +
        //    "9 - Suffle playlist \n" +
        //    "10 - Play song in loop \n" +
        //    "11 - EXIT player";

        Console.WriteLine("Please add the path from where do you want to play the songs: ");
        string path = userInput.getUserInput();

        if (!String.IsNullOrEmpty(path)) 
        {
            List<FileSong> songs = fileHandler.getAllFiles(path);
            List<FileSong> songsToPlay = new List<FileSong>();

            if (songs.Count > 0)
            {
                fileHandler.displayAllSongs(songs);

                Console.WriteLine("Add song number you want to play: ");
                string songNumberInput = userInput.getUserInput();

                if (!String.IsNullOrEmpty(songNumberInput) && songs.Contains(songs[Int32.Parse(songNumberInput) - 1]))
                {

                    for (int i = Int32.Parse(songNumberInput) - 1; i < songs.Count; i++)
                    {
                        songsToPlay.Add(songs[i]);
                    }

                    Console.WriteLine("Select option: \n" +
                        "1 - Play only the selected song \n" +
                        "2 - Play from the selected song \n" +
                        "3 - Play in loop the selected song \n " +
                        "4 - Pause song\n" +
                        "5 - Stop song\n" +
                        "6 - Shuffle songs\n" +
                        "7 - EXIT player");

                    musicPlayer.addSongs(songsToPlay);

                    string selectedOptionInput = userInput.getUserInput();

                    if (!String.IsNullOrEmpty(selectedOptionInput))
                    {
                        switch (selectedOptionInput)
                        {
                            case "1":
                                break;
                        }
                    }

                    musicPlayer.play();
                }
                else
                {
                    Console.WriteLine("No correct song selected");
                }
            }
            else
            {
                Console.WriteLine("There are no songs available");
            }
        }
        Console.WriteLine("------------------------ SCRIPT FINISHED ------------------------");
    }
}