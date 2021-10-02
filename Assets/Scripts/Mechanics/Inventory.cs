using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    Item pickedUpItem = null;
    public Image miniature;

    public void PickUpItem(Item item)
    {
        if (!HasItem())
        {
            pickedUpItem = item;
            item.gameObject.SetActive(false);
            miniature.color = new Color(1, 1, 1, 1);
            miniature.sprite = item.inventoryMiniature;
        }
    }
    public void PlaceItem(Vector3 position)
    {
        if (HasItem())
        {
            pickedUpItem.transform.position = position;
            pickedUpItem.gameObject.SetActive(true);
            pickedUpItem = null;
            miniature.color = new Color(1, 1, 1, 0);
            miniature.sprite = null;
        }
    }
    public bool HasItem()
    {
        return pickedUpItem;
    }
}
