using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ControllerFakeBox : MonoBehaviour
{
    public PickUpObject PickUp;
    [SerializeField] GameObject End_Screen;

    [SerializeField] GameObject Screamer;
    
    private void Set_End_Screen()
    {
        Screamer.SetActive(false);
        End_Screen.SetActive(true);
        Destroy(gameObject);
    }

    private void Death()
    {
        Screamer.SetActive(true);
        Invoke("Set_End_Screen", 2);
        
    }

    public void DestroyFakeBox()
    {
        if (PickUp.Is_alive == true)
        {
            PickUp.Is_alive = false;
            Death();
        }
    }
}
