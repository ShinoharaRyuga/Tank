using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedUp : ItemBase
{
    public override void Use()
    {
        FindObjectOfType<TankController>().SpeedUp(16f);
    }
}
