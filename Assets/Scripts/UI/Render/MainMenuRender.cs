using TMPro;
using UnityEngine;
using Data.Core;
using UnityEngine.UI;
using System;

namespace UI.Render
{
    public static class MainMenuRender
    {
        /*
         * ===================================================
         * Variables for displaying session names in the main menu
         * ===================================================
        */
        private static TextMeshProUGUI[] sessionNames = new TextMeshProUGUI[3];

        /*
         * ===================================================
         * Variables for rendering the Record Modal
         * ===================================================
        */
        private static GameObject[] records = new GameObject[10];

        // Variables for displaying flag counts and penalty records
        private static TextMeshProUGUI[] flagCount = new TextMeshProUGUI[10];
        private static TextMeshProUGUI[] penaltyRecords = new TextMeshProUGUI[10];

        private static RawImage[][] flagRecords = new RawImage[10][] { new RawImage[16], new RawImage[16], 
                                                                    new RawImage[16], new RawImage[16], 
                                                                    new RawImage[16], new RawImage[16], 
                                                                    new RawImage[16], new RawImage[16], 
                                                                    new RawImage[16], new RawImage[16] };

        // Names of the flags corresponding to their indices
        private static string[] flagNames = new string[16]
        {
            "Aether", "Zenith", "Terra", "Zephyr",
            "Nimbus", "Bolt", "Glacier", "Abyss",
            "Resonance", "Aion", "Chrono", "Selene",
            "Solstice", "Grimoire", "Harmonia", "Yggdrasil"
        };

        // References to all flag textures
        private static Texture nullFlag;
        private static Texture[] allFlags = new Texture[16];


        /*
         * ===================================================
         * And variables for rendering the Settings Modal
         * ===================================================
        */
        private static RawImage displayModeImage;
        private static RawImage resolutionImage;
        private static RawImage vsyncImage;

        private static TextMeshProUGUI mainVolumeText;
        private static TextMeshProUGUI musicVolumeText;
        private static TextMeshProUGUI clickSoundText;
        private static TextMeshProUGUI hoverSoundText;

        // Array of textures for different settings options
        private static Texture[] displayModeTextrues = new Texture[2];
        private static Texture[] resolutionTextures = new Texture[4];
        private static Texture[] vsyncTextures = new Texture[2];

