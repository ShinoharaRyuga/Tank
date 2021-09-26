using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlayDangerous : MonoBehaviour
{
    [SerializeField] MultiPlayManager m_gameManager = default;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerTank")
        {
            m_gameManager.m_endFlag = true;
            var go = collision.gameObject.name;
            if (go == "1Player")
            {
                m_gameManager.m_result = 2;
               
            }
            else if (go == "2Player")
            {
                m_gameManager.m_result = 1;
                
            }
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
