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
    private bool normalBox = false; //Blacklow

    public bool Is_alive; //Blacklow

    void Start()
    {
        Is_alive = true; // Blacklow
    }

    void Update()
    {
        ReleaseRay();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isHolding && itemInRange != null && fakeBox == false) PickupItem();
            else if (!isHolding && itemInRange != null && fakeBox == true)
            {
                ControllerFakeBox fakebox_controller = itemInRange.GetComponent<ControllerFakeBox>(); //Blacklow
                fakebox_controller.DestroyFakeBox();
            }
            else if (!isHolding && itemInRange != null && normalBox == true)
            {
                NormalBox box = itemInRange.GetComponent<NormalBox>(); //Blacklow
                box.Open_Box();
            }
            else if (isHolding) LeaveItem();
        }
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
            normalBox = false;
        }
        else if (hit.collider != null && hit.distance <= 2f && hit.collider.gameObject.CompareTag("FakeBox")) //zatway 
        {
            itemInRange = hit.collider.gameObject;
            fakeBox = true;
        }
        else if (hit.collider != null && hit.distance <= 2f && hit.collider.gameObject.CompareTag("NormalBox")) //Blacklow 
        {
            itemInRange = hit.collider.gameObject;
            normalBox = true;
        }
        else itemInRange = null;
            
    }

    private void PickupItem()
    {
        if (itemInRange != null) lastItem = itemInRange;
        foreach (Transform i in itemInRange.GetComponentsInChildren<Transform>())
        {
            i.gameObject.layer = LayerMask.NameToLayer("Weapons");
        }
        itemInRange.GetComponent<ItemDisabler>().EnableItem();
        itemInRange.transform.SetParent(handTransform); 
        itemInRange.transform.localPosition = Vector3.zero; 
        itemInRange.transform.localRotation = Quaternion.identity; 
        itemInRange.GetComponent<Rigidbody>().isKinematic = true; 
        isHolding = true;
    }
    
    private void LeaveItem() 
    {
        lastItem.GetComponent<ItemDisabler>().DisableItem();
        foreach (Transform i in lastItem.GetComponentsInChildren<Transform>())
        {
            i.gameObject.layer = LayerMask.NameToLayer("Default");
        }
        lastItem.GetComponent<Rigidbody>().isKinematic = false; 
        lastItem.transform.SetParent(null);
        isHolding = false;
    }
}
