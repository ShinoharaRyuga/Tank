using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Playerの戦車をコントロールする
/// スクリプト
/// </summary>
public class TankController : MonoBehaviour
{
    Rigidbody m_rb = default;
    /// <summary> 弾丸の発射位置</summary>
    [SerializeField] Transform m_bulletSpwan;
    /// <summary>実際に飛ばす弾丸</summary>
    [SerializeField] GameObject m_bullet;
    /// <summary>アイテム取得後に飛ばす弾丸</summary>
    [SerializeField] GameObject m_bullet1;
    /// <summary>現在の弾数</summary>
    [SerializeField] int m_bulletCount;
    /// <summary>最大の弾数</summary>
    [SerializeField] int m_maxBullet;
    /// <summary>Playerの移動スピード</summary>
    float m_speed = 8f;
    /// <summary>発射音</summary>
    [SerializeField] AudioClip m_sound;
    /// <summary>弾丸が回復するまでの時間</summary>
    float m_time = 0f;
    /// <summary>弾数を表示するテキスト</summary>
    [SerializeField] Text m_bulletText;
    
    /// <summary>現在の弾丸</summary>
    Bulletkinds m_currentBullet;
    public Bulletkinds CurrentBullet { get => m_currentBullet; set => m_currentBullet = value; }

    GameObject m_gameManager;
    GameManager m_gameManagerScript;
    private AudioSource m_audio;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_audio = this.gameObject.AddComponent<AudioSource>();
        m_gameManager = GameObject.Find("GameManager");
        m_gameManagerScript = m_gameManager.GetComponent<GameManager>();
        m_currentBullet = Bulletkinds.Usually;
    }

    void Update()
    {
        if (m_gameManagerScript.m_moveFlag)
        {
            Controller();
            BulletController();
            AddBullet();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(m_currentBullet);
        }

        m_bulletText.text = "Bullet:" + m_bulletCount.ToString();
    }

    /// <summary>Playerに弾丸が当たった時に呼ばれる　残機を減らす</summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            m_gameManagerScript.m_failFlag = true;
            GameManager.m_life--;
            Debug.Log(GameManager.m_life);
        }
    }

    /// <summary>Playerの移動関数</summary>
    private void Controller()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
       
        if (h != 0)
        {
            this.transform.Rotate(this.transform.up, h * 0.5f);
        }

        // 上下で前後移動する
        Vector3 velo = this.transform.forward * m_speed * -v;
        m_rb.velocity = velo;
    }

    /// <summary>弾丸の発射や弾丸の回復をする関数</summary>
    public void BulletController()
    {
        if (m_bulletCount > 0)
        {
            if (Input.GetButtonDown("Fire1"))
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
                Instantiate(m_bullet1, m_bulletSpwan);
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
}

/// <summary>弾丸の種類</summary>
public enum Bulletkinds
{
    /// <summary> 通常の弾丸</summary>
    Usually,
    /// <summary> 通常よりも弾速が速い弾丸</summary>
    Speed,
    /// <summary> 二連弾丸</summary>
    Double

}
