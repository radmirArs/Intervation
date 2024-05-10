using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ControllerFakeBox : MonoBehaviour
{
    [SerializeField] public GameObject End_Scene_;

    [SerializeField] public GameObject Screamer;

    public static void Set_End_Screen()
    {
        Screamer.SetActive(false);
        End_Scene_.SetActive(true);
    }

    void Death()
    {
        Screamer.SetActive(true);
        Invoke("Set_End_Screen", 2);
    }

    public static void DestroyFakeBox(GameObject fakeBox)
    {
        Death();
        Destroy(fakeBox);
    }

    public void SpawnEnemy(Vector3 position)
    {
    }
}
