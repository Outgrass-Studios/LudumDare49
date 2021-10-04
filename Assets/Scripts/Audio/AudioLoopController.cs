using qASIC.AudioManagment;
using UnityEngine;
using System.Collections;

namespace Audio
{
    [RequireComponent(typeof(AudioSourceController))]
    public class AudioLoopController : MonoBehaviour
    {
        [SerializeField] AudioClip[] clips;

        AudioSourceController controller;
        IEnumerator currentEnumerator;

        private void Awake()
        {
            controller = GetComponent<AudioSourceController>();
        }

        public void Play()
        {
            Stop();
            StartCoroutine(currentEnumerator = PlaySound());
        }

        public void Stop()
        {
            if (currentEnumerator == null) return;
            StopCoroutine(currentEnumerator);
        }

        IEnumerator PlaySound()
        {
            if (controller?.Target == null || clips.Length == 0) yield break;

            while(true)
            {
                int clip = Random.Range(0, clips.Length);
                controller.Target.clip = clips[clip];
                controller.Play();
                yield return new WaitForSeconds(clips[clip].length);
            }
        }
    }
}