using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Character : Shooter
{
    [SerializeField] public float speed;
    [SerializeField] public int hp;
    [SerializeField] public GameObject explosion;
    [SerializeField] public bool isInvincible;

    public void Move(Vector2 direction)
    {
    }

    public void Explode()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    public void TakeDamage(Collider2D collision)
    {
        hp -= collision.gameObject.GetComponent<Bullet>().shotPosition.attack;

        if (hp <= 0)
        {
            this.Explode();
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("AvailableArea"))
        {
            Destroy(collision.gameObject);

            if (!isInvincible)
            {
                this.TakeDamage(collision);
            }
        }
    }
}
