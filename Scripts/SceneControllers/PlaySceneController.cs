using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySceneController : SceneController
{
    new public void Start()
    {
        base.Start();
        string characterName = PlayerPrefs.GetString("selectedCharacter");

        GameObject availableArea = GameObject.Find("AvailableArea");

        PlayerFactory.SpawnPlayer(
            CharacterSelectSceneController.selectedCharacter,
            availableArea
        );
    }

}
