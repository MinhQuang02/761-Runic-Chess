using UnityEngine;

namespace UI.Movement
{
    public class MenuMovement : MonoBehaviour
    {   
        public int xPosition;
        public int yPosition;

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