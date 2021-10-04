using Items;
using UnityEngine.UI;
using UnityEngine;
using qASIC;

public class ItemUI : MonoBehaviour
{
    [SerializeField] Image image;
    bool state;

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

    private void Update()
    {
        if (FadeController.IsFading)
            image.gameObject.SetActive(false);
        image.gameObject.SetActive(state);
    }

    void HandleItemPickUp(Item item)
    {
        state = item != null;
        if (item == null) return;
        image.sprite = item.itemIndex < 0 || item.itemIndex >= sprites.Length ? null : sprites[item.itemIndex];
    }
}
