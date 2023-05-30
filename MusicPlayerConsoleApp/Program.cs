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
        string inputOptionMusicPlayer = "";


        Console.WriteLine("Please add the path from where do you want to play the songs: ");
        string path = userInput.getUserInput();

        if (!String.IsNullOrEmpty(path)) 
        {
            List<FileSong> songs = fileHandler.getAllFiles(path);

            if (songs.Count > 0)
            {

                fileHandler.displayAllSongs(songs);

                Console.WriteLine("Add song number you want to play: ");
                string songNumberInput = userInput.getUserInput();

                if (!String.IsNullOrEmpty(songNumberInput) && songs.Contains(songs[Int32.Parse(songNumberInput) - 1]))
                {
                    Console.WriteLine("Select option: \n" +
                        "1 - Play only the selected song \n" +
                        "2 - Play from the selected song \n" +
                        "3 - Play in loop the selected song \n" +
                        "4 - Shuffle songs \n" +
                        "5 - EXIT player");

                    string selectedOptionInput = userInput.getUserInput();

                    if (!String.IsNullOrEmpty(selectedOptionInput))
                    {
                        switch (selectedOptionInput)
                        {
                            default:
                                Console.WriteLine("No correct option selected");
                                break;

                            case "1": // 1 - Play only the selected song
                                Console.WriteLine("Option selected: 1 - Play only the selected song");

                                musicPlayer.addSong(songs[Int32.Parse(selectedOptionInput) - 1]);
                                musicPlayer.play();

                                Console.WriteLine("1 - Play \n" +
                                                  "2 - Pause \n" +
                                                  "3 - Stop \n" +
                                                  "4 - EXIT player");

                                inputOptionMusicPlayer = userInput.getUserInput();

                                if (!String.IsNullOrEmpty(inputOptionMusicPlayer))
                                {
                                    switch (inputOptionMusicPlayer)
                                    {
                                        case "1": // 1 - Play
                                            musicPlayer.play();
                                            break;

                                        case "2": // 2 - Pause
                                            musicPlayer.pause();
                                            break;

                                        case "3": // 3 - Stop
                                            musicPlayer.stop();
                                            break;

                                        case "4": // 4 - EXIT player
                                            return;
                                    }
                                }


                                break;

                            case "2": // 2 - Play from the selected song

                                Console.WriteLine("Option selected: 2 - Play from the selected song");

                                var x = songs.GetRange(Int32.Parse(songNumberInput) - 1, songs.Count - (Int32.Parse(songNumberInput) - 1));
                                musicPlayer.addSongs(x);
                                musicPlayer.play();

                                Console.WriteLine("1 - Play \n" +
                                                  "2 - Pause \n" +
                                                  "3 - Stop \n" +
                                                  "4 - Next song \n" +
                                                  "5 - EXIT player");
                                while (true)
                                {
                                    inputOptionMusicPlayer = userInput.getUserInput();

                                    if (!String.IsNullOrEmpty(inputOptionMusicPlayer))
                                    {
                                        switch (inputOptionMusicPlayer)
                                        {
                                            case "1": // 1 - Play
                                                musicPlayer.play();
                                                break;

                                            case "2": // 2 - Pause
                                                musicPlayer.pause();
                                                break;

                                            case "3": // 3 - Stop
                                                musicPlayer.stop();
                                                break;

                                            case "4": // 4 - Next song
                                                musicPlayer.next();
                                                break;

                                            case "5": // 5 - EXIT player
                                                return;
                                        }
                                    }
                                }
                                break;

                            case "3": // 3 - Play in loop the selected song
                                break;

                            case "4": // 4 - Shuffle songs
                                break;

                            case "5": // 5 - EXIT player
                                return;
                        }
                    }
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