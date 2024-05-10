using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public Transform handTransform; 
    public GameObject itemInRange;
    private GameObject lastItem;
    private bool isHolding = false;
    private Vector3 Ray_start_position = new Vector3(Screen.width/2, Screen.height/2, 0);
    private bool fakeBox = false; //zatway 
    void Update()
    {
        ReleaseRay();
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (!isHolding && itemInRange != null && fakeBox == false) PickupItem();
            else if (!isHolding && itemInRange != null && fakeBox == true)
            {
                DestroyFakeBox(itemInRange);
            }
            else if (isHolding) LeaveItem();
        }
    }
    public void DestroyFakeBox(GameObject fakeBox)
    {
        //заглушка
        Debug.Log("FakeBox");

        Destroy(fakeBox);
    }
    private void ReleaseRay() 
    {
    Ray ray = Camera.main.ScreenPointToRay(Ray_start_position);
    RaycastHit hit; 
    Physics.Raycast(ray, out hit);
        if (hit.collider != null && hit.distance <= 2f && hit.collider.gameObject.CompareTag("Pickupable"))
        {
            itemInRange = hit.collider.gameObject;
            fakeBox = false;
        }
        else if (hit.collider != null && hit.distance <= 2f && hit.collider.gameObject.CompareTag("FakeBox")) //zatway 
        {
            itemInRange = hit.collider.gameObject;
            fakeBox = true;
        }
        else itemInRange = null;
            
    }

    private void PickupItem()
    {
        if (itemInRange != null) lastItem = itemInRange;
        itemInRange.GetComponent<ItemDisabler>().EnableItem();
        itemInRange.transform.SetParent(handTransform); 
        itemInRange.transform.localPosition = Vector3.zero; 
        itemInRange.transform.localRotation = Quaternion.identity; 
        itemInRange.GetComponent<Rigidbody>().isKinematic = true; 
        itemInRange.GetComponent<Collider>().isTrigger = true; 
        isHolding = true;
    }
    
    private void LeaveItem() 
    {
        lastItem.GetComponent<ItemDisabler>().DisableItem();
        lastItem.transform.SetParent(null);
        //lastItem.transform.position = 
        lastItem.GetComponent<Rigidbody>().isKinematic = false; 
        lastItem.GetComponent<Collider>().isTrigger = false; 
        isHolding = false;
    }
}
