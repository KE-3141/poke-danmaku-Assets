using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShotPhysics))]
public class ShotPosition : MonoBehaviour
{
    public Bullet bullet;
    public int attack;
    public string enemyTagName = "Enemy";

    public float shootRate = 0.5f;
    public float rotationZOnFocusMode;
    public bool isShooting;
    public float homingForceRate = 0f;

    private Player player;

    private bool wasSlowBeforeOneFrame = false;
    public float defaultRotationZ;
    public EnemyFetcher enemyFetcher;
    private ShotPhysics shotPhysics;

    public IEnumerator Start()
    {
        this.player = GetComponentInParent<Player>();
        this.enemyFetcher = new EnemyFetcher();
        this.defaultRotationZ = this.transform.localRotation.eulerAngles.z;
        this.shotPhysics = GetComponent<ShotPhysics>();

        while (true)
        {
            this.Shoot(this.transform, this.isShooting);
            yield return new WaitForSeconds(shootRate);
        }
    }

    public void Shoot(Transform origin, bool isShooting = true)
    {
        if (this.isShooting)
        {
            StartShooting();
        }
        else
        {
            StopShooting();
        }
    }

    private void StartShooting()
    {
        StartCoroutine(_Shoot(transform));
    }

    private void StopShooting()
    {
        StopCoroutine(_Shoot(transform));
    }

    private IEnumerator _Shoot(Transform origin)
    {
        this.bullet.Instantiate(origin, this.shotPhysics, this);

        yield return new WaitForSeconds(shootRate);
    }

    public void Update()
    {
        if (this.player != null && this.player.isSlow && !wasSlowBeforeOneFrame)
        {
            transform.localRotation = Quaternion.Euler(0, 0, this.rotationZOnFocusMode);
            this.wasSlowBeforeOneFrame = true;
        }
        else if (this.player != null && !this.player.isSlow && wasSlowBeforeOneFrame)
        {
            transform.localRotation = Quaternion.Euler(0, 0, this.defaultRotationZ);
            this.wasSlowBeforeOneFrame = false;
        }

        if (this.homingForceRate > 0)
        {
            this.enemyFetcher.FetchClosestEnemy(transform, this.enemyTagName);
        }
    }
}