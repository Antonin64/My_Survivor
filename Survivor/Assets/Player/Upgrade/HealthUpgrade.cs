using UnityEngine;

public class HealthUpgrade : MonoBehaviour, IUpgrade
{
    public float maxHealthIncrease = 20f;
    public Sprite cardDesign;
    public float dropChance = 30f;

    public Sprite CardSprite => cardDesign;
    public float DropChance => dropChance;

    public void Apply(PlayerController player)
    {
        player.MaxHealth += maxHealthIncrease;
    }
}
