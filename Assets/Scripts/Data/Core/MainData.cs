using UnityEngine;

namespace Data.Core
{   
    public static class MainData
    {
        /*
         * ===================================================
         * Tổ chức dữ liệu người chơi
         * ===================================================
        */

        // Dữ liệu mặc định của người chơi (phiên chơi bắt đầu từ -1)
        public static int currentPlayerSession = -1;
        public static PlayerSetting defaultPlayerSetting = new PlayerSetting(0);

        // Dữ liệu ánh xạ với từng phiên chơi của người chơi
        public static string[] nameSessions = new string[3] { "null", "null", "null" };
        public static bool[] isContinue = new bool[3] { false, false, false };
        public static bool[] isMapOrBattlefield = new bool[3] { false, false, false };
        public static bool[] isStartPrep = new bool[3] {false, false, false };

        public static PlayerReccord[][] playerReccords = new PlayerReccord[3][]
        {
            new PlayerReccord[10],
            new PlayerReccord[10],
            new PlayerReccord[10]
        };

        public static PlayerSetting[] playerSettings = new PlayerSetting[3]
        {
            new PlayerSetting(0),
            new PlayerSetting(0),
            new PlayerSetting(0)
        };

        /*
         * ===================================================
         * Hàm đọc dữ liệu người chơi từ PlayerPrefs
         * ===================================================
        */
        public static void ReadMainData()
        {
            // Đọc vào từ PlayerPrefs dữ liệu sessions_i có cấu trúc là null-0-0-0
            for (int i = 0; i < 3; i++)
            {
                // Đọc dữ liệu phiên chơi của người chơi i
                string sessionsData = PlayerPrefs.GetString("sessions_" + i, "null-0-0-0");
                string[] sessionsParts = sessionsData.Split('-');

                nameSessions[i] = sessionsParts[0];
                isContinue[i] = (sessionsParts[1] == "1");              
                isMapOrBattlefield[i] = (sessionsParts[2] == "1");   
                isStartPrep[i] = (sessionsParts[3] == "1");

                // Đọc dữ liệu reccord của người chơi i
                string reccordData = PlayerPrefs.GetString("reccords_" + i, "[0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0]-" +
                                                                            "[0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0]-" +
                                                                            "[0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0]-" +
                                                                            "[0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0]-" +
                                                                            "[0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0]-" +
                                                                            "[0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0]-" +
                                                                            "[0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0]-" +
                                                                            "[0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0]-" +
                                                                            "[0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0]-" +
                                                                            "[0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0]");

                string[] recordParts = reccordData.Split('-');

                for (int j = 0; j < 10; j++)
                {
                    string recordPart = recordParts[j].Trim(new char[] { '[', ']' });
                    string[] recordValues = recordPart.Split('|');
                    PlayerReccord record = new PlayerReccord(0);
                    
                    for (int k = 0; k < 16; k++)
                    {
                        record.flags[k] = (recordValues[k] == "1");

                        // Đếm giá trị của numberOfFlags
                        if (record.flags[k] == true)
                        {
                            record.numberOfFlags++; 
                        }
                    }

                    record.penalty = int.Parse(recordValues[16]);
                    playerReccords[i][j] = record;
                }

                // Đọc dữ liệu setting của người chơi i
                string settingData = PlayerPrefs.GetString("settings_" + i, "1-2-1-70-70-70-70");
                string[] settingParts = settingData.Split('-');

                PlayerSetting setting = new PlayerSetting(0);
                setting.displayMode = (settingParts[0] == "1");
                setting.resolution = int.Parse(settingParts[1]);
                setting.vsync = (settingParts[2] == "1");
                setting.mainVolume = int.Parse(settingParts[3]);
                setting.musicVolume = int.Parse(settingParts[4]);
                setting.clickSound = int.Parse(settingParts[5]);
                setting.hoverSound = int.Parse(settingParts[6]);

                playerSettings[i] = setting;
            }
        }

