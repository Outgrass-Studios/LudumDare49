using UnityEngine.SceneManagement;
using UnityEngine;
using System;

namespace Triggers
{
    public class PlayerLevelTrigger : MonoBehaviour
    {
        [SerializeField] Color color;
        [SerializeField] float duration;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Cart")) return;
            int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (!Application.CanStreamedLevelBeLoaded(sceneIndex)) sceneIndex = 0;

            FadeController.Fade(color, duration, new Action(() =>
            {
                SceneManager.LoadScene(sceneIndex);
            }));
        }
    }
}