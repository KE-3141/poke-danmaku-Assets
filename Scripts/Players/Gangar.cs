public class Gangar : Player
{
  public override void Instantiate()
  {
    this.ability = new PhantomForce().Instantiate(this);
    this.playerInformation = new PlayerInformation(
        prefabName: "Gangar",
        characterName: "ゲンガー",
        standardShotName: "シャドーボール",
        standardShotDescription: "前方に向けて影の玉を放つ。",
        optionShotName: "たたりめ",
        optionShotDescription: "集中時相手にまとわりつく怨念で攻撃する。",
        specialShotName: "のろい",
        specialShotDescription: "徐々に相手にダメージを与える呪いをかける",
        abilityName: "ゴーストダイブ",
        abilityDescription: "画面端からもう一方の画面端へ瞬間移動する。"
    );
  }
}