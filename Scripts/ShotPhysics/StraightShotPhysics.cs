using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightShotPhysics : ShotPhysics
{
    public override void Force(Bullet bullet)
    {
        bullet.rb.velocity = bullet.defaultDirection * this.speed;
    }
}