        public static void Initialize()
        {
            /*
             * ===================================================
             * Initialize objects for displaying session names in the main menu
             * ===================================================
            */
            if (sessionNames[0] == null)
            {
                for (int i = 0; i < 3; i++)
                {
                    string objectPath = $"Canvas/MainMenu/Main/DisplayName/Session_{i + 1}/NameDisplay";
                    GameObject sessionTextObject = GameObject.Find(objectPath);
                    sessionNames[i] = sessionTextObject.GetComponent<TextMeshProUGUI>();
                }
            }

            /*
             * ===================================================
             * Function to initialize objects for rendering the Record Modal
             * ===================================================
            */

            // Initialize record GameObjects if not already initialized
            if (records[0] == null)
            {
                for (int i = 0; i < 10; i++)
                {
                    string recordPath = $"Canvas/MainMenu/Modal/TopRecords/ScrollView/Viewport/Content/Record_{i + 1}";
                    records[i] = GameObject.Find(recordPath);
                }
            }

            // Initialize TextMeshProUGUI objects for displaying flag counts if not already initialized
            if (flagCount[0] == null)
            {
                for (int i = 0; i < 10; i++)
                {
                    string flagCountPath = $"Canvas/MainMenu/Modal/TopRecords/ScrollView/Viewport/Content/Record_{i + 1}/FlagRecord";
                    GameObject flagCountObject = GameObject.Find(flagCountPath);
                    flagCount[i] = flagCountObject.GetComponent<TextMeshProUGUI>();
                }
            }

            // Initialize RawImage objects for displaying flag records if not already initialized
            if (flagRecords[0][0] == null)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        string flagImagePath = $"Canvas/MainMenu/Modal/TopRecords/ScrollView/Viewport/Content/Record_{i + 1}/Flags/Unit{j + 1}";
                        GameObject flagImageObject = GameObject.Find(flagImagePath);
                        flagRecords[i][j] = flagImageObject.GetComponent<RawImage>();
                    }
                }
            }

            // Initialize TextMeshProUGUI objects for displaying penalty records if not already initialized
            if (penaltyRecords[0] == null)
            {
                for (int i = 0; i < 10; i++)
                {
                    string penaltyRecordPath = $"Canvas/MainMenu/Modal/TopRecords/ScrollView/Viewport/Content/Record_{i + 1}/PenaltyRecord";
                    GameObject penaltyRecordObject = GameObject.Find(penaltyRecordPath);
                    penaltyRecords[i] = penaltyRecordObject.GetComponent<TextMeshProUGUI>();
                }
            }

            // Read flag textures from Resources if not already initialized
            if (allFlags[0] == null)
            {
                for (int i = 0; i < 16; i++)
                {
                    allFlags[i] = Resources.Load<Texture>($"Textures/Flag/RecordFlag/{flagNames[i]}");
                }
                nullFlag = Resources.Load<Texture>("Textures/Flag/RecordFlag/_Null");
            }

            /*
             * ===================================================
             * Function to initialize objects for rendering the Settings Modal
             * ===================================================
            */
            if (displayModeImage == null)
            {
                string displayModePath = "Canvas/MainMenu/Modal/Settings/ScrollView/Viewport/Content/DisplayMode/Display";
                GameObject displayModeObject = GameObject.Find(displayModePath);
                displayModeImage = displayModeObject.GetComponent<RawImage>();
            }
            if (resolutionImage == null)
            {
                string resolutionPath = "Canvas/MainMenu/Modal/Settings/ScrollView/Viewport/Content/Resolution/Display";
                GameObject resolutionObject = GameObject.Find(resolutionPath);
                resolutionImage = resolutionObject.GetComponent<RawImage>();
            }
            if (vsyncImage == null)
            {
                string vsyncPath = "Canvas/MainMenu/Modal/Settings/ScrollView/Viewport/Content/Vsync/Display";
                GameObject vsyncObject = GameObject.Find(vsyncPath);
                vsyncImage = vsyncObject.GetComponent<RawImage>();
            }

            if (mainVolumeText == null)
            {
                string mainVolumePath = "Canvas/MainMenu/Modal/Settings/ScrollView/Viewport/Content/MainVolume/Display";
                GameObject mainVolumeObject = GameObject.Find(mainVolumePath);
                mainVolumeText = mainVolumeObject.GetComponent<TextMeshProUGUI>();
            }
            if (musicVolumeText == null)
            {
                string musicVolumePath = "Canvas/MainMenu/Modal/Settings/ScrollView/Viewport/Content/MusicVolume/Display";
                GameObject musicVolumeObject = GameObject.Find(musicVolumePath);
                musicVolumeText = musicVolumeObject.GetComponent<TextMeshProUGUI>();
            }
            if (clickSoundText == null)
            {
                string clickSoundPath = "Canvas/MainMenu/Modal/Settings/ScrollView/Viewport/Content/ClickSound/Display";
                GameObject clickSoundObject = GameObject.Find(clickSoundPath);
                clickSoundText = clickSoundObject.GetComponent<TextMeshProUGUI>();
            }
            if (hoverSoundText == null)
            {
                string hoverSoundPath = "Canvas/MainMenu/Modal/Settings/ScrollView/Viewport/Content/HoverSound/Display";
                GameObject hoverSoundObject = GameObject.Find(hoverSoundPath);
                hoverSoundText = hoverSoundObject.GetComponent<TextMeshProUGUI>();
            }

            // Read setting option textures from Resources if not already initialized
            if (displayModeTextrues[0] == null)
            {
                displayModeTextrues[0] = Resources.Load<Texture>("Textures/UI/MainMenu/Modal/Settings/DisplayMode/Windowed");
                displayModeTextrues[1] = Resources.Load<Texture>("Textures/UI/MainMenu/Modal/Settings/DisplayMode/Fullscreen");
                resolutionTextures[0] = Resources.Load<Texture>("Textures/UI/MainMenu/Modal/Settings/Resolution/Low");
                resolutionTextures[1] = Resources.Load<Texture>("Textures/UI/MainMenu/Modal/Settings/Resolution/Medium");
                resolutionTextures[2] = Resources.Load<Texture>("Textures/UI/MainMenu/Modal/Settings/Resolution/High");
                resolutionTextures[3] = Resources.Load<Texture>("Textures/UI/MainMenu/Modal/Settings/Resolution/Ultra");
                vsyncTextures[0] = Resources.Load<Texture>("Textures/UI/MainMenu/Modal/Settings/Vsync/Off");
                vsyncTextures[1] = Resources.Load<Texture>("Textures/UI/MainMenu/Modal/Settings/Vsync/On");
            }
        }

        /*
         * ===================================================
         * Function to change the color of session name texts
         * ===================================================
        */
        public static void ChangeNameTextColor()
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == MainData.currentPlayerSession)
                {
                    sessionNames[i].color = new Color32(87, 88, 95, 200);
                }
                else
                {
                    sessionNames[i].color = new Color32(223, 228, 246, 255);
                }
            }
        }


        public static void ChangeDisplayName()
        {
            for (int i = 0; i < 3; i++)
            {
                if (MainData.nameSessions[i] != "null")
                {
                    sessionNames[i].text = "[" + MainData.nameSessions[i] + "]";
                }
            }
        }

        /*
         * ===================================================
         * Function to render the Record Modal
         * ===================================================
        */
        public static void RenderRecordModal()
        {   
            for (int i = 0; i < 10; i++)
            {
                records[i].SetActive(false);
            }

            if (MainData.currentPlayerSession == -1)
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                if (MainData.playerReccords[MainData.currentPlayerSession][i].penalty == 0)
                {
                    break;
                }

                records[i].SetActive(true);

                // Edit number of flags text
                string countText = flagCount[i].text;
                string parts = countText.Split(':')[0];
                flagCount[i].text = parts + ": " + MainData.playerReccords[MainData.currentPlayerSession][i].numberOfFlags.ToString();

                // Edit flag images
                for (int j = 0; j < 16; j++)
                {
                    if (MainData.playerReccords[MainData.currentPlayerSession][i].flags[j] == true)
                    {             
                        flagRecords[i][j].texture = allFlags[j];
                    }
                    else
                    {
                        flagRecords[i][j].texture = nullFlag;
                    }
                }

                // Edit penalty record text
                string penaltyText = penaltyRecords[i].text;
                string penaltyParts = penaltyText.Split(':')[0];
                penaltyRecords[i].text = penaltyParts + ": " + MainData.playerReccords[MainData.currentPlayerSession][i].penalty.ToString();
            }
        }

        /*
         * ===================================================
         * Function to render the Settings Modal
         * ===================================================
        */
        public static void RenderSettingsModal()
        {
            if (MainData.currentPlayerSession == -1)
            {   
                displayModeImage.texture = displayModeTextrues[Convert.ToInt32(MainData.defaultPlayerSetting.displayMode)];
                resolutionImage.texture = resolutionTextures[MainData.defaultPlayerSetting.resolution];
                vsyncImage.texture = vsyncTextures[Convert.ToInt32(MainData.defaultPlayerSetting.vsync)];
                mainVolumeText.text = MainData.defaultPlayerSetting.mainVolume.ToString() + "%";
                musicVolumeText.text = MainData.defaultPlayerSetting.musicVolume.ToString() + "%";
                clickSoundText.text = MainData.defaultPlayerSetting.clickSound.ToString() + "%";
                hoverSoundText.text = MainData.defaultPlayerSetting.hoverSound.ToString() + "%";
            }
            else
            {
                displayModeImage.texture = displayModeTextrues[Convert.ToInt32(MainData.playerSettings[MainData.currentPlayerSession].displayMode)];
                resolutionImage.texture = resolutionTextures[MainData.playerSettings[MainData.currentPlayerSession].resolution];
                vsyncImage.texture = vsyncTextures[Convert.ToInt32(MainData.playerSettings[MainData.currentPlayerSession].vsync)];
                mainVolumeText.text = MainData.playerSettings[MainData.currentPlayerSession].mainVolume.ToString() + "%";
                musicVolumeText.text = MainData.playerSettings[MainData.currentPlayerSession].musicVolume.ToString() + "%";
                clickSoundText.text = MainData.playerSettings[MainData.currentPlayerSession].clickSound.ToString() + "%";
                hoverSoundText.text = MainData.playerSettings[MainData.currentPlayerSession].hoverSound.ToString() + "%";
                MainData.WriteSettingData();
            }    
        }
    }
}
