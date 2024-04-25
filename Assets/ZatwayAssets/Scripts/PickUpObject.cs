using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public Transform handTransform; 
    private GameObject itemInRange;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && itemInRange != null) 
        {
            PickupItem(); // Поднимаем предмет
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickupable")) 
        {
            itemInRange = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickupable")) 
        {
            itemInRange = null; 
        }
    }

    private void PickupItem()
    {
        itemInRange.transform.SetParent(handTransform); 
        itemInRange.transform.localPosition = Vector3.zero; 
        itemInRange.transform.localRotation = Quaternion.identity; 
        itemInRange.GetComponent<Rigidbody>().isKinematic = true; 
    }
}
