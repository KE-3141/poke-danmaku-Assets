using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability
{
    protected Player player;
    protected bool isPerformable;

    public Ability Instantiate(Player player)
    {
        this.player = player;

        return this;
    }

    public virtual void Perform()
    {
    }

    public void Update()
    {

    }
}
