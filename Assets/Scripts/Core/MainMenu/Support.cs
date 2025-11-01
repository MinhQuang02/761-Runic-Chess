using UI.Movement;
using UnityEngine;

namespace Core.MainMenu
{   
    public class Support : MonoBehaviour
    {
        /*
         * ===================================================
         * Using Singleton Pattern to ensure only one instance of Support exists
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
         * Declare the CardMovement for the support card
         * ===================================================
        */
        [SerializeField] private CardMovement supportCard;

        /*
         * ===================================================
         * Event to switch the support card on and off screen and open support links
         * ===================================================
        */
        public void SwitchSupportCard()
        {   
            supportCard.SwitchCard();
        }

        public void OpenSupportLink(string url)
        {
            Application.OpenURL(url);
        }
    }
}