using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    Rigidbody m_rb = default;
    /// <summary> 弾丸の発射位置</summary>
    [SerializeField] Transform m_bulletSpwan;
    /// <summary>実際に飛ばす弾丸</summary>
    [SerializeField] GameObject m_bullet;
    /// <summary>弾数</summary>
    [SerializeField] int m_bulletCount;
    /// <summary>弾丸が飛ぶスピード</summary>
    float m_speed = 8f;

    private AudioSource m_audio;
    /// <summary>発射音</summary>
    [SerializeField] AudioClip m_sound;
    /// <summary>時間をはかり代入する変数</summary>
    float m_time = 0f;
  
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
        BulletController();
    }

    private void Controller()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
       // Debug.Log("hは" + h);
        //Debug.Log("vは" + v);

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
    }

    public void BulletController()
    {
        if (m_bulletCount > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(m_bullet, m_bulletSpwan);
                m_audio.PlayOneShot(m_sound);
                m_bulletCount--;
                // Debug.Log("発射！！");
                Debug.Log(m_bulletCount);
            }
        }

        if (m_bulletCount < 8)
        {
            m_time += Time.deltaTime;
            
            if (m_time > 2f)
            {
                m_bulletCount++;
                Debug.Log(m_bulletCount);
                m_time = 0;
            }
        }
        else
        {
            m_time = 0f;
            Debug.Log(m_time);
        }

    }
}
