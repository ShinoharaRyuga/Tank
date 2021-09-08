using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 二連砲にするアイテムの
/// スクリプト
/// </summary>
public class DoubleShotScript : ItemBase
{
    /// <summary>Itemを取った後飛ばす弾丸を増やす　二連砲</summary>
    public override void Use()
    {
        FindObjectOfType<TankController>().SetBullet(Bulletkinds.Double);
    }
}
