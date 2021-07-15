using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    Rigidbody m_rb = default;
    [SerializeField] Transform m_bulletSpwan;
    [SerializeField] GameObject m_bullet;
    float m_speed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Controller();
    }

    private void Controller()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_rb.velocity = transform.forward * m_speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_rb.velocity = transform.forward * -m_speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0.5f, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -0.5f, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(m_bullet, m_bulletSpwan);
        }
    }
}
