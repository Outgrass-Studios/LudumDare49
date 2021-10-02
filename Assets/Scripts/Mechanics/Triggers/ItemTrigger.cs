using qASIC;
using UnityEngine;
using System;

namespace Items.Triggers
{
    public class ItemTrigger : MonoBehaviour
    {
        [SerializeField] int[] targedItems = new int[] { 0 };

        public Action<Item> OnTrigger;

        private void OnTriggerEnter(Collider other)
        {
            Item item = other.GetComponent<Item>();
            if (item == null || Array.IndexOf(targedItems, item.itemIndex) == -1) return;

            qDebug.Log($"[{name}] has been triggered by item {item.itemIndex}", "trigger");
            OnTrigger?.Invoke(item);
        }
    }
}