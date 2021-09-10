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
    /// <summary>弾数</summary>
    int m_bulletCount = 0;
    /// <summary>移動スピード</summary>
    float m_speed = 8f;
    /// <summary>弾丸が回復するまでの時間</summary>
    float m_time = 0f;

    GameObject m_player = default;
    Transform m_playerPos = default;
    Transform m_enemyPos = default;
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
            m_enemyPos = this.gameObject.transform;
            m_playerPos = m_player.GetComponent<Transform>();
            var distance = Vector3.Distance(m_playerPos.position, m_enemyPos.position);
            m_upperBody.transform.LookAt(m_playerPos);
            AddBullet();

            if (m_bulletCount > 0)
            {
                Debug.Log("発射");
                m_audio.PlayOneShot(m_sound);
                Instantiate(m_bullet, m_bulletSpwan);
                m_bulletCount--;
            }
        }
        else
        {
            Debug.Log("end");
        }
        
    }

    public void AddBullet()
    {
        m_time += Time.deltaTime;

        if (m_time > m_addTime)
        {
            m_bulletCount++;
            m_time = 0;
        }

    }
}
