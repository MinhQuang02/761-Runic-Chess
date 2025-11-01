using UnityEngine;
using UI.Movement;
using UI.Render;
using Sounds;

namespace Data.Core
{
    public class InitialDataLoader : MonoBehaviour
    {
        /*
         * ===================================================
         * Using Singleton Pattern to ensure only one instance of InitialDataLoader exists and intialize core data at the start of the game
         * ===================================================
        */
        private static GameObject Instance;
        [SerializeField] private MenuMovement mainMenu;
        
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

            // Read main data from PlayerPrefs
            MainData.ReadMainData();

            // Initialize the static variables
            MainMenuRender.Initialize();
            GameSounds.Initialize();

            // Update display name in main menu
            MainMenuRender.ChangeDisplayName();            

            // Move main menu to screen
            mainMenu.MoveToScreen();
        }

    }
}

