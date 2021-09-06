using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ItemBaseを継承しplayerの
/// 移動速度が上がるアイテムのスクリプト
/// </summary>
public class PlayerSpeedUp : ItemBase
{
    [Tooltip("アイテムを取った後の移動スピード")]
    /// <summary>アイテムを取った後の移動スピード</summary>
    [SerializeField] float m_changeSpeed = 0;
    public override void Use()
    {
        FindObjectOfType<TankController>().SpeedUp(m_changeSpeed);
    }
}
