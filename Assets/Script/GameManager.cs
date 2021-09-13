using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲームの進行をするスクリプト
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>クリアを表示するテキスト</summary>
    [SerializeField] Text m_clearText;
    /// <summary>失敗を表示するテキスト</summary>
    [SerializeField] Text m_failText;
    /// <summary>タイトルに戻るボタン</summary>
    [SerializeField] GameObject m_titleBackButton;
    /// <summary>Playerの戦車をコントロールするスクリプト</summary>
    [SerializeField] TankController m_tankControllerScript;
    /// <summary>敵とPlayerの動きを制限するフラグ</summary>
    public bool m_moveFlag = false;
    /// <summary>playerの失敗を感知するフラグ</summary>
    public bool m_failFlag = false;
    /// <summary>ステージに存在する敵の総数</summary>
    public int m_enemy = 0;
    /// <summary>Playerの残機</summary>
    public static int m_life = 3;
    /// <summary>playerが全ての敵を倒した時のフラグ</summary>
    bool m_clearFlag = false;
  
    void Start()
    {
        m_clearText.gameObject.SetActive(false);
        m_failText.gameObject.SetActive(false);
        m_titleBackButton.SetActive(false);
    }

    void Update()
    {
        //クリア判定
        if (m_enemy <= 0 && !m_failFlag)
        {
            m_clearText.gameObject.SetActive(true);
            m_titleBackButton.SetActive(true);
            m_moveFlag = false;
            m_clearFlag = true;
        }

        //失敗判定
        if (m_failFlag && !m_clearFlag && m_life > 0)
        {
            Debug.Log("fail");
            m_failText.gameObject.SetActive(true);
            m_moveFlag = false;
        }
        else if(m_life <= 0 && !m_clearFlag) //GAMEOVER判定
        {
            Debug.Log("OVER");
            m_failText.text = "GAME OVER";
            m_failText.gameObject.SetActive(true);
            m_titleBackButton.SetActive(true);
        }
    }
}
