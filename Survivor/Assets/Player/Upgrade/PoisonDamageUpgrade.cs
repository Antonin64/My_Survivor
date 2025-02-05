using UnityEngine;

public class PoisonDamageUpgrade : MonoBehaviour, IUpgrade
{
    public float poisonDamage = 10f;
    public Sprite cardDesign;
    public float dropChance = 30f;

    public Sprite CardSprite => cardDesign;
    public float DropChance => dropChance;

    public void Apply(PlayerController player)
    {
        player.PoisonDamage += poisonDamage;
    }
}
