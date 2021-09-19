using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayScript : MonoBehaviour
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
        if (m_playerNumber == 1 && m_setController.m_player1 == 1)
        {
            //Debug.Log("PS4");
            PS4Controller();
            BulletController();
           
        }
    }

    private void PS4Controller()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0)
        {
            this.transform.Rotate(this.transform.up, h * 1.5f);
        }

        if (Input.GetButton("Fire1"))
        {
            //Debug.Log("前進");
            Vector3 velo = this.transform.forward * m_speed;
            m_rb.velocity = velo;
        }
        else if (Input.GetButton("Fire5"))
        {
            //Debug.Log("後進");
            Vector3 velo = -this.transform.forward * m_speed;
            m_rb.velocity = velo;
        }

        if (Input.GetButton("Fire7"))
        {
            Debug.Log("右回転");
            m_tankUpperBodys.transform.Rotate(0, 1, 0);
        }
        else if (Input.GetButton("Fire8"))
        {
            Debug.Log("左回転");
            m_tankUpperBodys.transform.Rotate(0, -1, 0);
        }
    }

    public void Xbox1Controller()
    {
        if (m_setController.m_playerNumbers[1] == 2)
        {
            float xh = Input.GetAxis("X1Horizontal");
            float xv = Input.GetAxis("X1Vertical");
            float xLRT = Input.GetAxis("X1LRT");

            if (xh != 0)
            {
                this.transform.Rotate(this.transform.up, xh * 1.5f);
            }

            if (Input.GetButton("X1RB"))
            {
                Vector3 velo = this.transform.forward * m_speed;
                m_rb.velocity = velo;
            }

            if (Input.GetButton("X1LB"))
            {
                m_tankUpperBodys.transform.Rotate(0, 1, 0);
            }

            if (xLRT > 0)
            {
                Vector3 velo = -this.transform.forward * m_speed;
                m_rb.velocity = velo;
            }

            if (xLRT < 0)
            {
                m_tankUpperBodys.transform.Rotate(0, -1, 0);
            }
        }

    }

    public void BulletController()
    {
        if (m_bulletCounts > 0)
        {
            if (Input.GetButtonDown("Fire6"))
            {
                Debug.Log("PS4");
                Debug.Log("発射");
                m_audio.PlayOneShot(m_sound);
                m_bulletCounts--;
                Instantiate(m_bullet, m_bulletSpwans);
            }
        }
    }

    public void Xbox1BulletController()
    {
        if (m_bulletCounts > 0)
        {
            if (Input.GetButtonDown("X1Xbutton"))
            {
                Debug.Log("Xbox");
                Debug.Log("発射");
                m_audio.PlayOneShot(m_sound);
                m_bulletCounts--;
                Instantiate(m_bullet, m_bulletSpwans);
            }
        }
    }
}
