using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFetcher
{
    public Transform closestEnemy;

    public void FetchClosestEnemy(Transform transform, string enemyTagName)
    {
        var targets = GameObject.FindGameObjectsWithTag(enemyTagName);
        if (targets.Length == 1)
        {
            this.closestEnemy = targets[0].transform;
            return;
        }

        GameObject result = null;
        var minTargetDistance = float.MaxValue;
        foreach (var target in targets)
        {
            var targetDistance = Vector3.Distance(transform.position, target.transform.position);
            if (!(targetDistance < minTargetDistance)) continue;
            minTargetDistance = targetDistance;
            result = target.transform.gameObject;
        }

        this.closestEnemy = result?.transform;
    }
}
