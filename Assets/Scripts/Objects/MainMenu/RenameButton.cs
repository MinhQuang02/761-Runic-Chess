using UnityEngine;
using Data.Core;
using TMPro;

namespace Objects.MainMenu
{
    public class RenameButton : MonoBehaviour
    {
        public int buttonIndex;
        public TextMeshProUGUI[] sessionName = new TextMeshProUGUI [3];

        public void clickRenameButton()
        {
            MainData.currentPlayerSession = buttonIndex;

            // Đổi màu chữ của các chữ trở lại màu mặc định và màu của chữ của phiên chơi hiện tại thành màu đặc biệt
            for (int i = 0; i < 3; i++)
            {
                if (i == MainData.currentPlayerSession)
                {
                    // Màu xanh đậm đặc biệt
                    sessionName[i].color = new Color32(87, 88, 95, 200);
                }
                else
                {
                    sessionName[i].color = new Color32(223, 228, 246, 255); // Màu trắng mặc định
                }
            }
        }
    }
}