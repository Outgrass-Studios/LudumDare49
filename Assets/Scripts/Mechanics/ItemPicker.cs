using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class ItemPicker : MonoBehaviour
{
    Inventory inventory;
    RaycastHit hit;

    void Start()
    {
        inventory = GetComponent<Inventory>();
        
    }
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        
    }
}
