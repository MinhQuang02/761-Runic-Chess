using UnityEngine;

namespace Data.Core
{   
    public static class MainData
    {
        // Dữ liệu mặc định của người chơi (phiên chơi bắt đầu từ -1)
        public static int currentPlayerSession = -1;
        public static PlayerSetting defaultPlayerSetting = new PlayerSetting();

        // Dữ liệu ánh xạ với từng phiên chơi của người chơi
        public static string[] playerSessions = new string[3]; // không có dữ liệu của người chơi -1
        public static bool[] isNewGame = new bool[3] { true, true, true };

        public static PlayerReccord[][] playerReccords = new PlayerReccord[3][]
        {
            new PlayerReccord[10],
            new PlayerReccord[10],
            new PlayerReccord[10]
        };

        public static PlayerSetting[] playerSettings = new PlayerSetting[3]
        {
            new PlayerSetting(),
            new PlayerSetting(),
            new PlayerSetting()
        };

    }


    public struct PlayerReccord
    {
        public int numberOfFlags;
        public int[] flags;
        public int penalty;

        public PlayerReccord(int init = 0)
        {
            numberOfFlags = 0;
            flags = new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            penalty = 0;
        }
    }

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