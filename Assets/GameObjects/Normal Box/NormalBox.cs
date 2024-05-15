using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBox : MonoBehaviour
{
    [SerializeField] GameObject Key;

    public void Open_Box()
    {
        Instantiate(Key, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
