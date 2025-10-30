using TMPro;
using UnityEngine;
using Data.Core;
using UI.Movement;
using UI.Render;

namespace Core.MainMenu
{
    public class RenameModal : MonoBehaviour
    {
        public TMP_InputField nameField;
        public MenuMovement renameModal;
        public void ConfirmRename()
        {
            if (!string.IsNullOrEmpty(nameField.text))
            {
                string inputName = nameField.text;
                string standardizedName = char.ToUpper(inputName[0]) + inputName.Substring(1).ToLower();
                nameField.text = standardizedName;

                MainData.nameSessions[MainData.currentPlayerSession] = nameField.text;

                MainData.WriteSessionData();
                renameModal.MoveOffScreen();
                MainMenuRender.ChangeDisplayName(MainData.nameSessions);

                // Xóa nội dung trong ô nhập liệu sau khi đổi tên
                nameField.text = "";
            }
        }

        public void ExitRenameModal()
        {
            renameModal.MoveOffScreen();
            // Xóa nội dung trong ô nhập liệu khi thoát modal
            nameField.text = "";

            // Chuyển currentPlayerSession về -1 để không chọn phiên chơi nào và màu sắc trở lại bình thường
            MainData.currentPlayerSession = -1;
            MainMenuRender.ChangeNameTextColor(-1);
        }
    }
}