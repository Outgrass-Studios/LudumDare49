using qASIC.AudioManagment;
using UnityEngine;

namespace Audio
{
    public class AudioTrigger : MonoBehaviour
    {
        [SerializeField] AudioSourceController source;
        [SerializeField] AudioClip[] clips;

        public void TriggerSound(int clipIndex)
        {
            if (clipIndex < 0 || clipIndex >= clips.Length) return;
            source.Stop();
            source.Target.clip = clips[clipIndex];
            source.Play();
        }
    }
}