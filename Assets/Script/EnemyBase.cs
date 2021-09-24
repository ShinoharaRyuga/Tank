using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵戦車の基底クラス
/// </summary>
public class EnemyBase : MonoBehaviour
{
    [SerializeField] int m_fireMode = 0;
    /// <summary> 弾数が回復する時間 </summary>
    [SerializeField] float m_addTime = 0f;
    /// <summary>発射音</summary>
    [SerializeField] AudioClip m_sound;
    /// <summary>実際に飛ばす弾丸</summary>
    [SerializeField] GameObject m_bullet;
    [SerializeField] bool m_lookFlag = true;
    /// <summary>弾数</summary>
    int m_bulletCount = 0;
    /// <summary>弾丸が回復するまでの時間</summary>
    float m_time = 0f;

    
    Transform m_playerPos = default;
    [SerializeField] GameObject m_player = default;
    [SerializeField] GameManager m_gameManagerScript = default;
    AudioSource m_audio = default;
    /// <summary> 弾丸の発射位置</summary>
    Transform m_bulletSpwan;
    /// <summary>砲身がある戦車の上部</summary>
    GameObject m_upperBody;

    // Start is called before the first frame update
    void Start()
    {
        m_playerPos = m_player.transform;
        m_audio = this.gameObject.AddComponent<AudioSource>();
        m_upperBody = transform.GetChild(0).gameObject;
        m_bulletSpwan = m_upperBody.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gameManagerScript.m_moveFlag && m_player != null)
        {
            m_playerPos = m_player.GetComponent<Transform>();

            if (m_lookFlag)
            {
                m_upperBody.transform.LookAt(m_playerPos);
            }

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
                Ray ray = new Ray(m_bulletSpwan.position, m_bulletSpwan.forward);
                RaycastHit hit;
                if (m_bulletCount > 0 && Physics.Raycast(ray, out hit, 30.0f))
                {
                    var go = hit.collider.gameObject;
                    Debug.Log(go.name);
                    if (go.tag == "PlayerTank")
                    {
                        m_audio.PlayOneShot(m_sound);
                        Instantiate(m_bullet, m_bulletSpwan);
                        m_bulletCount--;
                    }
                }
            }
            else if (m_fireMode == 3)
            {
                if (m_upperBody.transform.GetChild(1) != null && m_bulletCount > 0)
                {
                    Transform bulletSpwan = m_upperBody.transform.GetChild(1);
                    Instantiate(m_bullet, m_bulletSpwan);
                    Instantiate(m_bullet, bulletSpwan);
                    m_audio.PlayOneShot(m_sound);
                    m_bulletCount--;

                }
            }
            

            AddBullet();
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
        }
    }
}
