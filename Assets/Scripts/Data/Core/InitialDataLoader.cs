using UnityEngine;
using UI.Movement;
using UI.Render;
using Sounds;

namespace Data.Core
{
    public class InitialDataLoader : MonoBehaviour
    {
        private static GameObject Instance;
        public MenuMovement mainMenu;
        
        void Awake()
        {
            // Singleton pattern
            if (Instance == null)
            {
                Instance = this.gameObject;
            }
            else
            {
                Destroy(this.gameObject);
                return;
            }

            // Đưa menu chính vào vị trí hiển thị
            mainMenu.MoveToScreen();

            // Đọc dữ liệu chính
            MainData.ReadMainData();

            // Khởi tạo hàm render
            MainMenuRender.Initialize();
            MainMenuRender.ChangeDisplayName();

            // Khởi tạo âm thanh
            GameSounds.Initialize();
        }

    }
}

