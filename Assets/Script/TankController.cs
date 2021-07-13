using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
     Rigidbody m_rb = default;
    [SerializeField] Transform m_bulletSpwan;
    [SerializeField] GameObject m_bullet;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(m_bullet, m_bulletSpwan);
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_rb.velocity = transform.forward * 10;
            Debug.Log("W");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_rb.velocity = transform.forward * -10;
            Debug.Log("S");
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1, 0);
        }  
    }
}
