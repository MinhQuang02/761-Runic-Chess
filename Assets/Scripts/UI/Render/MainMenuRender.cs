using TMPro;
using UnityEngine;

namespace UI.Render
{
    public static class MainMenuRender
    {
        public static TextMeshProUGUI[] sessionNames = new TextMeshProUGUI[3];

        public static void Initialize()
        {
            // Khởi tạo các đối tượng TextMeshProUGUI nếu chưa được khởi tạo
            if (sessionNames[0] == null)
            {
                for (int i = 0; i < 3; i++)
                {
                    string objectPath = $"Canvas/MainMenu/Main/DisplayName/Session_{i + 1}/NameDisplay";
                    GameObject sessionTextObject = GameObject.Find(objectPath);
                    sessionNames[i] = sessionTextObject.GetComponent<TextMeshProUGUI>();
                }
            }
        }

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


        public static void ChangeDisplayName(string[] session_name)
        {
            for (int i = 0; i < 3; i++)
            {
                if (session_name[i] != "null")
                {
                    sessionNames[i].text = "[" + session_name[i] + "]";
                }
            }
        }
    }
}
