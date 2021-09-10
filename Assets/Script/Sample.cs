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
        float rh = Input.GetAxis("R_Horizontal");
        float rv = Input.GetAxis("R_Vertical");

        Debug.Log("rv =" + rv);
        Debug.Log("rh =" + rh);

        if (rh != 1)
        {
            
            this.gameObject.transform.Rotate(-transform.up, 0.5f);
        }

        if (rv != 1)
        {
            this.gameObject.transform.Rotate(transform.up, 0.5f);
        }
    }
}
