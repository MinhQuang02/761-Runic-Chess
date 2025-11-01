using UnityEngine;

namespace UI.Movement
{
    public class CardMovement : MenuMovement
    {
        /*
         * ===================================================
         * Event to switch the card's position between on-screen and off-screen
         * ===================================================
        */
        public void SwitchCard()
        {   
            if (transform.localPosition == Vector3.zero)
            {
                MoveOffScreen();
            }
            else
            {
                MoveToScreen();
            }
        }
    }
}