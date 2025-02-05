using UnityEngine;

public class ArmorUpgrade : MonoBehaviour, IUpgrade
{
    public float armorIncrease = 5f;
    public Sprite cardDesign;
    public float dropChance = 30f;

    public Sprite CardSprite => cardDesign;
    public float DropChance => dropChance;

    public void Apply(PlayerController player)
    {
        player.Armor += armorIncrease;
    }
}