        /*
         * ===================================================
         * Hàm ghi dữ liệu người chơi vào PlayerPrefs
         * ===================================================
        */
        public static void WriteMainData()
        {
            for (int i = 0; i < 3; i++)
            {
                // Ghi dữ liệu phiên chơi của người chơi i
                string sessionsData = nameSessions[i] + "-" +
                                      (isContinue[i] ? "1" : "0") + "-" +
                                      (isMapOrBattlefield[i] ? "1" : "0") + "-" +
                                      (isStartPrep[i] ? "1" : "0");
                PlayerPrefs.SetString("sessions_" + i, sessionsData);

                // Ghi dữ liệu reccord của người chơi i
                string reccordData = "";
                for (int j = 0; j < 10; j++)
                {
                    PlayerReccord reccord = playerReccords[i][j];
                    string recordPart = "[";
                    for (int k = 0; k < 16; k++)
                    {
                        recordPart += (reccord.flags[k] ? "1" : "0") + "|";
                    }
                    recordPart += reccord.penalty.ToString() + "]";
                    reccordData += recordPart;
                    if (j < 9)
                    {
                        reccordData += "-";
                    }
                }
                PlayerPrefs.SetString("reccords_" + i, reccordData);

                // Ghi dữ liệu setting của người chơi i
                PlayerSetting setting = playerSettings[i];
                string settingData = (setting.displayMode ? "1" : "0") + "-" +
                                     setting.resolution.ToString() + "-" +
                                     (setting.vsync ? "1" : "0") + "-" +
                                     setting.mainVolume.ToString() + "-" +
                                     setting.musicVolume.ToString() + "-" +
                                     setting.clickSound.ToString() + "-" +
                                     setting.hoverSound.ToString();
                PlayerPrefs.SetString("settings_" + i, settingData);
            }

            PlayerPrefs.Save();
        }

        // Hàm ghi dữ liệu người chơi hiện tại vào PlayerPrefs
        public static void WriteSessionData()
        {
            // Ghi dữ liệu phiên chơi của người chơi i
            string sessionsData = nameSessions[currentPlayerSession] + "-" +
                                  (isContinue[currentPlayerSession] ? "1" : "0") + "-" +
                                  (isMapOrBattlefield[currentPlayerSession] ? "1" : "0") + "-" +
                                  (isStartPrep[currentPlayerSession] ? "1" : "0");
            PlayerPrefs.SetString("sessions_" + currentPlayerSession, sessionsData);
            PlayerPrefs.Save();
        }

        // Hàm ghi dữ liệu reccord của người chơi hiện tại vào PlayerPrefs
        public static void WriteReccordData()
        {
            // Ghi dữ liệu reccord của người chơi i
            string reccordData = "";
            for (int j = 0; j < 10; j++)
            {
                PlayerReccord reccord = playerReccords[currentPlayerSession][j];
                string recordPart = "[";
                for (int k = 0; k < 16; k++)
                {
                    recordPart += (reccord.flags[k] ? "1" : "0") + "|";
                }
                recordPart += reccord.penalty.ToString() + "]";
                reccordData += recordPart;
                if (j < 9)
                {
                    reccordData += "-";
                }
            }
            PlayerPrefs.SetString("reccords_" + currentPlayerSession, reccordData);
            PlayerPrefs.Save();
        }

        // Hàm ghi dữ liệu setting của người chơi hiện tại vào PlayerPrefs
        public static void WriteSettingData()
        {
            // Ghi dữ liệu setting của người chơi i
            PlayerSetting setting = playerSettings[currentPlayerSession];
            string settingData = (setting.displayMode ? "1" : "0") + "-" +
                                 setting.resolution.ToString() + "-" +
                                 (setting.vsync ? "1" : "0") + "-" +
                                 setting.mainVolume.ToString() + "-" +
                                 setting.musicVolume.ToString() + "-" +
                                 setting.clickSound.ToString() + "-" +
                                 setting.hoverSound.ToString();
            PlayerPrefs.SetString("settings_" + currentPlayerSession, settingData);
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// Cấu trúc dữ liệu lưu trữ thành tích của người chơi
    /// </summary>
    public struct PlayerReccord
    {
        public int numberOfFlags;
        public bool[] flags;
        public int penalty;

        public PlayerReccord(int init = 0)
        {
            numberOfFlags = 0;
            flags = new bool[16] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
            penalty = 0;
        }
    }

    /// <summary>
    /// Cấu trúc dữ liệu lưu trữ cài đặt của người chơi
    /// </summary>
    public struct PlayerSetting
    {
        public bool displayMode;
        public int resolution;
        public bool vsync;
        public int mainVolume;
        public int musicVolume;
        public int clickSound;
        public int hoverSound;

        public PlayerSetting(int init = 0)
        {
            displayMode = true; // true là fullscreen, false là windowed
            resolution = 2; // 0 là Low, 1 là Medium, 2 là High, 3 là Ultra
            vsync = true; // true là bật, false là tắt

            // âm lượng mặc định là 70
            mainVolume = 70; 
            musicVolume = 70;
            clickSound = 70;
            hoverSound = 70;
        }
    }
}