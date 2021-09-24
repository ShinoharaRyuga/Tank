using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour
{
    [SerializeField] GameManager m_gameManager = default;
    [SerializeField] bool m_fallFlag = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (m_fallFlag)
        {
            if (m_gameManager.m_moveFlag && collision.gameObject.tag == "PlayerTank")
            {
                this.GetComponent<Renderer>().material.color = Color.black;
                Destroy(this.gameObject, 5f);
            }
        }
    }
}
