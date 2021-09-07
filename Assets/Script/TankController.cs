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
    /// <summary>アイテム取得後に飛ばす弾丸</summary>
    [SerializeField] GameObject m_bullet1;
    /// <summary>弾数</summary>
    [SerializeField] int m_bulletCount;
    /// <summary>Playerの移動スピード</summary>
    float m_speed = 8f;
    /// <summary>発射音</summary>
    [SerializeField] AudioClip m_sound;
    /// <summary>弾丸が回復するまでの時間</summary>
    float m_time = 0f;
    /// <summary>現在の弾丸</summary>
    Bulletkinds m_currentBullet;
    public Bulletkinds CurrentBullet { get => m_currentBullet; set => m_currentBullet = value; }

    GameObject m_gameManager;
    GameManager m_gameManagerScript;
    private AudioSource m_audio;

    

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
        if (m_gameManagerScript.m_moveFlag)
        {
            Controller();
            BulletController();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(m_speed);
        }
    }

    /// <summary>Playerの移動関数</summary>
    private void Controller()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
       
        if (h != 0)
        {
            this.transform.Rotate(this.transform.up, h * 1);
        }

        // 上下で前後移動する
        Vector3 velo = this.transform.forward * m_speed * v;
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

        if (m_bulletCount < 8)
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

    /// <summary>発射する弾丸を生成する関数</summary>
    /// <param name="bullet"></param>
    public void FireBullet(Bulletkinds bullet)
    {
        switch (bullet)
        {
            case Bulletkinds.usually:
                Instantiate(m_bullet, m_bulletSpwan);
                break;
            case Bulletkinds.speed:
                Instantiate(m_bullet1, m_bulletSpwan);
                break;
        }
    }

    /// <summary>発射する弾丸を決める関数</summary>
    /// <param name="bulletkinds"></param>
    public void SetBullet(Bulletkinds bulletkinds)
    {
        CurrentBullet = bulletkinds;
    }
}

/// <summary>弾丸の種類</summary>
public enum Bulletkinds
{
    /// <summary> 通常の弾丸</summary>
    usually,
    /// <summary> 通常よりも弾速が速い弾丸</summary>
    speed,

}
