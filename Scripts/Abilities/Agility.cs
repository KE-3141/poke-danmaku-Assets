using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class is responsible for the ability of the player to move faster.
 */
public class Agility : Ability
{
    new protected bool isPerformable { get { return !this.player.isSlow && !this.player.isShooting; } }
    private float defaultSpeed;
    private AfterImageEffect afterImageEffect;
    // True if the agility ability was activated before one frame
    private bool wasAgiiltyActivated = false;

    new public Agility Instantiate(Player player)
    {
        Agility ability = (Agility)base.Instantiate(player);
        ability.defaultSpeed = ability.player.speed;
        ability.afterImageEffect = ability.player.GetComponent<AfterImageEffect>();
        ability.afterImageEffect.CreateAfterImage();

        return ability;
    }


    public override void Perform()
    {
        if (this.isPerformable && !this.wasAgiiltyActivated)
        {
            this.player.speed = this.defaultSpeed * 2f;
            this.wasAgiiltyActivated = true;
            this.afterImageEffect.isCreatingAfterImage = true;
        }
        else if (!this.isPerformable && this.wasAgiiltyActivated)
        {
            this.player.speed = this.defaultSpeed;
            this.wasAgiiltyActivated = false;
            this.afterImageEffect.isCreatingAfterImage = false;
        }
    }
}
