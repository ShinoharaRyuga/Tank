using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵戦車の基底クラス
/// </summary>
public class EnemyBase : MonoBehaviour
{
    Rigidbody m_rb = default;
    /// <summary> 弾丸の発射位置</summary>
    [SerializeField] Transform m_bulletSpwan;
    /// <summary>実際に飛ばす弾丸</summary>
    [SerializeField] GameObject m_bullet;
    /// <summary> 弾数が回復する時間 </summary>
    [SerializeField] float m_addTime = 0f;
    /// <summary>砲身がある戦車の上部</summary>
    [SerializeField] GameObject m_upperBody;
    /// <summary>発射音</summary>
    [SerializeField] AudioClip m_sound;
    /// <summary>Playerのレイヤーに反応</summary>
    [SerializeField] LayerMask m_playerMask;
    /// <summary>弾数</summary>
    int m_bulletCount = 0;
    /// <summary>移動スピード</summary>
    float m_speed = 8f;
    /// <summary>弾丸が回復するまでの時間</summary>
    float m_time = 0f;

    [SerializeField] int m_fireMode = 0;

    GameObject m_player = default;
    Transform m_playerPos = default;
    GameObject m_gameManager = default;
    GameManager m_gameManagerScript = default;
    AudioSource m_audio = default;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.Find("Player");
        m_audio = this.gameObject.AddComponent<AudioSource>();
        m_gameManager = GameObject.Find("GameManager");
        m_gameManagerScript = m_gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gameManagerScript.m_moveFlag && m_player != null)
        {
            m_playerPos = m_player.GetComponent<Transform>();
            m_upperBody.transform.LookAt(m_playerPos);
            AddBullet();
            Ray ray = new Ray(m_bulletSpwan.position, m_bulletSpwan.transform.forward);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 20.0f, Color.red, 1);

            if (m_fireMode == 1)
            {
                if (m_bulletCount > 0)
                {
                    m_audio.PlayOneShot(m_sound);
                    Instantiate(m_bullet, m_bulletSpwan);
                    m_bulletCount--;
                }
                
            }
            else if (m_fireMode == 2)
            {
                Debug.Log("hit");
                if (m_bulletCount > 0 && Physics.Raycast(ray, out hit, 20.0f, m_playerMask))
                {
                    var go = hit.collider.gameObject;
                    Debug.Log(go.tag);
                    if (go.tag == "PlayerTank")
                    {
                        m_audio.PlayOneShot(m_sound);
                        Instantiate(m_bullet, m_bulletSpwan);
                        m_bulletCount--;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("弾" + m_bulletCount);
        }
    }

    public void AddBullet()
    {
        if (m_bulletCount != 1)
        {
            m_time += Time.deltaTime;
        }
       
        if (m_time > m_addTime)
        {
            m_bulletCount++;
            m_time = 0;
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            m_gameManagerScript.m_enemy--;
            //Debug.Log(m_gameManagerScript.m_enemy);
        }
    }
}
