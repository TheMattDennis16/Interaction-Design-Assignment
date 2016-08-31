using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;

namespace Assignment.Classes.SystemObjects.Other
{
    class Audio
    {
        //Win32 API Calls for audio waveform volume modification
        [DllImport("winmm.dll")]
        private static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll")]
        private static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        public static void updateVolume()
        {
            //Gets the new volume, applies the change to both audio channels and then sets the new volume to the output device.
            int newVol = ((ushort.MaxValue / 10) * Properties.Settings.Default.volume);
            uint NewVolumeAllChannels = (((uint)newVol & 0x0000ffff) | ((uint)newVol << 16));
            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
        }

        public static void playLowSound()
        {
            SoundPlayer player = new SoundPlayer((Stream)Properties.Resources.Low_On_Hover);
            player.Play();
        }

        public static void playHighSound()
        {
            SoundPlayer player = new SoundPlayer((Stream)Properties.Resources.High_On_Hover);
            player.Play();
        }

        public static void playOvenAlarm()
        {
            SoundPlayer player = new SoundPlayer((Stream)Properties.Resources.Oven_Alarm);
            player.Play();
        }

        private static System.Windows.Media.MediaPlayer player = null;

        public static void startOvenSound()
        {
            try
            {
                player = new System.Windows.Media.MediaPlayer();
                player.Open(new System.Uri(Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "audio/OvenOnSound.wav")));
                player.Play();
                player.MediaEnded += Player_MediaEnded;
            }
            catch (Exception e)
            {
                ErrorLogic.Error.showErrorDialog("Unable to load Audio File /audio/OvenOnSound.wav", 5);
            }
        }

        private static void Player_MediaEnded(object sender, EventArgs e)
        {
            player.Position = new TimeSpan(0);
            player.Play();
        }

        public static void stopOvenSound()
        {
            try
            {
                player.Stop();
            }
            catch (Exception e)
            {
                // Handled, ignore issue.
            }
        }
    }
}
