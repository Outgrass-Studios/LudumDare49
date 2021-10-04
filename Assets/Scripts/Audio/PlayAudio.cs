using qASIC.AudioManagment;
using UnityEngine;

namespace Audio
{
    public class PlayAudio : MonoBehaviour
    {
        [SerializeField] string channel;
        [SerializeField] AudioData data;

        private void Awake()
        {
            AudioManager.Play(channel, data);
        }
    }
}