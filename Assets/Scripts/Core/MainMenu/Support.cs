using UI.Movement;
using UnityEngine;

namespace Core.MainMenu
{   
    public class Support : MonoBehaviour
    {
        private static GameObject Instance;
        public CardMovement supportCard;

        public void Awake()
        {
            // Singleton pattern
            if (Instance == null)
            {
                Instance = this.gameObject;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

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