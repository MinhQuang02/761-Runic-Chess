using UnityEngine;
using Sounds;
using Data.Core;
using UI.Render;
using UnityEngine.UI;

namespace Core.MainMenu
{
    public class Settings : MonoBehaviour
    {
        /*
         * ===================================================
         * Using Singleton Pattern to ensure only one instance of Settings exists and initialize default settings
         * ===================================================
        */
        private static GameObject Instance;

        public void Awake()
        {
            // Singleton pattern
            if (Instance == null)
            {
                Instance = this.gameObject;
            }
            else
            {
                Destroy(this.gameObject);
                return;
            }

            // Initialize default settings
            Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, FullScreenMode.FullScreenWindow);
            QualitySettings.SetQualityLevel(2);
            QualitySettings.vSyncCount = 1;
        }

        /*
         * ===================================================
         * Declare all the variables used in the Settings
         * ===================================================
        */
        [SerializeField] private Scrollbar mainVolumeScrollbar;
        [SerializeField] private Scrollbar musicVolumeScrollbar;
        [SerializeField] private Scrollbar clickSoundScrollbar;
        [SerializeField] private Scrollbar hoverSoundScrollbar;

        private int[] targetWidth = new int[] { 1280, 1920, 2560, 3840 };
        private int[] targetHeight = new int[] { 720, 1080, 1440, 2160 };

        /*
         * ===================================================
         * Re-render indices and values in Settings
         * ===================================================
        */
        public void RenderSettings()
        {   
            if (MainData.currentPlayerSession == -1)
            {   
                // Display Mode
                if (MainData.defaultPlayerSetting.displayMode)
                {
                    Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, FullScreenMode.FullScreenWindow);
                }
                else
                {
                    Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
                }

                // Resolution
                QualitySettings.SetQualityLevel(MainData.defaultPlayerSetting.resolution);

                // Vsync
                if (MainData.defaultPlayerSetting.vsync)
                {
                    QualitySettings.vSyncCount = 1;
                }
                else
                {
                    QualitySettings.vSyncCount = 0;
                }

                // Update volumes
                GameSounds.UpdateVolumes();

                // Update volume scrollbars
                mainVolumeScrollbar.value = MainData.defaultPlayerSetting.mainVolume / 100f;
                musicVolumeScrollbar.value = MainData.defaultPlayerSetting.musicVolume / 100f;
                clickSoundScrollbar.value = MainData.defaultPlayerSetting.clickSound / 100f;
                hoverSoundScrollbar.value = MainData.defaultPlayerSetting.hoverSound / 100f;
            }
            else
            {
                // Display Mode
                if (MainData.playerSettings[MainData.currentPlayerSession].displayMode)
                {
                    Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, FullScreenMode.FullScreenWindow);
                }
                else
                {
                    Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
                }

                // Resolution
                QualitySettings.SetQualityLevel(MainData.playerSettings[MainData.currentPlayerSession].resolution);

                // Vsync
                if (MainData.playerSettings[MainData.currentPlayerSession].vsync)
                {
                    QualitySettings.vSyncCount = 1;
                }
                else
                {
                    QualitySettings.vSyncCount = 0;
                }

                // Update volumes
                GameSounds.UpdateVolumes();

