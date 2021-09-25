using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMultiplay : MonoBehaviour
{
    public void LoadScene()
    {
        int x = 0;
        x = Random.Range(1, 6); ;

        if (x == 1)
        {
            SceneManager.LoadScene("Stage 1");
        }
        else if (x == 2)
        {
            SceneManager.LoadScene("Stage 2");
        }
        else if (x == 3)
        {
            SceneManager.LoadScene("Stage 3");
        }
        else if (x == 4)
        {
            SceneManager.LoadScene("Stage 4");
        }
        else if (x == 5)
        {
            SceneManager.LoadScene("Stage 5");
        }

    }
}
