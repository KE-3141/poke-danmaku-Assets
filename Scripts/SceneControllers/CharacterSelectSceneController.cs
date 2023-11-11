using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterSelectSceneController : SceneController
{
    private bool hasSelected;
    public List<Player> characters;

    private int currentIndex = 0;
    private bool isTryMode;
    private AvailableArea availableArea;
    public static Player selectedCharacter;

    private Dictionary<string, Label> labels = new Dictionary<string, Label>();

    new public void Start()
    {
        base.Start();
        this.availableArea = FindObjectOfType<AvailableArea>();

        this.SwitchCharacter(0);
        selectedCharacter.isInCharacterSelectScene = !this.isTryMode;

        this.SetVisualElement();
        this.SetPlayerPicture();
    }

    protected override void Trigger()
    {
        this.hasSelected = Input.GetKeyDown(KeyCode.Return);

        if (this.hasSelected)
        {
            this.hasTriggered = true;
        }
    }

    protected override void StartTransition()
    {
        Initiate.Fade(this.nextSceneName, Color.black, 1.5f);
    }

    private void SwitchCharacter(int direction)
    {
        this.currentIndex += direction;

        if (this.currentIndex < 0)
        {
            this.currentIndex = this.characters.Count - 1;
        }
        else if (this.currentIndex >= this.characters.Count)
        {
            this.currentIndex = 0;
        }

        Destroy(GetComponentInChildren<Player>()?.gameObject);

        selectedCharacter = PlayerFactory.SpawnPlayer(
            this.characters[this.currentIndex].GetComponent<Player>(),
            this.availableArea.gameObject
        ).GetComponent<Player>();

        selectedCharacter.isInCharacterSelectScene = !this.isTryMode;

        this.SetVisualElement();
        this.SetPlayerPicture();

        // PlayerPrefs.SetString(
        //     "selectedCharacter",
        //     selectedCharacter.playerInformation.prefabName
        // );
    }

    private void SetPlayerPicture()
    {
        PlayerPicture playerPicture = GameObject.FindObjectOfType<PlayerPicture>();
        playerPicture.ChangeCharacter(selectedCharacter);
    }

    private void ToggleTryMode()
    {
        this.isTryMode = !this.isTryMode;
        selectedCharacter.isInCharacterSelectScene = !this.isTryMode;
    }

    new public void Update()
    {
        base.Update();

        if (!this.isTryMode && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.SwitchCharacter(-1);
        }
        else if (!this.isTryMode && Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.SwitchCharacter(1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.ToggleTryMode();
        }
    }

    private void SetVisualElement()
    {
        this.labels.Clear();
        UIDocument uiDocument = GetComponent<UIDocument>();
        PlayerInformation playerInformation = selectedCharacter.playerInformation;

        // this.labels.Add(
        //     "characterName",
        //     uiDocument.rootVisualElement.Q<Label>("CharacterName")
        // );
        this.labels.Add(
            "standardShotName",
            uiDocument.rootVisualElement.Q("StandardShot").Q<Label>("Name")
        );
        this.labels.Add(
            "standardShotDescription",
            uiDocument.rootVisualElement.Q("StandardShot").Q<Label>("Description")
        );
        this.labels.Add(
            "optionShotName",
            uiDocument.rootVisualElement.Q("OptionShot").Q<Label>("Name")
            );
        this.labels.Add(
            "optionShotDescription",
            uiDocument.rootVisualElement.Q("OptionShot").Q<Label>("Description")
        );
        this.labels.Add(
            "specialShotName",
            uiDocument.rootVisualElement.Q("SpecialShot").Q<Label>("Name")
        );
        this.labels.Add(
            "specialShotDescription",
            uiDocument.rootVisualElement.Q("SpecialShot").Q<Label>("Description")
        );
        this.labels.Add(
            "abilityName",
            uiDocument.rootVisualElement.Q("Ability").Q<Label>("Name")
        );
        this.labels.Add(
            "abilityDescription",
            uiDocument.rootVisualElement.Q("Ability").Q<Label>("Description")
        );


        // this.labels["characterName"].text = playerInformation.characterName;
        this.labels["standardShotName"].text = playerInformation.standardShotName;
        this.labels["standardShotDescription"].text = playerInformation.standardShotDescription;
        this.labels["optionShotName"].text = playerInformation.optionShotName;
        this.labels["optionShotDescription"].text = playerInformation.optionShotDescription;
        this.labels["specialShotName"].text = playerInformation.specialShotName;
        this.labels["specialShotDescription"].text = playerInformation.specialShotDescription;
        this.labels["abilityName"].text = playerInformation.abilityName;
        this.labels["abilityDescription"].text = playerInformation.abilityDescription;
    }
}
