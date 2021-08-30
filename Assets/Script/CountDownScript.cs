using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownScript : MonoBehaviour
{
    [SerializeField] float m_count = 0;
    [SerializeField] GameManager m_gameManager;
    Text m_countDownText;

    // Start is called before the first frame update
    void Start()
    {
        m_countDownText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        m_count -= Time.deltaTime;

        m_countDownText.text = m_count.ToString("F0");


        if (m_count <= 0)
        {
            m_countDownText.text = "スタート！！";
            m_gameManager.m_moveFlag = true;
        }

        if (m_count <= -1)
        {
            m_countDownText.gameObject.SetActive(false);
        }
    }
}
