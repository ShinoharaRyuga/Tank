using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankConfiguration : MonoBehaviour
{
    public static float m_tankRotateValue = 0.5f;
    public static float m_upperBodyRotateValue = 0.5f;
    [SerializeField] Text m_tankRotateText = default;
    [SerializeField] Text m_upperRotateText = default;
    [SerializeField] Text m_configurationText = default;

    private static int m_tankRotateNumber = 1;
    private static int m_upperRotateNumber = 5;

    private bool m_changeFlag = true;
    // Start is called before the first frame update
    void Start()
    {
        m_configurationText.text = "本体変更中";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0) && m_changeFlag)
        {
            m_configurationText.text = "上部変更中";
            m_changeFlag = false;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad0) && !m_changeFlag)
        {
            m_configurationText.text = "本体変更中";
            m_changeFlag = true;
        }

        if (m_changeFlag)
        {
            TankRotateChange();
        }
        else if(!m_changeFlag)
        {
            UpperBodyRotateChange();
        }

        m_tankRotateText.text = "本体感度 現在: " + m_tankRotateNumber.ToString();
        m_upperRotateText.text = "上部感度 現在: " + m_upperRotateNumber.ToString();
    }

    private void TankRotateChange()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            m_tankRotateNumber = 1;
            m_tankRotateValue = 0.1f;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            m_tankRotateNumber = 2;
            m_tankRotateValue = 0.2f;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            m_tankRotateNumber = 3;
            m_tankRotateValue = 0.3f;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            m_tankRotateNumber = 4;
            m_tankRotateValue = 0.4f;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            m_tankRotateNumber = 5;
            m_tankRotateValue = 0.5f;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            m_tankRotateNumber = 6;
            m_tankRotateValue = 0.6f;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            m_tankRotateNumber = 7;
            m_tankRotateValue = 0.7f;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            m_tankRotateNumber = 8;
            m_tankRotateValue = 0.8f;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            m_tankRotateNumber = 9;
            m_tankRotateValue = 0.9f;
        }
    }

    private void UpperBodyRotateChange()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            m_upperRotateNumber = 1;
            m_upperBodyRotateValue = 0.1f;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            m_upperRotateNumber = 2;
            m_upperBodyRotateValue = 0.2f;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            m_upperRotateNumber = 3;
            m_upperBodyRotateValue = 0.3f;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            m_upperRotateNumber = 4;
            m_upperBodyRotateValue = 0.4f;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            m_upperRotateNumber = 5;
            m_upperBodyRotateValue = 0.5f;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            m_upperRotateNumber = 6;
            m_upperBodyRotateValue = 0.6f;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            m_upperRotateNumber = 7;
            m_upperBodyRotateValue = 0.7f;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            m_upperRotateNumber = 8;
            m_upperBodyRotateValue = 0.8f;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            m_upperRotateNumber = 9;
            m_upperBodyRotateValue = 0.9f;
        }
    }
}
