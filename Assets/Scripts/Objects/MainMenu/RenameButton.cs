using UnityEngine;
using Data.Core;
using UI.Movement;
using UI.Render;

namespace Objects.MainMenu
{
    public class RenameButton : MonoBehaviour
    {
        public int buttonIndex;
        public MenuMovement setName;
        public OptionMovement continueOption;
        public OptionMovement newGameOption;

        public void ClickRenameButton()
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

            }    
        }
    }
}