using MusicPlayerConsoleApp.Files;
using NAudio.Wave;
using System.Threading;

namespace MusicPlayerConsoleApp.Player
{
    public class PlayerLogic
    {
        enum PlayerState
        {
            PLAYING,
            STOPPED,
            PAUSED
        }

        PlayerState currentState = PlayerState.STOPPED;

        WaveOutEvent outputDevice = new WaveOutEvent();

        List<FileSong> fileSongs = new List<FileSong>();

        int indexSongPlaying = 0;

        AudioFileReader audioFile;
        
        Thread playThread;

        public PlayerLogic() 
        {
            playThread = new Thread(startThread);
        }

        public void addSong(FileSong fileSong) 
        {
            fileSongs.Add(fileSong);
        }

        public void addSongs(List<FileSong> files)
        {
            fileSongs.AddRange(files);
        }

        private void playSongs()
        {
            while (currentState == PlayerState.PLAYING)
            {
                if (fileSongs.Count > indexSongPlaying)
                {
                    playSong(fileSongs[indexSongPlaying]);
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        if (currentState != PlayerState.PLAYING)
                        {
                            return;
                        }
                        showPlayedSongTimestamp();
                        Thread.Sleep(1000);
                    }
                    indexSongPlaying++;
                }
            }
        }
        private void playSong(FileSong fileSong)
        {
            audioFile = new AudioFileReader(fileSong.path);
            outputDevice.Init(audioFile);
            outputDevice.Play();
        }

        public void showPlayedSongTimestamp()
        {
            if (audioFile != null)
            {
                Console.WriteLine(audioFile.CurrentTime + " out of " + audioFile.TotalTime);
            }
        }

        public void pauseSong()
        {
            currentState = PlayerState.PAUSED;
        }

        public void stopSong()
        {
            currentState = PlayerState.STOPPED;
        }

        public void startSong()
        {
            currentState = PlayerState.PLAYING;
        }

        private void startThread()
        {
            while (true)
            {
                switch (currentState)
                {
                    case PlayerState.PLAYING:
                        playSongs();
                        break;

                    case PlayerState.STOPPED:
                        outputDevice.Stop();
                        break;

                    case PlayerState.PAUSED:
                        outputDevice.Pause();
                        break;
                }
            }
        }

    }
}