using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ArrowScript : MonoBehaviour
{
    [SerializeField] EventSystem m_eventSystem = default;
    [SerializeField] GameObject[] m_arrow = default;
    [SerializeField] Button m_1PPlayButton = default;
    /// <summary>現在選択されているボタン</summary>
    GameObject m_selectedObj;
    // Start is called before the first frame update
    void Start()
    {
        m_1PPlayButton.Select();
    }

    // Update is called once per frame
    void Update()
    {
        m_selectedObj = m_eventSystem.currentSelectedGameObject.gameObject; //現在選択されているボタンを取得
        SetArrow();
    }

    public void SetArrow()
    {
        switch (m_selectedObj.name)
        {
            case "1PPlay":
                SelectArrow(0);
                break;
            case "2PPlay":
                SelectArrow(1);
                break;
            case "Training":
                SelectArrow(2);
                break;
        }
    }

    /// <summary>矢印を変える関数</summary>
    /// <param name="Set"></param>
    public void SelectArrow(int Set)
    {
        for (var i = 0; i < m_arrow.Length; i++)
        {
            if (i != Set)
            {
                m_arrow[i].SetActive(false);
            }
            else
            {
                m_arrow[i].SetActive(true);
            }
        }
    }
}
