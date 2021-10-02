using UnityEngine.SceneManagement;
using UnityEngine;

namespace ComponentLoading
{
    public class ComponentLoader : MonoBehaviour
    {
        public const string SystemSceneName = "Systems";

        static string previousSceneName;

        public static bool Initialized { get; private set; } = false;

        private void Start()
        {
            if (SceneManager.GetActiveScene().name == SystemSceneName)
            {
                LoadPreviousScene();
                Initialized = true;
            }
        }

        public static void LoadPreviousScene() =>
            SceneManager.LoadScene(previousSceneName);

        [RuntimeInitializeOnLoadMethod]
        static void Initialize()
        {
            string current = SceneManager.GetActiveScene().name;
            if (current == SystemSceneName) return;
            previousSceneName = current;
            SceneManager.LoadScene(SystemSceneName);
        }
    }
}