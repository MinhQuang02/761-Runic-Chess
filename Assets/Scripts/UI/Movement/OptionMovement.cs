using UnityEngine;

namespace UI.Movement
{
    public class OptionMovement : MonoBehaviour
    {
        private int xDestinationPosition = -267;
        private int xDefaultPosition = -2000;

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