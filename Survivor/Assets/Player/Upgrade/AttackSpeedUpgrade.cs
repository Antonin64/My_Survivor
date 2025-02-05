using UnityEngine;

public class AttackSpeedUpgrade : MonoBehaviour, IUpgrade
{
    public float attackSpeedIncrease = 0.2f;
    public Sprite cardDesign;
    public float dropChance = 30f;

    public Sprite CardSprite => cardDesign;

    public void Apply(PlayerController player)
    {
        player.AttackSpeed += attackSpeedIncrease;
    }
}
