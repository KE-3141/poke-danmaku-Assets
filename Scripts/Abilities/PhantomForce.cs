using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Can teleport to the another side of the availavle area.
 */
public class PhantomForce : Ability
{
    new protected bool isPerformable
    {
        get
        {
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                return false;
            }

            return this.player.availableArea.isTouchingWall;
        }
    }

    public override void Perform()
    {
        if (this.isPerformable)
        {
            Vector2 playerPosition = this.player.transform.position;


            this.player.transform.position = playerPosition;
        }
    }
}
