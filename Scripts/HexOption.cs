using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexOption : Option
{
    public AnimationCurve curve;
    private EnemyFetcher enemyFetcher;
    private Vector3 distanceFromTarget;
    private float radius;
    private float angle;

    new public void Start()
    {
        base.Start();
        this.enemyFetcher = new EnemyFetcher();
        this.distanceFromTarget = new Vector3(0, 1, 0);
        this.radius = Vector3.Distance(this.player.transform.position, this.transform.position);

        Vector2 playerDirection = this.player.transform.position;
        this.angle = Mathf.Atan2(playerDirection.y - transform.position.y, playerDirection.x - transform.position.x) * Mathf.Rad2Deg;
    }

    private void RotateAround(Transform target)
    {
        this.angle += 90f * Time.deltaTime;

        var x = target.position.x + Mathf.Cos(this.angle * Mathf.Deg2Rad) * this.radius;
        var y = target.position.y + Mathf.Sin(this.angle * Mathf.Deg2Rad) * this.radius;

        transform.position = Vector2.MoveTowards(transform.position, new Vector3(x, y, 0), 10f * Time.deltaTime);
    }

    new public void Update()
    {
        if (!this.player.isInCharacterSelectScene)
        {
            this.enemyFetcher.FetchClosestEnemy(transform, "Enemy");

            if (!this.player.isSlow)
            {
                this.RotateAround(this.player.transform);

                foreach (ShotPosition shotPosition in shotPositions)
                {
                    shotPosition.transform.rotation = Quaternion.Euler(0, 0, shotPosition.defaultRotationZ);
                }
            }
            else if (this.player.isSlow && this.enemyFetcher.closestEnemy != null)
            {
                this.RotateAround(this.enemyFetcher.closestEnemy);

                Vector3 diff = (this.enemyFetcher.closestEnemy.position - transform.position);

                foreach (ShotPosition shotPosition in this.shotPositions)
                {
                    shotPosition.transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);
                }
            }
        }
    }
}
