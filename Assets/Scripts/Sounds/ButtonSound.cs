using UnityEngine;
using UnityEngine.EventSystems;

namespace Sounds
{
    public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
    {
        /*
         * ===================================================
         * Waiting for pointer events to play corresponding sound effects
         * ===================================================
        */
        public void OnPointerEnter(PointerEventData eventData)
        {
            GameSounds.PlayHoverSound();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            GameSounds.PlayClickSound();
        }
    }
}

