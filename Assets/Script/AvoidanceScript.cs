using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidanceScript : MonoBehaviour
{
    GameObject m_parent = default;
    Rigidbody m_parentRb = default;
    // Start is called before the first frame update
    void Start()
    {
        m_parent = transform.parent.gameObject;
        m_parentRb = m_parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("範囲内");
            m_parentRb.AddForce(new Vector3 (10, 0, -5), ForceMode.Force);
        }
    }
}
