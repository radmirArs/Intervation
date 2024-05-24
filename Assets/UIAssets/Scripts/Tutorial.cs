using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    void OnEnable()
    {
        Invoke("Disable",8f);
    }

    private void Disable()
    {
        Destroy(gameObject);
    }
}
