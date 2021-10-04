using qASIC.AudioManagment;
using UnityEngine;

namespace Audio
{
    public class CollisionAudioTrigger : MonoBehaviour
    {
        [SerializeField] AudioClip[] clips;

        AudioSourceController source;
        Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            source = GetComponent<AudioSourceController>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (source?.Target == null || clips.Length == 0 || rb == null || rb.IsSleeping()) return;
            source.Target.clip = clips[Random.Range(0, clips.Length)];
            source?.Play();
        }
    }
}