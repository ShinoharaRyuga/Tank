using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiPlayManager : MonoBehaviour
{
    [SerializeField] Text m_resultText = default;

    [SerializeField] Button m_titleBack = default;

    [SerializeField] Button m_rePlay = default;

    [SerializeField] MultiPlayCount m_countScript = default;
    /// <summary>敵とPlayerの動きを制限するフラグ</summary>
    public bool m_moveFlag = false;
    /// <summary>敵とPlayerの動きを制限するフラグ</summary>
    public int m_result = 0;

    public int m_readyCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_titleBack.gameObject.SetActive(false);
        m_rePlay.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_readyCount == 1)
        {
            m_countScript.m_countFlag = true;
        }

        if (m_result != 0)
        {
            m_moveFlag = false;
            m_resultText.text = "";
        }

        if (m_result == 1)
        {
            m_resultText.color = Color.red;
            m_resultText.text = "1PWin";
            m_titleBack.gameObject.SetActive(true);
            m_rePlay.gameObject.SetActive(true);
        }
        else if (m_result == 2)
        {
            m_resultText.color = Color.blue;
            m_resultText.text = "2PWin";
            m_titleBack.gameObject.SetActive(true);
            m_rePlay.gameObject.SetActive(true);
        }
    }
}
