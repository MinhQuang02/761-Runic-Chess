using UnityEngine;
using Data.Core;

namespace Sounds
{
    public static class GameSounds
    {
        /*
         * ===================================================
         * Declarations all audio sources used in the game
         * ===================================================
        */
        private static AudioSource titleTheme;
        private static AudioSource themeSong;
        private static AudioSource bgm;
        private static AudioSource hoverSound;
        private static AudioSource clickSound;

        /*
         * ===================================================
         * Initialize all audio sources used in the game
         * ===================================================
        */
        public static void Initialize()
        {
            titleTheme = GameObject.Find("Audios/title-theme").GetComponent<AudioSource>();
            themeSong = GameObject.Find("Audios/theme-song").GetComponent<AudioSource>();
            bgm = GameObject.Find("Audios/bgm").GetComponent<AudioSource>();
            hoverSound = GameObject.Find("Audios/hover-sound").GetComponent<AudioSource>();
            clickSound = GameObject.Find("Audios/click-sound").GetComponent<AudioSource>();
        }

        /*
         * ===================================================
         * Play and stop functions for all audio sources used in the game
         * ===================================================
        */

        // Title Theme
        public static void PlayTitleTheme()
        {
            titleTheme.Play();
        }

        public static void StopTitleTheme()
        {
            titleTheme.Stop();
        }

        // Theme Song
        public static void PlayThemeSong()
        {
            themeSong.Play();
        }

        public static void StopThemeSong()
        {
            themeSong.Stop();
        }

        // BGM
        public static void PlayBGM()
        {
            bgm.Play();
        }

        public static void StopBGM()
        {
            bgm.Stop();
        }

        // Click Sound
        public static void PlayClickSound()
        {
            clickSound.Play();
        }

        // Hover Sound
        public static void PlayHoverSound()
        {
            hoverSound.Play();
        }

        // Update all volumes based on player settings
        public static void UpdateVolumes()
        {   
            if (MainData.currentPlayerSession == -1)
            {
                titleTheme.volume = (MainData.defaultPlayerSetting.mainVolume *
                                    MainData.defaultPlayerSetting.musicVolume) / 10000f;
                themeSong.volume = (MainData.defaultPlayerSetting.mainVolume *
                                    MainData.defaultPlayerSetting.musicVolume) / 10000f;
                bgm.volume = (MainData.defaultPlayerSetting.mainVolume *
                                    MainData.defaultPlayerSetting.musicVolume) / 10000f;
                hoverSound.volume = (MainData.defaultPlayerSetting.mainVolume *
                                    MainData.defaultPlayerSetting.clickSound) / 10000f;
                clickSound.volume = (MainData.defaultPlayerSetting.mainVolume *
                                    MainData.defaultPlayerSetting.hoverSound) / 10000f;
            }
            else
            {
                titleTheme.volume = (MainData.playerSettings[MainData.currentPlayerSession].mainVolume *
                                    MainData.playerSettings[MainData.currentPlayerSession].musicVolume) / 10000f;
                themeSong.volume = (MainData.playerSettings[MainData.currentPlayerSession].mainVolume *
                                    MainData.playerSettings[MainData.currentPlayerSession].musicVolume) / 10000f;
                bgm.volume = (MainData.playerSettings[MainData.currentPlayerSession].mainVolume *
                                    MainData.playerSettings[MainData.currentPlayerSession].musicVolume) / 10000f;
                hoverSound.volume = (MainData.playerSettings[MainData.currentPlayerSession].mainVolume *
                                    MainData.playerSettings[MainData.currentPlayerSession].clickSound) / 10000f;
                clickSound.volume = (MainData.playerSettings[MainData.currentPlayerSession].mainVolume *
                                    MainData.playerSettings[MainData.currentPlayerSession].hoverSound) / 10000f;
            }
        }
    }
}