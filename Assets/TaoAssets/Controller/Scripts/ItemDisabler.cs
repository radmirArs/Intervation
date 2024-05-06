using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisabler : MonoBehaviour
{
    public GameObject Item;
    public void EnableItem() {
        Item.SetActive(true);
    }
    public void DisableItem() {
        Item.SetActive(false);
    }
}
