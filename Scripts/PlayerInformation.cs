public class PlayerInformation
{
    public string prefabName { get; private set; }
    public string characterName { get; private set; }

    public string standardShotName { get; private set; }
    public string standardShotDescription { get; private set; }

    public string optionShotName { get; private set; }
    public string optionShotDescription { get; private set; }

    public string specialShotName { get; private set; }
    public string specialShotDescription { get; private set; }

    public string abilityName { get; private set; }
    public string abilityDescription { get; private set; }

    public PlayerInformation(
        string prefabName,
        string characterName,
        string standardShotName,
        string standardShotDescription,
        string optionShotName,
        string optionShotDescription,
        string specialShotName,
        string specialShotDescription,
        string abilityName,
        string abilityDescription
    )
    {
        this.prefabName = prefabName;
        this.characterName = characterName;
        this.standardShotName = standardShotName;
        this.standardShotDescription = standardShotDescription;
        this.optionShotName = optionShotName;
        this.optionShotDescription = optionShotDescription;
        this.specialShotName = specialShotName;
        this.specialShotDescription = specialShotDescription;
        this.abilityName = abilityName;
        this.abilityDescription = abilityDescription;
    }
}
