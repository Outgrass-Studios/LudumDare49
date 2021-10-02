using Items;
using UnityEngine.UI;
using UnityEngine;
using qASIC;

public class ItemUI : MonoBehaviour
{
    [SerializeField] Image image;

    [Tooltip("An array of sprites for every item index")] [SerializeField] Sprite[] sprites;

    private void Awake()
    {
        Inventory inv = Player.PlayerReference.Singleton?.inventory;
        if(inv == null)
        {
            qDebug.LogError("Inventory has not been assigned!");
            return;
        }

        inv.OnItemPickUp += HandleItemPickUp;
    }

    void HandleItemPickUp(Item item)
    {
        image.gameObject.SetActive(item != null);
        if (item == null) return;
        image.sprite = item.itemIndex < 0 || item.itemIndex >= sprites.Length ? null : sprites[item.itemIndex];
    }
}
