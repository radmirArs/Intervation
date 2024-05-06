using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public GameObject Cube;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Cube.GetComponent<Renderer>().material.color = new Color(1f, 0, 0);
        }
        if (Input.GetMouseButtonDown(1)) {
            Cube.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
        }
    }
}
