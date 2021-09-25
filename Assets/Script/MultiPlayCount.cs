using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiPlayCount : MonoBehaviour
{
    /// <summary>カウントダウンの時間</summary>
    [SerializeField] float m_count = 0;
    /// <summary>ゲーム進行のスクリプト</summary>
    [SerializeField] MultiPlayManager m_gameManager;
    /// <summary>カウントダウンを表示するテキスト</summary>
    Text m_countDownText;

    public bool m_countFlag = false;


    void Start()
    {
        m_countDownText = GetComponent<Text>();
        m_countDownText.text = "Xボタンを押してください";
    }

    void Update()
    {
        if (m_countFlag == true)
        {
            CountStart();
        }
    }

    public void CountStart()
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
