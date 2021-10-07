using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("本体感度　" + TankConfiguration.m_tankRotateValue);
        Debug.Log("上部感度　" + TankConfiguration.m_upperBodyRotateValue);
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("本体感度　" + TankConfiguration.m_tankRotateValue);
            Debug.Log("上部感度　" + TankConfiguration.m_upperBodyRotateValue);
        }
    }
}
