using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingShotPhysics : ShotPhysics
{
    public override void Force(Bullet bullet)
    {
        bullet.delaySeconds -= Time.deltaTime;

        if (bullet.delaySeconds < 0 && this.shotPosition.enemyFetcher.closestEnemy != null)
        {
            Vector2 direction = (this.shotPosition.enemyFetcher.closestEnemy.transform.position - (bullet.transform.position * this.shotPosition.homingForceRate)).normalized;
            bullet.rb.velocity = Vector2.Lerp(bullet.rb.velocity, direction * this.speed, 0.05f);

            Vector3 diff = (this.shotPosition.enemyFetcher.closestEnemy.position - bullet.transform.position);
            bullet.transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);
        }
        else
        {
            bullet.rb.velocity = transform.up * this.speed;
        }
    }
}
