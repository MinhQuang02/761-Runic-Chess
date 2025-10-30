using UnityEngine;
using Data.Core;
using UI.Movement;
using UI.Render;

namespace Core.MainMenu
{
    public class RenameButton : MonoBehaviour
    {
        public MenuMovement setName;
        public OptionMovement continueOption;
        public OptionMovement newGameOption;

        public void ClickRenameButton(int buttonIndex)
        {
            MainData.currentPlayerSession = buttonIndex;

            // Đổi màu chữ của các chữ trở lại màu mặc định và màu của chữ của phiên chơi hiện tại thành màu đặc biệt
            MainMenuRender.ChangeNameTextColor(buttonIndex);

            // Cập nhập lại trạng thái của option display
            continueOption.MoveToDefault();
            newGameOption.MoveToDefault();
            if (MainData.isContinue[buttonIndex] == true)
            {
                continueOption.MoveToDestination();
            }
            else
            {
                newGameOption.MoveToDestination();
            }

            // Kiểm tra xem có tên phiên chơi không, nếu không có thì mở menu đặt tên
            if (MainData.nameSessions[buttonIndex] == "null")
            {
                setName.MoveToScreen();
            }
            else
            {
                // Test thử tính năng trên modal record
                MainData.playerReccords[MainData.currentPlayerSession][0].numberOfFlags = 4;
                MainData.playerReccords[MainData.currentPlayerSession][0].penalty = 100;

                MainData.playerReccords[MainData.currentPlayerSession][0].flags[0] = true;
                MainData.playerReccords[MainData.currentPlayerSession][0].flags[1] = true;
                MainData.playerReccords[MainData.currentPlayerSession][0].flags[2] = true;
                MainData.playerReccords[MainData.currentPlayerSession][0].flags[4] = true;

                MainMenuRender.RenderRecordModal();
            }
        }
    }
}