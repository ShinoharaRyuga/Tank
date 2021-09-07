using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムを基底クラス
/// </summary>
public abstract class ItemBase : MonoBehaviour
{
    public abstract void Use();

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerTank")
        {
            Destroy(this.gameObject);
            Use();
        }
    }
}
