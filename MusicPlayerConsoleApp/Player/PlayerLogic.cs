using MusicPlayerConsoleApp.Files;
using System.Media;
using System.Numerics;

namespace MusicPlayerConsoleApp.Player
{
    public class PlayerLogic
    {
        SoundPlayer soundPlayer = new SoundPlayer();
        public void playSong(FileSong fileSong)
        {
            soundPlayer.SoundLocation = fileSong.path;
            soundPlayer.Play();
        }
    }
}
