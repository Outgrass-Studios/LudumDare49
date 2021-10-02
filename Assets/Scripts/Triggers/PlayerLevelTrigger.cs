using UnityEngine.SceneManagement;
using UnityEngine;

namespace Triggers
{
    public class PlayerLevelTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Cart")) return;
            int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (!Application.CanStreamedLevelBeLoaded(sceneIndex)) sceneIndex = 0;
            SceneManager.LoadScene(sceneIndex);
        }
    }
}