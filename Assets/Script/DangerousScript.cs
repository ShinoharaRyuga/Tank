using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousScript : MonoBehaviour
{
    [SerializeField] GameManager m_gameManager = default;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerTank")
        {
            m_gameManager.m_failFlag = true;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
