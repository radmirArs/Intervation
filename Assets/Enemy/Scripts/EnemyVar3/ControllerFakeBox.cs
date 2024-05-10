using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ControllerFakeBox : MonoBehaviour
{
    [SerializeField] GameObject End_Screen;

    [SerializeField] GameObject Screamer;

    void Set_End_Screen()
    {
        Screamer.SetActive(false);
        End_Screen.SetActive(true);
        Destroy(gameObject);
    }

    void Death()
    {
        Screamer.SetActive(true);
        Invoke("Set_End_Screen", 2);
    }

    public void DestroyFakeBox()
    {
        Death();
    }
}
