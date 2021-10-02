using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class ItemPicker : MonoBehaviour
{
    public Transform source;
    private Inventory inventory;
    RaycastHit hit;

    void Start()
    {
        inventory = GetComponent<Inventory>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            TryPickUp();
        if(Input.GetKeyDown(KeyCode.Mouse1))
            PlaceItem();
    }
    void TryPickUp()
    {
        if(Raycast())
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.CompareTag("Item"))
            {
                inventory.PickUpItem(hitObject.GetComponent<Item>());
            }
        }
    }
    void PlaceItem()
    {
        if(Raycast())
        {
            Vector3 placePos = hit.point;
            inventory.PlaceItem(placePos);
        }
    }

    bool Raycast()
    {
        return source && Physics.Raycast(new Ray(source.position, source.forward), out hit, 10);
    }
}
