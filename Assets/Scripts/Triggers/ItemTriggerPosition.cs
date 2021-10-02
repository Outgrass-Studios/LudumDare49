using UnityEngine;
using Items;

namespace Triggers
{
    public class ItemTriggerPosition : MonoBehaviour
    {
        [SerializeField] Vector3 offset;

        private void Awake()
        {
            ItemTrigger trigger = GetComponent<ItemTrigger>();
            if (trigger == null) return;
            trigger.OnTrigger.AddListener(HandleTrigger);
        }

        void HandleTrigger(Item item)
        {
            item.transform.position = transform.position + offset;
        }

        private void OnDrawGizmosSelected()
        {
            Color color = Gizmos.color;
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position + offset, 0.1f);
            Gizmos.color = color;
        }
    }
}