using MusicPlayerConsoleApp.Files;
using NAudio.Wave;

namespace MusicPlayerConsoleApp.Player
{
    public class PlayerLogic
    {
        WaveOutEvent outputDevice = new WaveOutEvent();

        public void playSong(FileSong fileSong)
        {
            AudioFileReader audioFile = new AudioFileReader(fileSong.path);
            outputDevice.Init(audioFile);
            outputDevice.Play();

            while (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                Console.WriteLine(audioFile.CurrentTime + " out of " + audioFile.TotalTime);
                Thread.Sleep(1000);
            }
        }

    }
}