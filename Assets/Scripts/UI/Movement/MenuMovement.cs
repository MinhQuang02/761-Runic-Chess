using UnityEngine;

namespace UI.Movement
{
    public class MenuMovement : MonoBehaviour
    {
        /*
         * ===================================================
         * Declarations for menu position coordinates when off-screen
         * ===================================================
        */
        [SerializeField] private int xPosition;
        [SerializeField] private int yPosition;

        /*
         * ===================================================
         * Functions to move the menu on-screen and off-screen
         * ===================================================
        */
        public void MoveToScreen()
        {
            transform.localPosition = Vector3.zero;
        }

        public void MoveOffScreen()
        {
            transform.localPosition = new Vector3(xPosition, yPosition, 0);
        }
    }
}