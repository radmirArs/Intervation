using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerFakeBox : MonoBehaviour
{
    public GameObject Enemy3VarY;
    public GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void DestroyFakeBox(GameObject fakeBox)
    {
        Destroy(fakeBox);
        ControllerFakeBox controllerFakeBox = new ControllerFakeBox();
        controllerFakeBox.SpawnEnemy(fakeBox);
    }

    public void SpawnEnemy(GameObject fakeBox)
    {
        GameObject enemy = Instantiate(Enemy3VarY, Player.transform.position+Vector3.up, Player.transform.rotation);
    }
}
