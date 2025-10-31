using UnityEngine;
using UnityEngine.EventSystems;

namespace Sounds
{
    public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
    {
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

