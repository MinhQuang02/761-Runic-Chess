using UnityEngine;
using Data.Core;
using UI.Movement;
using UI.Render;

namespace Core.MainMenu
{
    public class RenameButton : MonoBehaviour
    {
        /*
         * ===================================================
         * Using Singleton Pattern to ensure only one instance of RenameButton exists
         * ===================================================
        */
        private static GameObject Instance;

        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this.gameObject;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        /*
         * ===================================================
         * Declare all the variables used in the Rename Button
         * ===================================================
        */
        [SerializeField] private MenuMovement setName;
        [SerializeField] private OptionMovement continueOption;
        [SerializeField] private OptionMovement newGameOption;
        [SerializeField] private Settings updateSettings;

        /*
         * ===================================================
         * Events after clicking the Rename Button
         * ===================================================
        */
        public void ClickRenameButton(int buttonIndex)
        {
            // Change the current player session to the selected button index and update the name text color
            MainData.currentPlayerSession = buttonIndex;
            MainMenuRender.ChangeNameTextColor();

            // Move the Continue and New Game options to default positions
            continueOption.MoveToDefault();
            newGameOption.MoveToDefault();

            // Check if the selected session is a Continue or New Game option
            if (MainData.isContinue[buttonIndex] == true)
            {
                continueOption.MoveToDestination();
            }
            else
            {
                newGameOption.MoveToDestination();
            }

            // Check if the selected session has a name set or not
            if (MainData.nameSessions[buttonIndex] == "null")
            {
                setName.MoveToScreen();
            }
            else
            {
                updateSettings.RenderSettings();
                MainMenuRender.RenderRecordModal();
                MainMenuRender.RenderSettingsModal();
            }
        }
    }
}