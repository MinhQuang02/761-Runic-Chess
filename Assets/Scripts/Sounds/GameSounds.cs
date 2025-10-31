using UnityEngine;

namespace Sounds
{
    public static class GameSounds
    {
        private static AudioSource titleTheme;
        private static AudioSource themeSong;
        private static AudioSource bgm;

        private static AudioSource hoverSound;
        private static AudioSource clickSound;

        public static float mainVolumeIndex = 0.7f;
        public static float musicVolumeIndex = 0.7f;
        public static float clickSoundIndex = 0.7f;
        public static float hoverSoundIndex = 0.7f;

        public static void Initialize()
        {
            titleTheme = GameObject.Find("Audios/title-theme").GetComponent<AudioSource>();
            themeSong = GameObject.Find("Audios/theme-song").GetComponent<AudioSource>();
            bgm = GameObject.Find("Audios/bgm").GetComponent<AudioSource>();

            hoverSound = GameObject.Find("Audios/hover-sound").GetComponent<AudioSource>();
            clickSound = GameObject.Find("Audios/click-sound").GetComponent<AudioSource>();
        }

        public static void PlayTitleTheme()
        {
            titleTheme.Play();
        }

        public static void StopTitleTheme()
        {
            titleTheme.Stop();
        }

        public static void PlayThemeSong()
        {
            themeSong.Play();
        }

        public static void StopThemeSong()
        {
            themeSong.Stop();
        }

        public static void PlayBGM()
        {
            bgm.Play();
        }

        public static void StopBGM()
        {
            bgm.Stop();
        }

        public static void PlayHoverSound()
        {
            hoverSound.Play();
        }

        public static void PlayClickSound()
        {
            clickSound.Play();
        }

        public static void UpdateVolumes()
        {
            titleTheme.volume = mainVolumeIndex * musicVolumeIndex;
            themeSong.volume = mainVolumeIndex * musicVolumeIndex;
            bgm.volume = mainVolumeIndex * musicVolumeIndex;
            hoverSound.volume = mainVolumeIndex * hoverSoundIndex;
            clickSound.volume = mainVolumeIndex * clickSoundIndex;
        }
    }
}