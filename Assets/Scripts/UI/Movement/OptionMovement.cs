using UnityEngine;

namespace UI.Movement
{
    public class OptionMovement : MonoBehaviour
    {
        /*
         * ===================================================
         * Declarations for option menu position coordinates
         * ===================================================
        */
        private int xDestinationPosition = -267;
        private int xDefaultPosition = -2000;

        /*
         * ===================================================
         * Functions to move the option menu to default and destination positions
         * ===================================================
        */
        public void MoveToDefault()
        {
            transform.localPosition = new Vector3(xDefaultPosition, transform.localPosition.y, 0);
        }

        public void MoveToDestination()
        {
            transform.localPosition = new Vector3(xDestinationPosition, transform.localPosition.y, 0);
        }
    }
}