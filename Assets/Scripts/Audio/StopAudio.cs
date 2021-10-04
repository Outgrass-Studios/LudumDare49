using qASIC.AudioManagment;
using UnityEngine;

namespace Audio
{
    public class StopAudio : MonoBehaviour
    {
        private void Awake() =>
            AudioManager.StopAll();
    }
}