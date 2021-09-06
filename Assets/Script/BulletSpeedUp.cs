using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeedUp : ItemBase
{
    public override void Use()
    {
        FindObjectOfType<PlayerBulletAddForce>().ChangeSpeed(16);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
