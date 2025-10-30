using UI.Movement;
using UnityEngine;

namespace Core.MainMenu
{   
    public class Support : MonoBehaviour
    {
        public CardMovement supportCard;

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