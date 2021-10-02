using UnityEngine;

namespace Triggers
{
    public class ItemTriggerTask : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<ItemTrigger>()?.OnTrigger.AddListener(_ => HandleTrigger());
        }

        void HandleTrigger()
        {
            if (CartController.Singleton == null) return;
            CartController.Singleton.remainingTasks--;
        }
    }
}