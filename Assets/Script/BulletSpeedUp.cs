using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ItemBaseを継承しplayerの
/// 弾丸の速度が上がるアイテムのスクリプト
/// </summary>
public class BulletSpeedUp : ItemBase
{
    /// <summary>通常の弾丸よりスピードが速い弾丸を飛ばす</summary>
    public override void Use()
    {
        FindObjectOfType<TankController>().SetBullet(Bulletkinds.Speed);
    }
}
