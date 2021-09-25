using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// シーンの遷移をするスクリプト
/// </summary>
public class LoadSceneScript : MonoBehaviour
{
    public int m_sceneIndex = 0;

    private void Start()
    {
        m_sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    /// <summary>タイトルに戻る</summary>
    public void TitleBack()
    {
        SceneManager.LoadScene("Title");
        GameManager.m_life = 3;
    }

    /// <summary>リプレイ</summary>
    public void Replay()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>次のステージに進む</summary>
    public void NextScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        int i = scene.buildIndex; 
        i++;
        int j = SceneManager.sceneCountInBuildSettings;
        
        if (j - i > 0)
        {
            SceneManager.LoadScene(i); // 次のシーンに進む
        }
    }

    public void TrainingScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
