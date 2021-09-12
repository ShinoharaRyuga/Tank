using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text m_clearText;
    [SerializeField] Text m_failText;
    [SerializeField] GameObject m_titleBackButton;
    public bool m_moveFlag = false;
    public bool m_failFlag = false;
    public int m_enemy = 0;
  
    // Start is called before the first frame update
    void Start()
    {
        m_clearText.gameObject.SetActive(false);
        m_failText.gameObject.SetActive(false);
        m_titleBackButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_enemy <= 0 && !m_failFlag)
        {
            m_clearText.gameObject.SetActive(true);
            m_titleBackButton.SetActive(true);
            m_moveFlag = false;
        }

        if (m_failFlag)
        {
            m_failText.gameObject.SetActive(true);
            m_titleBackButton.SetActive(true);
            m_moveFlag = false;
        }
    }
}
