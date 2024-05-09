using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ControllerFakeBox : MonoBehaviour
{

    public static void DestroyFakeBox(GameObject fakeBox)
    {
        //заглушка
        Debug.Log("FakeBox");
        Destroy(fakeBox);
    }

    public void SpawnEnemy(Vector3 position)
    {
    }
}
