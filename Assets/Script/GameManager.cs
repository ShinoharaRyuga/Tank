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
    /// <summary>シーンの遷移をするスクリプト</summary>
    LoadSceneScript m_loadSceneScript;

    [SerializeField] CountDownScript m_countScript = default;

    [SerializeField] Text m_stageText = default;

    [SerializeField] Text m_enemyText = default;
    /// <summary>敵とPlayerの動きを制限するフラグ</summary>
    public bool m_moveFlag = false;
    /// <summary>playerの失敗を感知するフラグ</summary>
    public bool m_failFlag = false;
    /// <summary>ステージに存在する敵の総数</summary>
    public int m_enemy = 0;
    /// <summary>Playerの残機</summary>
    public static  int m_life = 3;
    /// <summary>playerが全ての敵を倒した時のフラグ</summary>
    public  bool m_clearFlag = false;

    void Start()
    {
        m_clearText.gameObject.SetActive(false);
        m_failText.gameObject.SetActive(false);
        m_titleBackButton.SetActive(false);
        m_loadSceneScript = GetComponent<LoadSceneScript>();
    }

    void Update()
    {
        m_enemyText.text = "敵戦車数　" + m_enemy.ToString();

        StartCoroutine(SetFalse());
        //クリア判定
        if (m_enemy <= 0 && !m_failFlag)
        {
            m_clearText.gameObject.SetActive(true);
            m_titleBackButton.SetActive(true);
            m_moveFlag = false;
            m_clearFlag = true;
            StartCoroutine(NextScene());
        }

        //失敗判定
        if (m_failFlag && !m_clearFlag && m_life > 0)
        {
            m_failText.gameObject.SetActive(true);
            m_moveFlag = false;
            StartCoroutine(RePlay());
        }
        else if(m_life <= 0 && !m_clearFlag) //GAMEOVER判定
        {
            m_failText.text = "GAME OVER";
            m_failText.gameObject.SetActive(true);
            m_titleBackButton.SetActive(true);
            StartCoroutine(TitleBack());
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(m_life);
        }

        if (Input.GetButton("X1Start"))
        {
            StartCoroutine(TitleBack());
        }
    }

    /// <summary>次のシーンの遷移をする関数</summary>
    /// <returns></returns>
    private IEnumerator NextScene()
    {
        if (m_loadSceneScript.m_sceneIndex != 30)
        {
            yield return new WaitForSeconds(3f);
            m_loadSceneScript.NextScene();
        }
        else
        {
            yield return new WaitForSeconds(3f);
            m_loadSceneScript.TitleBack();
        }
        
    }

    private IEnumerator RePlay()
    {
        yield return new WaitForSeconds(3f);
        m_loadSceneScript.Replay();
    }

    private IEnumerator SetFalse()
    {
        yield return new WaitForSeconds(3f);
        m_stageText.gameObject.SetActive(false);
        m_enemyText.gameObject.SetActive(false);
        m_countScript.m_countFlag = true;
    }

    public IEnumerator TitleBack()
    {
        yield return new WaitForSeconds(3f);
        m_loadSceneScript.TitleBack();
    }
}
