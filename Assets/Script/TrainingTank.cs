using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingTank : MonoBehaviour
{
    Rigidbody m_rb = default;
    /// <summary> 弾丸の発射位置</summary>
    Transform m_bulletSpwan;
    /// <summary>実際に飛ばす弾丸</summary>
    [SerializeField] GameObject m_bullet;
    /// <summary>現在の弾数</summary>
    [SerializeField] int m_bulletCount;
    /// <summary>最大の弾数</summary>
    [SerializeField] int m_maxBullet;
    /// <summary>砲身がある上部</summary>
    GameObject m_upperBody;
    /// <summary>Playerの移動スピード</summary>
    float m_speed = 8f;
    /// <summary>発射音</summary>
    [SerializeField] AudioClip m_sound;
    /// <summary>弾丸が回復するまでの時間</summary>
    float m_time = 0f;

    LoadSceneScript m_loadSceneScript = default;


    /// <summary>現在の弾丸</summary>
    Bulletkinds m_currentBullet;
    public Bulletkinds CurrentBullet { get => m_currentBullet; set => m_currentBullet = value; }

    private AudioSource m_audio;
    string[] m_controllerName = default;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_audio = this.gameObject.AddComponent<AudioSource>();
        m_currentBullet = Bulletkinds.Usually;
        m_controllerName = Input.GetJoystickNames();
        m_upperBody = transform.GetChild(0).gameObject;
        m_bulletSpwan = m_upperBody.transform.GetChild(0);
        m_loadSceneScript = GetComponent<LoadSceneScript>();
        //m_panel.SetActive(false);
        foreach (var name in m_controllerName)
        {
            Debug.Log(name);
        }
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        AddBullet();
        if (m_controllerName[0] == "" && m_controllerName[0] != "Controller")
        {
            PS4Controller();
            PS4BulletController();
        }
        else
        {
            XboxBulletController();
            XboxController();
        }

        if (Input.GetButton("X1Start"))
        {
            //StartCoroutine(TitleBack());
            m_loadSceneScript.TitleBack();
        }
    }

    /// <summary>Playerの移動関数</summary>
    private void PS4Controller()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0)
        {
            this.transform.Rotate(this.transform.up, h * 1f);
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
            m_upperBody.transform.Rotate(0, 1, 0);
        }
        else if (Input.GetButton("Fire8"))
        {
            m_upperBody.transform.Rotate(0, -1, 0);
        }
    }

    public void XboxController()
    {
        float xh = Input.GetAxis("X1Horizontal");
        float xv = Input.GetAxis("X1Vertical");
        float xLRT = Input.GetAxis("X1LRT");
        bool rbFlag = false;

        if (xh != 0)
        {
            this.transform.Rotate(this.transform.up, xh * TankConfiguration.m_tankRotateValue);
        }

        if (Input.GetButton("X1RB"))
        {
            rbFlag = true;
            Vector3 velo = this.transform.forward * m_speed;
            m_rb.velocity = velo;
        }

        if (Input.GetButton("X1LB"))
        {
            m_upperBody.transform.Rotate(0, TankConfiguration.m_upperBodyRotateValue, 0);
        }

        if (xLRT > 0 && rbFlag == false)
        {
            Vector3 velo = -this.transform.forward * m_speed;
            m_rb.velocity = velo;
        }

        if (xLRT < 0)
        {
            m_upperBody.transform.Rotate(0, -TankConfiguration.m_upperBodyRotateValue, 0);
        }


    }

    /// <summary>弾丸の発射や弾丸の回復をする関数</summary>
    public void PS4BulletController()
    {
        if (m_bulletCount > 0)
        {
            if (Input.GetButtonDown("Fire6"))
            {
                m_audio.PlayOneShot(m_sound);
                m_bulletCount--;
                FireBullet(m_currentBullet);
            }
        }
    }

    public void XboxBulletController()
    {
        if (m_bulletCount > 0)
        {
            if (Input.GetButtonDown("X1Xbutton"))
            {
                m_audio.PlayOneShot(m_sound);
                m_bulletCount--;
                FireBullet(m_currentBullet);
            }
        }
    }

    /// <summary>時間で弾丸が回復する関数</summary>
    public void AddBullet()
    {
        if (m_bulletCount < m_maxBullet)
        {
            m_time += Time.deltaTime;

            if (m_time > 2f)
            {
                m_bulletCount++;
                m_time = 0;
            }
        }
        else
        {
            m_time = 0f;

        }
    }

    /// <summary>Playerの移動速度が上がる関数 </summary>
    /// <param name="speed"></param>
    public void SpeedUp(float speed)
    {
        m_speed = speed;
    }

    /// <summary>発射する弾丸,発射を生成する関数</summary>
    /// <param name="bullet"></param>
    public void FireBullet(Bulletkinds bullet)
    {
        switch (bullet)
        {
            case Bulletkinds.Usually:
                Instantiate(m_bullet, m_bulletSpwan);
                break;
            case Bulletkinds.Speed:
                break;
            case Bulletkinds.Double:
                if (m_bulletCount >= 2)
                {
                    StartCoroutine(DoubleFire());
                    m_bulletCount--;
                }
                else
                {
                    Instantiate(m_bullet, m_bulletSpwan);
                }
                break;
        }
    }

    /// <summary>発射する弾丸を決める関数</summary>
    /// <param name="bulletkinds"></param>
    public void SetBullet(Bulletkinds bulletkinds)
    {
        CurrentBullet = bulletkinds;
    }

    /// <summary>二連砲をで使う関数　砲弾を２個作成</summary>
    IEnumerator DoubleFire()
    {
        Instantiate(m_bullet, m_bulletSpwan);
        yield return new WaitForSeconds(0.07f);
        Instantiate(m_bullet, m_bulletSpwan);
        m_audio.PlayOneShot(m_sound);
    }

    //IEnumerator TitleBack()
    //{
    //    m_panel.SetActive(true);
    //    yield return new WaitForSeconds(1f);
    //    m_fadeOutScript.StartFadeOut();
    //    yield return new WaitForSeconds(2f);
    //    m_loadSceneScript.TitleBack();
    //}
}

