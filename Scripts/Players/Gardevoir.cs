public class Gardevoir : Player
{
  public override void Instantiate()
  {
    this.ability = new FutureSight().Instantiate(this);
    this.playerInformation = new PlayerInformation(
        prefabName: "Gardevoir",
        characterName: "サーナイト",
        standardShotName: "サイコショック",
        standardShotDescription: "念波を実体化し、前方に放つ。",
        optionShotName: "マジカルリーフ",
        optionShotDescription: "相手を追跡する不思議な葉っぱで攻撃する",
        specialShotName: "ミストバースト",
        specialShotDescription: "自分の周りの全てのものを攻撃する。",
        abilityName: "みらいよち",
        abilityDescription: "集中時に被弾すると、ミストバーストのPPを消費してダメージを無効化する。"
    );
  }
}