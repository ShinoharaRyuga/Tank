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
    /// <summary>弾数</summary>
    [SerializeField] int m_bulletCount;
    /// <summary>移動スピード</summary>
    float m_speed = 8f;

    private GameObject m_player;

    private Transform m_playerPos;
    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.Find("Player");
        m_playerPos = m_player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(m_playerPos.position);
    }
}
