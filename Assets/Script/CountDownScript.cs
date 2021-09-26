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
    AudioSource m_audio = default;
    public bool m_countFlag = false;
    [SerializeField] AudioClip m_startSE = default;
    private bool m_seFlag = false;
    void Start()
    {
        m_countDownText = GetComponent<Text>();
        m_countDownText.text = "";
        m_audio = this.gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (m_countFlag)
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
            if (!m_seFlag)
            {
                m_audio.PlayOneShot(m_startSE);
                m_seFlag = true;
            }
        }

        if (m_count <= -1)
        {
            m_countDownText.gameObject.SetActive(false);
        }
    }
}
