public class Pikachu : Player
{
  public override void Instantiate()
  {
    this.ability = new Agility().Instantiate(this);
    this.playerInformation = new PlayerInformation(
        prefabName: "Pikachu",
        characterName: "ピカチュウ",
        standardShotName: "でんきショック",
        standardShotDescription: "前方に向けて電気の刺激を浴びせて攻撃",
        optionShotName: "かげぶんしん",
        optionShotDescription: "自分の動きに合わせて動く分身をつくる",
        specialShotName: "ボルテッカー",
        specialShotDescription: "電気をまとって前方に突進する",
        abilityName: "こうそくいどう",
        abilityDescription: "攻撃をしていない間、すばやさがぐーんと上がる。"
    );
  }
}