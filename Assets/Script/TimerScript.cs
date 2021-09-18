using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
     Text m_timerText;

    [SerializeField] float m_time = 0.0f;

    public bool m_timerFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        m_timerText = GetComponent<Text>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (m_timerFlag)
        {
            m_time -= Time.deltaTime;
        }
        
        m_timerText.text = m_time.ToString("F2");

        if (m_time <= 0)
        {
            m_timerText.text = "ゲーム終了！！";
            m_timerFlag = false;
        }
    }
}
