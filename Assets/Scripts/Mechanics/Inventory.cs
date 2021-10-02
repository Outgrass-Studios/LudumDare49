using UnityEngine;
using System;

namespace Items
{
    public class Inventory : MonoBehaviour
    {
        Item pickedUpItem = null;

        public Action<Item> OnItemPickUp;

        public void PickUpItem(Item item)
        {
            if (!HasItem())
            {
                pickedUpItem = item;
                item.gameObject.SetActive(false);
                OnItemPickUp?.Invoke(item);
            }
        }
        public void PlaceItem(Vector3 position)
        {
            if (HasItem())
            {
                pickedUpItem.transform.position = position;
                pickedUpItem.gameObject.SetActive(true);
                pickedUpItem = null;
                OnItemPickUp?.Invoke(null);
            }
        }
        public bool HasItem()
        {
            return pickedUpItem;
        }
    }
}