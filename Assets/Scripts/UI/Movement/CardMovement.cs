using UnityEngine;

namespace UI.Movement
{
    public class CardMovement : MenuMovement
    {
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