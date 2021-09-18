using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// カウントダウンの処理をする
/// スクリプト
/// </summary>
public class CountDownScript : MonoBehaviour
{
    /// <summary>カウントダウンの時間</summary>
    [SerializeField] float m_count = 0;
    /// <summary>ゲーム進行のスクリプト</summary>
    [SerializeField] GameManager m_gameManager;
    /// <summary>カウントダウンを表示するテキスト</summary>
    Text m_countDownText;

    [SerializeField] TimerScript m_timer = default;

    void Start()
    {
        m_countDownText = GetComponent<Text>();
    }

    void Update()
    {
        m_count -= Time.deltaTime;

        m_countDownText.text = m_count.ToString("F0");


        if (m_count <= 0)
        {
            m_countDownText.text = "スタート！！";
            m_gameManager.m_moveFlag = true;
            m_timer.m_timerFlag = true;
        }

        if (m_count <= -1)
        {
            m_countDownText.gameObject.SetActive(false);
        }
    }
}
