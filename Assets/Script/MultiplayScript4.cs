using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayScript4 : MonoBehaviour
{
    [SerializeField] GameObject m_tankUpperBodys = default;
    Rigidbody m_rb = default;
    [SerializeField] Transform m_bulletSpwans = default;
    [SerializeField] int m_maxBulletCounts = default;
    [SerializeField] int m_bulletCounts = default;
    [SerializeField] GameObject m_bullet;
    [SerializeField] SetController m_setController = default;
    [SerializeField] AudioClip m_sound;
    [SerializeField] Text m_bulletTexts = default;

    public int m_playerNumber = 0;
    float m_speed = 8f;
    float m_time = 0f;

    GameObject m_gameManager;
    GameManager m_gameManagerScript;
    AudioSource m_audio;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_audio = this.gameObject.AddComponent<AudioSource>();
        m_gameManager = GameObject.Find("GameManager");
        m_gameManagerScript = m_gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (m_playerNumber == 4 && m_setController.m_player4 == 4)
        {
            Debug.Log("Xbox");
            Xbox3BulletController();
            Xbox3Controller();
        }
    }

    public void Xbox3Controller()
    {
        float xh = Input.GetAxis("X3Horizontal");
        float xv = Input.GetAxis("X3Vertical");
        float xLRT = Input.GetAxis("X3LRT");
        bool rbFlag = false;

        Debug.Log(xh);

        if (xh != 0)
        {
            this.transform.Rotate(this.transform.up, xh * 1.5f);
        }

        if (Input.GetButton("X3RB"))
        {
            Debug.Log("hit");
            rbFlag = true;
            Vector3 velo = this.transform.forward * m_speed;
            m_rb.velocity = velo;
        }
        else if (Input.GetButtonUp("X3RB"))
        {
            Vector3 velo = Vector3.zero;
            m_rb.velocity = velo;
        }

        if (Input.GetButton("X3LB"))
        {
            m_tankUpperBodys.transform.Rotate(0, 1, 0);
        }

        if (xLRT > 0 && rbFlag == false)
        {
            Vector3 velo = -this.transform.forward * m_speed;
            m_rb.velocity = velo;
        }

        if (xLRT < 0)
        {
            m_tankUpperBodys.transform.Rotate(0, -1, 0);
        }


    }

    public void Xbox3BulletController()
    {
        if (m_bulletCounts > 0)
        {
            if (Input.GetButtonDown("X3Xbutton"))
            {
                Debug.Log("Xboxの方");
                m_audio.PlayOneShot(m_sound);
                m_bulletCounts--;
                Instantiate(m_bullet, m_bulletSpwans);
            }
        }
    }
}


