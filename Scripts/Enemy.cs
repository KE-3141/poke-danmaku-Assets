using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    new public void Start()
    {
        base.Start();
        Move(transform.up * -1);
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
