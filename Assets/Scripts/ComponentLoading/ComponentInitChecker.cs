using UnityEngine;

namespace ComponentLoading
{
    public class ComponentInitChecker : MonoBehaviour
    {
        public GameObject[] components;

        private void Awake()
        {
            if (!ComponentLoader.Initialized) return;
            ComponentLoader.LoadPreviousScene();
            DestroyComponents();
        }

        void DestroyComponents()
        {
            for (int i = 0; i < components.Length; i++)
                Destroy(components[i]);
        }
    }
}