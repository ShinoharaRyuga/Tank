using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ItemBaseを継承しplayerの
/// 弾丸の速度が上がるアイテムのスクリプト
/// </summary>
public class BulletSpeedUp : ItemBase
{
    public override void Use()
    {
        FindObjectOfType<TankController>().SetBullet(Bulletkinds.speed);
    }
}
