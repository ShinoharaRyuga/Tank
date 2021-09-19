using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetController : MonoBehaviour
{
    public static int totalController = 0;
    public MultiplayScript[] m_multiplayScripts = default;
    [SerializeField] MultiplayScript2 m_multiplayScript2 = default;
    public int[] m_playerNumbers = default;
    string[] m_controllerName;


    public int m_player1 = 0;
    public int m_player2 = 0;
    public int m_player3 = 0;
    public int m_player4 = 0;

    void Start()
    {
        m_controllerName = Input.GetJoystickNames();
        //Debug.Log("1" + m_controllerName[0]);
        //Debug.Log("2" + m_controllerName[1]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire6") && m_player1 == 0)
        {
        
            m_multiplayScripts[0].m_playerNumber = 1;
            m_player1 = 1;
            Debug.Log("PS4");
        }

        if (Input.GetButton("X1Xbutton") && m_player2 == 0)
        {
            
            m_multiplayScript2.m_playerNumber = 2;
            m_player2 = 2;
            Debug.Log("Xbox");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(m_player1);
            Debug.Log(m_player2);
        }
    }
}
