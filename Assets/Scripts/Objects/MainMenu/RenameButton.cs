using UnityEngine;
using Data.Core;
using TMPro;
using UI.Movement;
using UI.Render;

namespace Objects.MainMenu
{
    public class RenameButton : MonoBehaviour
    {
        public int buttonIndex;
        public MenuMovement setName;

        public void ClickRenameButton()
        {
            MainData.currentPlayerSession = buttonIndex;

            // Đổi màu chữ của các chữ trở lại màu mặc định và màu của chữ của phiên chơi hiện tại thành màu đặc biệt
            MainMenuRender.ChangeNameTextColor(buttonIndex);

            // Kiểm tra xem có tên phiên chơi không, nếu không có thì mở menu đặt tên
            if (MainData.nameSessions[buttonIndex] == "null")
            {
                setName.MoveToScreen();
            }
        }
    }
}