using UnityEngine;
using UI.Movement;

namespace Core.MainMenu
{
    public class MenuOptions : MonoBehaviour
    {
        /*
         * ===================================================
         * Using Singleton Pattern to ensure only one instance of MenuOptions exists
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
         * Declare all the Modals used in the Main Menu to Movement
         * ===================================================
        */
        [SerializeField] private MenuMovement topRecordsModal;
        [SerializeField] private MenuMovement patchNotesModal;
        [SerializeField] private MenuMovement settingsModal;

        /*
         * ===================================================
         * Top Records: Menu Options
         * ===================================================
        */
        public void OpenTopRecords()
        {
            topRecordsModal.MoveToScreen();
        }

        public void CloseTopRecords()
        {
            topRecordsModal.MoveOffScreen();
        }

        /*
         * ===================================================
         * Patch Notes: Menu Options
         * ===================================================
        */
        public void OpenPatchNotes()
        {
            patchNotesModal.MoveToScreen();
        }

        public void ClosePatchNotes()
        {
            patchNotesModal.MoveOffScreen();
        }

        /*
         * ===================================================
         * Settings: Menu Options
         * ===================================================
        */
        public void OpenSettings()
        {
            settingsModal.MoveToScreen();
        }

        public void CloseSettings()
        {
            settingsModal.MoveOffScreen();
        }

        /*
         * ===================================================
         * Quit: Menu Options
         * ===================================================
        */
        public void QuitGame()
        {
            Application.Quit();
        }
    }

}