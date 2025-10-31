using UnityEngine;
using Sounds;

namespace Core.MainMenu
{
    public class Settings : MonoBehaviour
    {
        private static GameObject Instance;

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

        public void ChangeMainVolumeIndex(float index)
        {
            GameSounds.mainVolumeIndex = index;
            GameSounds.UpdateVolumes();
        }

        public void ChangeMusicVolumeIndex(float index)
        {
            GameSounds.musicVolumeIndex = index;
            GameSounds.UpdateVolumes();
        }

        public void ChangeClickSoundIndex(float index)
        {
            GameSounds.clickSoundIndex = index;
            GameSounds.UpdateVolumes();
        }

        public void ChangeHoverSoundIndex(float index)
        {
            GameSounds.hoverSoundIndex = index;
            GameSounds.UpdateVolumes();
        }
    }

}