using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[DisallowMultipleComponent]
public class Bullet : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public ShotPosition shotPosition;
    private ShotPhysics shotPhysics;
    public float delaySeconds;
    public Vector3 defaultDirection;

    public Bullet Instantiate(Transform transform, ShotPhysics shotPhysics, ShotPosition shotPosition)
    {
        Bullet bullet = Instantiate(this, transform.position, transform.rotation);
        bullet.rb = bullet.GetComponent<Rigidbody2D>();
        bullet.shotPhysics = shotPhysics;
        bullet.defaultDirection = shotPosition.transform.up;
        bullet.delaySeconds = shotPhysics.delaySeconds;
        bullet.shotPosition = shotPosition;

        return bullet;
    }

    private void Go()
    {
        this.shotPhysics.Force(this);
    }

    public void Update()
    {
        this.Go();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
