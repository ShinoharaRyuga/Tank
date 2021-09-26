using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayScript2 : MonoBehaviour
{
    [SerializeField] GameObject m_tankUpperBodys = default;
    Rigidbody m_rb = default;
    [SerializeField] Transform m_bulletSpwans = default;
    [SerializeField] int m_maxBulletCounts = default;
    [SerializeField] int m_bulletCounts = default;
    [SerializeField] GameObject m_bullet;
    [SerializeField] SetController m_setController = default;
    [SerializeField] AudioClip m_sound;

    public int m_playerNumber = 0;
    private bool m_ready = false;
    float m_speed = 8f;
    float m_time = 0f;

    
    [SerializeField] MultiPlayManager m_gameManagerScript;
    AudioSource m_audio;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_audio = this.gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("X2Xbutton") && !m_ready)
        {
            m_gameManagerScript.m_readyCount++;
            m_ready = true;
        }

        if (m_playerNumber == 2 && m_setController.m_player2 == 2  && m_gameManagerScript.m_moveFlag == true)
        {
            Debug.Log("Xbox");
            Xbox2BulletController();
            Xbox2Controller();
            AddBullet();
        }
    }

    public void Xbox2Controller()
    {
        float xh = Input.GetAxis("X2Horizontal");
        float xv = Input.GetAxis("X2Vertical");
        float xLRT = Input.GetAxis("X2LRT");
        bool rbFlag = false;

        Debug.Log(xh);

        if (xh != 0)
        {
            this.transform.Rotate(this.transform.up, xh * TankConfiguration.m_tankRotateValue);
        }

        if (Input.GetButton("X2RB"))
        {
            Debug.Log("hit");
            rbFlag = true;
            Vector3 velo = this.transform.forward * m_speed;
            m_rb.velocity = velo;
        }
        else if (Input.GetButtonUp("X2RB"))
        {
            Vector3 velo = Vector3.zero;
            m_rb.velocity = velo;
        }

        if (Input.GetButton("X2LB"))
        {
            m_tankUpperBodys.transform.Rotate(0, TankConfiguration.m_upperBodyRotateValue, 0);
        }

        if (xLRT > 0 && rbFlag == false)
        {
            Vector3 velo = -this.transform.forward * m_speed;
            m_rb.velocity = velo;
        }
        
        if (xLRT < 0)
        {
            m_tankUpperBodys.transform.Rotate(0, -TankConfiguration.m_upperBodyRotateValue, 0);
        }


    }

    public void Xbox2BulletController()
    {
        if (m_bulletCounts > 0)
        {
            if (Input.GetButtonDown("X2Xbutton"))
            {
                Debug.Log("xbox2");
                m_audio.PlayOneShot(m_sound);
                m_bulletCounts--;
                Instantiate(m_bullet, m_bulletSpwans);
            }
        }
    }

    /// <summary>時間で弾丸が回復する関数</summary>
    public void AddBullet()
    {
        if (m_bulletCounts < m_maxBulletCounts)
        {
            m_time += Time.deltaTime;

            if (m_time > 2f)
            {
                m_bulletCounts++;
                m_time = 0;
            }
        }
        else
        {
            m_time = 0f;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" && m_gameManagerScript.m_moveFlag)
        {
            m_gameManagerScript.m_result = 1;
            m_gameManagerScript.m_endFlag = true;
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Break")
        {
            m_speed = 4f;
            Debug.Log("Enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Break")
        {
            m_speed = 8f;
            Debug.Log("Exit");
        }
    }
}

