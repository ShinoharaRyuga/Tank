using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire8"))
        {
            Debug.Log("PS4");
        }

        if (Input.GetButtonDown("XFire8"))
        {
            Debug.Log("Xbox");
        }
    }
}
