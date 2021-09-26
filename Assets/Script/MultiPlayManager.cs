using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiPlayManager : MonoBehaviour
{
    [SerializeField] Text m_resultText = default;

    [SerializeField] MultiPlayCount m_countScript = default;

    LoadSceneScript m_loadSceneScript = default;

    AudioSource m_audio = default;
    [SerializeField] AudioClip m_resultSE = default;
    /// <summary>敵とPlayerの動きを制限するフラグ</summary>
    public bool m_moveFlag = false;
    /// <summary>敵とPlayerの動きを制限するフラグ</summary>
    public int m_result = 0;

    public int m_readyCount = 0;

    public bool m_endFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        m_loadSceneScript = GetComponent<LoadSceneScript>();
        m_audio = this.gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        SetResult();
        if (Input.GetButton("X1Start"))
        {
            StartCoroutine(TitleBack());
        }
    }

    void SetResult()
    {
        if (m_readyCount == 1)
        {
            m_countScript.m_countFlag = true;
        }

        if (m_result != 0)
        {
            m_moveFlag = false;
        }

        if (m_result == 1 && m_endFlag)
        {
            m_resultText.color = Color.red;
            m_resultText.text = "1PWin";
            m_endFlag = false;
            m_audio.PlayOneShot(m_resultSE);
            StartCoroutine(TitleBack());
        }
        else if (m_result == 2 && m_endFlag)
        {
            Debug.Log("2P勝");
            m_resultText.color = Color.blue;
            m_resultText.text = "2PWin";
            m_endFlag = false;
            m_audio.PlayOneShot(m_resultSE);
            StartCoroutine(TitleBack());
        }
    }

    public IEnumerator TitleBack()
    {
        yield return new WaitForSeconds(3f);
        m_loadSceneScript.TitleBack();
    }
}
