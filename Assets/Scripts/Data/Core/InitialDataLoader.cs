using UnityEngine;
using UI.Movement;
using UI.Render;

namespace Data.Core
{
    public class InitialDataLoader : MonoBehaviour
    {
        public MenuMovement mainMenu;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            mainMenu.MoveToScreen();
            MainData.ReadMainData();
            MainMenuRender.Initialize();
            MainMenuRender.ChangeDisplayName(MainData.nameSessions);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

