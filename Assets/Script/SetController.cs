using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetController : MonoBehaviour
{
    public static int totalController = 0;
    [SerializeField] MultiplayScript m_multiplayScript = default;
    [SerializeField] MultiplayScript2 m_multiplayScript2 = default;
    //[SerializeField] MultiplayScript3 m_multiplayScript3 = default;
    //[SerializeField] MultiplayScript4 m_multiplayScript4 = default;
    public int[] m_playerNumbers = default;
    string[] m_controllerName;

    public int m_player1 = 0;
    public int m_player2 = 0;
    public int m_player3 = 0;
    public int m_player4 = 0;

    void Start()
    {
        ControllerSet();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("X1Xbutton") && m_player1 == 0)
        {
            m_multiplayScript.m_playerNumber = 1;
            m_player1 = 1;
            Debug.Log("1P");
        }

        if (Input.GetButton("X2Xbutton") && m_player2 == 0)
        {
            
            m_multiplayScript2.m_playerNumber = 2;
            m_player2 = 2;
            Debug.Log("2P");
        }

        //if (totalController >= 3)
        //{
        //    if (Input.GetButton("X2Xbutton") && m_player3 == 0)
        //    {

        //        m_multiplayScript3.m_playerNumber = 3;
        //        m_player3 = 3;
        //        Debug.Log("3P");
        //    }
        //}

        //if (totalController >= 4)
        //{
        //    if (Input.GetButton("X3Xbutton") && m_player4 == 0)
        //    {

        //        m_multiplayScript4.m_playerNumber = 4;
        //        m_player4 = 4;
        //        Debug.Log("4P");
        //    }
        //}
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(m_player1);
            Debug.Log(m_player2);
        }
    }

    public  void ControllerSet()
    {
        m_controllerName = Input.GetJoystickNames();
        Debug.Log(m_controllerName.Length);
        foreach (var name in m_controllerName)
        {
            Debug.Log(name);
            if (name != "")
            {
                totalController++;
            }
        }
        Debug.Log("コントローラー合計 " + totalController);
    }
}
