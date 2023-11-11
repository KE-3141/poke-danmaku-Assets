using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory : MonoBehaviour
{
    private static Vector3 spawnPosition = new Vector3(0, 0, 0);

    public static GameObject SpawnPlayer(
        Player player,
        GameObject availableArea
    )
    {
        player.Instantiate();

        GameObject spawnedPlayer = Instantiate(
            (GameObject)Resources.Load(player.prefabResourcePath()),
            availableArea.transform.position + spawnPosition,
            availableArea.transform.rotation
        );

        // set available area as parent
        spawnedPlayer.transform.parent = availableArea.transform;

        return spawnedPlayer;
    }


    public void Update()
    {
    }
}
