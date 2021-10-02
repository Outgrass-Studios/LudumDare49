using qASIC;
using UnityEngine;
using UnityEngine.Events;
using System;
using Items;

namespace Triggers
{
    public class ItemTrigger : MonoBehaviour
    {
        [SerializeField] bool oneUse = true;
        [SerializeField] int[] targedItems = new int[] { 0 };

        bool used = false;

        public UnityEvent<Item> OnTrigger;

        private void OnTriggerEnter(Collider other)
        {
            if (oneUse && used) return;
            Item item = other.GetComponent<Item>();
            if (item == null || Array.IndexOf(targedItems, item.itemIndex) == -1) return;

            qDebug.Log($"[{name}] has been triggered by item {item.itemIndex}", "trigger");
            OnTrigger.Invoke(item);
            if (oneUse) used = true;
        }
    }
}