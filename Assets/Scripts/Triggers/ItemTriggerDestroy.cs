using UnityEngine;
using Items;

namespace Triggers
{
    public class ItemTriggerDestroy : MonoBehaviour
    {
        [SerializeField] bool state = false;

        private void Awake()
        {
            GetComponent<ItemTrigger>()?.OnTrigger.AddListener(HandleTrigger);
        }

        void HandleTrigger(Item item)
        {
            item.gameObject.SetActive(state);
        }
    }
}