using MusicPlayerConsoleApp.Files;
using NAudio.Wave;
using System.Threading;

namespace MusicPlayerConsoleApp.Player
{
    public class MusicPlayer
    {
        enum PlayerState
        {
            PLAYING,
            STOPPED,
            PAUSED
        }

        volatile PlayerState previousState = PlayerState.STOPPED;
        volatile PlayerState currentState = PlayerState.STOPPED;

        WaveOutEvent outputDevice = new WaveOutEvent();

        List<FileSong> fileSongs = new List<FileSong>();

        int indexSongPlaying = 0;

        AudioFileReader audioFile;
        
        Thread playThread;

        public MusicPlayer() 
        {
            playThread = new Thread(startThread);
            playThread.Start();
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
            if (previousState != PlayerState.PAUSED)
            {
                audioFile = new AudioFileReader(fileSong.path);
                outputDevice.Init(audioFile);
            }
            outputDevice.Play();
        }

        public void showPlayedSongTimestamp()
        {
            if (audioFile != null)
            {
                //Console.WriteLine(audioFile.CurrentTime + " out of " + audioFile.TotalTime);
            }
        }

        public void pause()
        {
            previousState = currentState;
            currentState = PlayerState.PAUSED;
        }

        public void stop()
        {
            previousState = currentState;
            currentState = PlayerState.STOPPED;
        }

        public void play()
        {
            previousState = currentState;
            currentState = PlayerState.PLAYING;
        }

        public void previous()
        {
            outputDevice.Stop();
            if (indexSongPlaying != 0)
                indexSongPlaying--;
            playSong(fileSongs[indexSongPlaying]);
        }

        public void next()
        {
            outputDevice.Stop();
            if (indexSongPlaying != fileSongs.Count - 1)
            {
                indexSongPlaying++;
            }
            playSong(fileSongs[indexSongPlaying]);
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