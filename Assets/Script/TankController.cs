using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    Rigidbody m_rb = default;
    [SerializeField] Transform m_bulletSpwan;
    [SerializeField] GameObject m_bullet;
    float m_speed = 8f;
    private AudioSource m_audio;
    [SerializeField] AudioClip m_sound;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_audio = this.gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Controller();
       
    }

    private void Controller()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Debug.Log("hは" + h);
        Debug.Log("vは" + v);

        
        if(v == 0)
        {
            m_rb.velocity = Vector3.zero;
        }
        else
        {
            if (v > 0.2)
            {
                m_rb.velocity = transform.forward * m_speed;
            }
            else if (v == -1)
            {
                m_rb.velocity = transform.forward * -m_speed;
            }
        }
        if (h > 0)
        {
            transform.Rotate(0, 1f, 0);
        }
        else if (h < 0)
        {
            transform.Rotate(0, -1f, 0);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(m_bullet, m_bulletSpwan);
            m_audio.PlayOneShot(m_sound);
            Debug.Log("発射！！");
        }
    }
}
