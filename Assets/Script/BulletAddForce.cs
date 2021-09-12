using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bulletに力を加えて飛ばすスクリプト
/// </summary>
public class BulletAddForce : MonoBehaviour
{
    /// <summary>弾の生存期間（秒)</summary>
    [SerializeField] float m_lifeTime = 5f;
    /// <summary>弾が飛ぶ速さ</summary>
    [SerializeField] float m_speed = 8f;

    Rigidbody rb = default;
    int m_reflection = 0;
    
    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody>();
        //z方向に飛ばす
        rb.AddForce(transform.forward * m_speed, ForceMode.Impulse);
        // m_lifeTime分時間が経過したら弾丸を削除する
        Destroy(this.gameObject, m_lifeTime);
        gameObject.transform.parent = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_reflection++;
        if (collision.gameObject.tag == "Tank" || collision.gameObject.tag == "PlayerTank" || collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }

        if (m_reflection > 2)
        {
            Destroy(this.gameObject);
        }

    }
}
