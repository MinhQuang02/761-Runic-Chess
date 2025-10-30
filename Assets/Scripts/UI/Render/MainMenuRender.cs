using TMPro;
using UnityEngine;
using Data.Core;
using UnityEngine.UI;

namespace UI.Render
{
    public static class MainMenuRender
    {
        /*
         * ===================================================
         * Biến mô tả về tên của các phiên chơi để cập nhập
         * ===================================================
        */
        public static TextMeshProUGUI[] sessionNames = new TextMeshProUGUI[3];

        /*
         * ===================================================
         * Các biến mô tả về các đối tượng trong Record Modal
         * ===================================================
        */
        public static GameObject[] records = new GameObject[10];

        // Các biến hiển thị các component trong một object của record
        public static TextMeshProUGUI[] flagCount = new TextMeshProUGUI[10];
        public static TextMeshProUGUI[] penaltyRecords = new TextMeshProUGUI[10];

        public static RawImage[][] flagRecords = new RawImage[10][] { new RawImage[16], new RawImage[16], 
                                                                    new RawImage[16], new RawImage[16], 
                                                                    new RawImage[16], new RawImage[16], 
                                                                    new RawImage[16], new RawImage[16], 
                                                                    new RawImage[16], new RawImage[16] };

        // Tên của các lá cờ
        private static string[] flagNames = new string[16]
        {
            "Aether", "Zenith", "Terra", "Zephyr",
            "Nimbus", "Bolt", "Glacier", "Abyss",
            "Resonance", "Aion", "Chrono", "Selene",
            "Solstice", "Grimoire", "Harmonia", "Yggdrasil"
        };

        // Ảnh của các lá cờ được nhập từ Resources
        public static Texture nullFlag = null;
        public static Texture[] allFlags = new Texture[16];



        public static void Initialize()
        {
            /*
             * ===================================================
             * Khởi tạo các đối tượng TextMeshProUGUI nếu chưa được khởi tạo
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
             * Hàm khởi tạo các đối tượng để render Record Modal
             * ===================================================
            */

            // Khởi tạo các đối tượng record nếu chưa được khởi tạo
            if (records[0] == null)
            {
                for (int i = 0; i < 10; i++)
                {
                    string recordPath = $"Canvas/MainMenu/Modal/TopRecords/ScrollView/Viewport/Content/Record_{i + 1}";
                    records[i] = GameObject.Find(recordPath);
                }
            }

            // Khởi tạo các đối tượng TextMeshProUGUI để hiển thị số cờ nếu chưa được khởi tạo
            if (flagCount[0] == null)
            {
                for (int i = 0; i < 10; i++)
                {
                    string flagCountPath = $"Canvas/MainMenu/Modal/TopRecords/ScrollView/Viewport/Content/Record_{i + 1}/FlagRecord";
                    GameObject flagCountObject = GameObject.Find(flagCountPath);
                    flagCount[i] = flagCountObject.GetComponent<TextMeshProUGUI>();
                }
            }

            // Khởi tạo các đối tượng RawImage nếu chưa được khởi tạo
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

            // Khởi tạo các đối tượng TextMeshProUGUI để hiển thị điểm phạt nếu chưa được khởi tạo
            if (penaltyRecords[0] == null)
            {
                for (int i = 0; i < 10; i++)
                {
                    string penaltyRecordPath = $"Canvas/MainMenu/Modal/TopRecords/ScrollView/Viewport/Content/Record_{i + 1}/PenaltyRecord";
                    GameObject penaltyRecordObject = GameObject.Find(penaltyRecordPath);
                    penaltyRecords[i] = penaltyRecordObject.GetComponent<TextMeshProUGUI>();
                }
            }

            // Đọc các lá cờ từ Resources nếu chưa được khởi tạo
            if (allFlags[0] == null)
            {
                for (int i = 0; i < 16; i++)
                {
                    allFlags[i] = Resources.Load<Texture>($"Textures/Flag/RecordFlag/{flagNames[i]}");
                }
                nullFlag = Resources.Load<Texture>("Textures/Flag/RecordFlag/_Null");
            }
        }

        /*
         * ===================================================
         * Hàm render hiển thị tên phiên chơi với màu sắc đặc biệt kèm với thay đổi tên
         * ===================================================
        */
        public static void ChangeNameTextColor(int buttonIndex)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == buttonIndex)
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
         * Hàm render Record Modal
         * ===================================================
        */
        public static void RenderRecordModal()
        {   
            if (MainData.currentPlayerSession == -1)
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                records[i].SetActive(false);
            }

            for (int i = 0; i < 10; i++)
            {
                if (MainData.playerReccords[MainData.currentPlayerSession][i].penalty == 0)
                {
                    break;
                }

                records[i].SetActive(true);

                // Chỉnh sửa số cờ đã thu thập
                string countText = flagCount[i].text;
                string parts = countText.Split(':')[0];
                flagCount[i].text = parts + ": " + MainData.playerReccords[MainData.currentPlayerSession][i].numberOfFlags.ToString();

                // Chỉnh sửa ảnh cụ thể từng lá cờ
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

                // Chỉnh sửa điểm phạt
                string penaltyText = penaltyRecords[i].text;
                string penaltyParts = penaltyText.Split(':')[0];
                penaltyRecords[i].text = penaltyParts + ": " + MainData.playerReccords[MainData.currentPlayerSession][i].penalty.ToString();
            }
        }
    }
}