                // Update volume scrollbars
                mainVolumeScrollbar.value = MainData.playerSettings[MainData.currentPlayerSession].mainVolume / 100f;
                musicVolumeScrollbar.value = MainData.playerSettings[MainData.currentPlayerSession].musicVolume / 100f;
                clickSoundScrollbar.value = MainData.playerSettings[MainData.currentPlayerSession].clickSound / 100f;
                hoverSoundScrollbar.value = MainData.playerSettings[MainData.currentPlayerSession].hoverSound / 100f;
            }
            MainMenuRender.RenderSettingsModal();
        }

        /*
         * ===================================================
         * Edit settings via the buttons in Settings
         * ===================================================
        */

        // Display Mode
        public void ChangeLeftDisplayMode()
        {
            if (MainData.currentPlayerSession == -1)
            {
                if (MainData.defaultPlayerSetting.displayMode)
                {
                    MainData.defaultPlayerSetting.displayMode = false;
                    Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
                }
            }
            else
            {
                if (MainData.playerSettings[MainData.currentPlayerSession].displayMode)
                {
                    MainData.playerSettings[MainData.currentPlayerSession].displayMode = false;
                    Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
                }
            }
            MainMenuRender.RenderSettingsModal();
        }

        public void ChangeRightDisplayMode()
        {
            if (MainData.currentPlayerSession == -1)
            {
                if (!MainData.defaultPlayerSetting.displayMode)
                {
                    MainData.defaultPlayerSetting.displayMode = true;
                    Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, FullScreenMode.FullScreenWindow);
                }
            }
            else
            {
                if (!MainData.playerSettings[MainData.currentPlayerSession].displayMode)
                {
                    MainData.playerSettings[MainData.currentPlayerSession].displayMode = true;
                    Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, FullScreenMode.FullScreenWindow);
                }
            }
            MainMenuRender.RenderSettingsModal();
        }

        // Resolution
        public void ChangeLeftResolution()
        {
            if (MainData.currentPlayerSession == -1)
            {
                if (MainData.defaultPlayerSetting.resolution > 0)
                {
                    MainData.defaultPlayerSetting.resolution -= 1;
                    QualitySettings.SetQualityLevel(MainData.defaultPlayerSetting.resolution);
                }
            }
            else
            {
                if (MainData.playerSettings[MainData.currentPlayerSession].resolution > 0)
                {
                    MainData.playerSettings[MainData.currentPlayerSession].resolution -= 1;
                    QualitySettings.SetQualityLevel(MainData.playerSettings[MainData.currentPlayerSession].resolution);
                }
            }
            MainMenuRender.RenderSettingsModal();
        }

        public void ChangeRightResolution()
        {
            if (MainData.currentPlayerSession == -1)
            {
                if (MainData.defaultPlayerSetting.resolution < 3)
                {
                    MainData.defaultPlayerSetting.resolution += 1;
                    QualitySettings.SetQualityLevel(MainData.defaultPlayerSetting.resolution);
                }
            }
            else
            {
                if (MainData.playerSettings[MainData.currentPlayerSession].resolution < 3)
                {
                    MainData.playerSettings[MainData.currentPlayerSession].resolution += 1;
                    QualitySettings.SetQualityLevel(MainData.playerSettings[MainData.currentPlayerSession].resolution);
                }
            }
            MainMenuRender.RenderSettingsModal();
        }

        // Vsync
        public void ChangeLeftVsync()
        {
            if (MainData.currentPlayerSession == -1)
            {
                if (MainData.defaultPlayerSetting.vsync)
                {
                    MainData.defaultPlayerSetting.vsync = false;
                    QualitySettings.vSyncCount = 0;
                }
            }
            else
            {
                if (MainData.playerSettings[MainData.currentPlayerSession].vsync)
                {
                    MainData.playerSettings[MainData.currentPlayerSession].vsync = false;
                    QualitySettings.vSyncCount = 0;
                }
            }
            MainMenuRender.RenderSettingsModal();
        }

        public void ChangeRightVsync()
        {
            if (MainData.currentPlayerSession == -1)
            {
                if (!MainData.defaultPlayerSetting.vsync)
                {
                    MainData.defaultPlayerSetting.vsync = true;
                    QualitySettings.vSyncCount = 1;
                }
            }
            else
            {
                if (!MainData.playerSettings[MainData.currentPlayerSession].vsync)
                {
                    MainData.playerSettings[MainData.currentPlayerSession].vsync = true;
                    QualitySettings.vSyncCount = 1;
                }
            }
            MainMenuRender.RenderSettingsModal();
        }

        // Main Volume
        public void ChangeLeftMainVolume()
        {
            if (MainData.currentPlayerSession == -1)
            {
                if (MainData.defaultPlayerSetting.mainVolume > 4)
                {   
                    Debug.Log(MainData.defaultPlayerSetting.mainVolume);
                    MainData.defaultPlayerSetting.mainVolume -= 5;
                    Debug.Log(MainData.defaultPlayerSetting.mainVolume);
                    Debug.Log(MainData.defaultPlayerSetting.mainVolume);
                    mainVolumeScrollbar.value = MainData.defaultPlayerSetting.mainVolume / 100f;
                    Debug.Log(MainData.defaultPlayerSetting.mainVolume);
                    Debug.Log(MainData.defaultPlayerSetting.mainVolume);
                }
            }
            else
            {
                if (MainData.playerSettings[MainData.currentPlayerSession].mainVolume > 4)
                {
                    MainData.playerSettings[MainData.currentPlayerSession].mainVolume -= 5;
                    mainVolumeScrollbar.value = MainData.playerSettings[MainData.currentPlayerSession].mainVolume / 100f;
                }
            }
            GameSounds.UpdateVolumes();
            MainMenuRender.RenderSettingsModal();
        }

        public void ChangeRightMainVolume()
        {
            if (MainData.currentPlayerSession == -1)
            {
                if (MainData.defaultPlayerSetting.mainVolume < 96)
                {
                    MainData.defaultPlayerSetting.mainVolume += 5;
                    mainVolumeScrollbar.value = MainData.defaultPlayerSetting.mainVolume / 100f;
                }
            }
            else
            {
                if (MainData.playerSettings[MainData.currentPlayerSession].mainVolume < 96)
                {
                    MainData.playerSettings[MainData.currentPlayerSession].mainVolume += 5;
                    mainVolumeScrollbar.value = MainData.playerSettings[MainData.currentPlayerSession].mainVolume / 100f;
                }
            }
            GameSounds.UpdateVolumes();
            MainMenuRender.RenderSettingsModal();
        }

        // Music Volume
        public void ChangeLeftMusicVolume()
        {
            if (MainData.currentPlayerSession == -1)
            {
                if (MainData.defaultPlayerSetting.musicVolume > 4)
                {
                    MainData.defaultPlayerSetting.musicVolume -= 5;
                    musicVolumeScrollbar.value = MainData.defaultPlayerSetting.musicVolume / 100f;
                }
            }
            else
            {
                if (MainData.playerSettings[MainData.currentPlayerSession].musicVolume > 4)
                {
                    MainData.playerSettings[MainData.currentPlayerSession].musicVolume -= 5;
                    musicVolumeScrollbar.value = MainData.playerSettings[MainData.currentPlayerSession].musicVolume / 100f;
                }
            }
            GameSounds.UpdateVolumes();
            MainMenuRender.RenderSettingsModal();
        }

        public void ChangeRightMusicVolume()
        {
            if (MainData.currentPlayerSession == -1)
            {
                if (MainData.defaultPlayerSetting.musicVolume < 96)
                {
                    MainData.defaultPlayerSetting.musicVolume += 5;
                    musicVolumeScrollbar.value = MainData.defaultPlayerSetting.musicVolume / 100f;
                }
            }
            else
            {
                if (MainData.playerSettings[MainData.currentPlayerSession].musicVolume < 96)
                {
                    MainData.playerSettings[MainData.currentPlayerSession].musicVolume += 5;
                    musicVolumeScrollbar.value = MainData.playerSettings[MainData.currentPlayerSession].musicVolume / 100f;
                }
            }
            GameSounds.UpdateVolumes();
            MainMenuRender.RenderSettingsModal();
        }

        // Click Sound
        public void ChangeLeftClickSound()
        {
            if (MainData.currentPlayerSession == -1)
            {
                if (MainData.defaultPlayerSetting.clickSound > 4)
                {
                    MainData.defaultPlayerSetting.clickSound -= 5;
                    clickSoundScrollbar.value = MainData.defaultPlayerSetting.clickSound / 100f;
                }
            }
            else
            {
                if (MainData.playerSettings[MainData.currentPlayerSession].clickSound > 4)
                {
                    MainData.playerSettings[MainData.currentPlayerSession].clickSound -= 5;
                    clickSoundScrollbar.value = MainData.playerSettings[MainData.currentPlayerSession].clickSound / 100f;
                }
            }
            GameSounds.UpdateVolumes();
            MainMenuRender.RenderSettingsModal();
        }

        public void ChangeRightClickSound()
        {
            if (MainData.currentPlayerSession == -1)
            {
                if (MainData.defaultPlayerSetting.clickSound < 96)
                {
                    MainData.defaultPlayerSetting.clickSound += 5;
                    clickSoundScrollbar.value = MainData.defaultPlayerSetting.clickSound / 100f;
                }
            }
            else
            {
                if (MainData.playerSettings[MainData.currentPlayerSession].clickSound < 96)
                {
                    MainData.playerSettings[MainData.currentPlayerSession].clickSound += 5;
                    clickSoundScrollbar.value = MainData.playerSettings[MainData.currentPlayerSession].clickSound / 100f;
                }
            }
            GameSounds.UpdateVolumes();
            MainMenuRender.RenderSettingsModal();
        }

        // Hover Sound
        public void ChangeLeftHoverSound()
        {
            if (MainData.currentPlayerSession == -1)
            {
                if (MainData.defaultPlayerSetting.hoverSound > 4)
                {
                    MainData.defaultPlayerSetting.hoverSound -= 5;
                    hoverSoundScrollbar.value = MainData.defaultPlayerSetting.hoverSound / 100f;
                }
            }
            else
            {
                if (MainData.playerSettings[MainData.currentPlayerSession].hoverSound > 4)
                {
                    MainData.playerSettings[MainData.currentPlayerSession].hoverSound -= 5;
                    hoverSoundScrollbar.value = MainData.playerSettings[MainData.currentPlayerSession].hoverSound / 100f;
                }
            }
            GameSounds.UpdateVolumes();
            MainMenuRender.RenderSettingsModal();
        }

        public void ChangeRightHoverSound()
        {
            if (MainData.currentPlayerSession == -1)
            {
                if (MainData.defaultPlayerSetting.hoverSound < 96)
                {
                    MainData.defaultPlayerSetting.hoverSound += 5;
                    hoverSoundScrollbar.value = MainData.defaultPlayerSetting.hoverSound / 100f;
                }
            }
            else
            {
                if (MainData.playerSettings[MainData.currentPlayerSession].hoverSound < 96)
                {
                    MainData.playerSettings[MainData.currentPlayerSession].hoverSound += 5;
                    hoverSoundScrollbar.value = MainData.playerSettings[MainData.currentPlayerSession].hoverSound / 100f;
                }
            }
            GameSounds.UpdateVolumes();
            MainMenuRender.RenderSettingsModal();
        }

        /*
         * ===================================================
         * Edit settings via the scrollbars in Volume Settings
         * ===================================================
        */

        // Main Volume
        public void ChangeMainVolumeIndex(float index)
        {
            if (MainData.currentPlayerSession == -1)
            {
                MainData.defaultPlayerSetting.mainVolume = Mathf.RoundToInt(index * 100f);
            }
            else
            {
                MainData.playerSettings[MainData.currentPlayerSession].mainVolume = Mathf.RoundToInt(index * 100f);
            }
            GameSounds.UpdateVolumes();
            MainMenuRender.RenderSettingsModal();
        }

        // Music Volume
        public void ChangeMusicVolumeIndex(float index)
        {
            if (MainData.currentPlayerSession == -1)
            {
                MainData.defaultPlayerSetting.musicVolume = Mathf.RoundToInt(index * 100f);
            }
            else
            {
                MainData.playerSettings[MainData.currentPlayerSession].musicVolume = Mathf.RoundToInt(index * 100f);
            }
            GameSounds.UpdateVolumes();
            MainMenuRender.RenderSettingsModal();
        }

        // Click Sound
        public void ChangeClickSoundIndex(float index)
        {
            if (MainData.currentPlayerSession == -1)
            {
                MainData.defaultPlayerSetting.clickSound = Mathf.RoundToInt(index * 100f);
            }
            else
            {
                MainData.playerSettings[MainData.currentPlayerSession].clickSound = Mathf.RoundToInt(index * 100f);
            }
            GameSounds.UpdateVolumes();
            MainMenuRender.RenderSettingsModal();
        }

        // Hover Sound
        public void ChangeHoverSoundIndex(float index)
        {
            if (MainData.currentPlayerSession == -1)
            {
                MainData.defaultPlayerSetting.hoverSound = Mathf.RoundToInt(index * 100f);
            }
            else
            {
                MainData.playerSettings[MainData.currentPlayerSession].hoverSound = Mathf.RoundToInt(index * 100f);
            }
            GameSounds.UpdateVolumes();
            MainMenuRender.RenderSettingsModal();
        }
    }
}