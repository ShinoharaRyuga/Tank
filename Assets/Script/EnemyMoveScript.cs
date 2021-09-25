using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveScript : MonoBehaviour
{
    [SerializeField] Transform m_playerPos;
    [SerializeField] GameManager m_gameManager = default;
    [SerializeField] float m_mindistance = 0.0f;

    private MovePattern m_movePattern = MovePattern.Idle;
    float m_distance = 0.0f;
    NavMeshAgent m_agent = default;

    Transform m_enemyPos = default;
    void Start()
    {

    }

    void Update()
    {

        if (m_playerPos != null && m_gameManager.m_moveFlag)
        {
            m_enemyPos = this.gameObject.transform;
            m_distance = Vector3.Distance(m_playerPos.position, m_enemyPos.position);
            m_agent = GetComponent<NavMeshAgent>();


            switch (m_movePattern)
            {
                case MovePattern.Idle:
                    m_agent.isStopped = true;
                    break;
                case MovePattern.Chase:
                    m_agent.isStopped = false;
                    m_agent.destination = m_playerPos.position;
                    break;
            }

            if (m_distance >= m_mindistance)
            {
                m_movePattern = MovePattern.Chase;
            }
            else
            {
                m_movePattern = MovePattern.Idle;
            }

        } 
    }
}

public enum MovePattern
{
    Idle,
    Chase,
}
