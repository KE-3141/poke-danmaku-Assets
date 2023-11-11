using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public bool isShooting;
    public ShotPosition[] shotPositions;


    public void Start()
    {
        this.shotPositions = GetComponentsInChildren<ShotPosition>();
    }

    public void Shoot()
    {
        foreach (ShotPosition shotPosition in shotPositions)
        {
            shotPosition.isShooting = this.isShooting;
        }
    }

    public void freezeAnimation()
    {
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.enabled = false;
        }
    }

    public void unfreezeAnimation()
    {
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.enabled = true;
        }
    }
}
