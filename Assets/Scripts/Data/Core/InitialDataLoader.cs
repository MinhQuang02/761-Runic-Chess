using UnityEngine;
using UI.Movement;
using UI.Render;

namespace Data.Core
{
    public class InitialDataLoader : MonoBehaviour
    {
        public MenuMovement mainMenu;

        // Cập nhập lần đầu để nạp data khi game chạy
        void Awake()
        {
            mainMenu.MoveToScreen();
            MainData.ReadMainData();
            MainMenuRender.Initialize();
            MainMenuRender.ChangeDisplayName();
        }

    }
}

