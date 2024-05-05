using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBoxScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy3VarY;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Debug.Log("32");
            Instantiate(Enemy3VarY, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
