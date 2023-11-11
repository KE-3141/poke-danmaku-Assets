using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShotPosition))]
public class ShotPhysics : MonoBehaviour
{
    [SerializeField] public int speed;
    [SerializeField] public float delaySeconds;
    protected ShotPosition shotPosition;

    public void Start()
    {
        this.shotPosition = GetComponent<ShotPosition>();
    }

    public virtual void Force(Bullet bullet)
    {
    }

    public void Update()
    {
    }
}
