using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveScript : MonoBehaviour
{
    [SerializeField] Transform m_playerPos;
    [SerializeField] GameManager m_gameManager = default;

    private MovePattern m_movePattern = MovePattern.Idle;
    float m_distance = 0.0f;
    public bool m_hitRay = false;
    NavMeshAgent m_agent = default;

    Transform m_enemyPos = default;
    void Start()
    {

    }

    void Update()
    {

        if (m_playerPos != null)
        {
            m_enemyPos = this.gameObject.transform;
            m_distance = Vector3.Distance(m_playerPos.position, m_enemyPos.position);
            m_agent = GetComponent<NavMeshAgent>();
            //Debug.Log(m_distance);

        }
        if (m_gameManager.m_moveFlag)
        {
            switch (m_movePattern)
            {
                case MovePattern.Idle:
                    m_agent.isStopped = true;
                    break;
                case MovePattern.Chase:
                    m_agent.destination = m_playerPos.position;
                    break;
            }
        }

       
        if (m_hitRay)
        {
            Debug.Log(m_hitRay);
        }
       

        if (m_distance >= 20)
        {
            m_movePattern = MovePattern.Chase;
        }
        else
        {
            m_movePattern = MovePattern.Idle;
        }
    }
}

public enum MovePattern
{
    Idle,
    Chase,
}
