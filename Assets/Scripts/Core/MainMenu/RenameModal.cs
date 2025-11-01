using TMPro;
using UnityEngine;
using Data.Core;
using UI.Movement;
using UI.Render;

namespace Core.MainMenu
{
    public class RenameModal : MonoBehaviour
    {
        /*
         * ===================================================
         * Using Singleton Pattern to ensure only one instance of RenameModal exists
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
         * Declare all the variables used in the Rename Modal
         * ===================================================
        */
        [SerializeField] private TMP_InputField nameField;
        [SerializeField] private MenuMovement renameModal;
        [SerializeField] private Settings updateSettings;

        /*
         * ===================================================
         * Events in the Rename Modal
         * ===================================================
        */
        public void ConfirmRename()
        {
            if (!string.IsNullOrEmpty(nameField.text))
            {
                // Standardize the name: first letter uppercase, rest lowercase
                string inputName = nameField.text;
                string standardizedName = char.ToUpper(inputName[0]) + inputName.Substring(1).ToLower();
                nameField.text = standardizedName;

                // Update the name in MainData and write to session data
                MainData.nameSessions[MainData.currentPlayerSession] = nameField.text;
                MainData.WriteSessionData();

                // Delete the content in the input field after confirming
                nameField.text = "";

                // Re-render the settings and main menu to reflect the name change
                updateSettings.RenderSettings();
                MainMenuRender.ChangeDisplayName();
                MainMenuRender.RenderSettingsModal();

                // Move the rename modal off-screen
                renameModal.MoveOffScreen();
            }
        }

        public void ExitRenameModal()
        {
            // Delete the content in the input field when exiting
            nameField.text = "";

            // Change the current player session to -1 (no selection)
            MainData.currentPlayerSession = -1;

            // Re-render the settings and main menu to reflect the exit action
            updateSettings.RenderSettings();
            MainMenuRender.ChangeNameTextColor();
            MainMenuRender.RenderRecordModal();
            
            // Move the rename modal off-screen
            renameModal.MoveOffScreen();
        }
    }
}