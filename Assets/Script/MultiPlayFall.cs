using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlayFall : MonoBehaviour
{
    [SerializeField] MultiPlayManager m_gameManager = default;
    [SerializeField] bool m_fallFlag = true;
    [SerializeField] float m_falltime = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (m_fallFlag)
        {
            Debug.Log("落ちる");
            if (m_gameManager.m_moveFlag && collision.gameObject.tag == "PlayerTank")
            {
                this.GetComponent<Renderer>().material.color = Color.black;
                Destroy(this.gameObject, m_falltime);
            }
        }
    }
}
