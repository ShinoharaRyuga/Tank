using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text m_clearText;
    public bool m_moveFlag = false;
    public int m_enemy = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_clearText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_enemy <= 0)
        {
            m_clearText.gameObject.SetActive(true);
            m_moveFlag = false;
        }
    }
}
