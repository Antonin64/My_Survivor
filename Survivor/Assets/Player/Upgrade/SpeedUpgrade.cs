using UnityEngine;

public class SpeedUpgrade : MonoBehaviour, IUpgrade
{
    public float speedIncrease = 2f;
    public Sprite cardDesign;
    public float dropChance = 30f;

    public Sprite CardSprite => cardDesign;
    public float DropChance => dropChance;

    public void Apply(PlayerController player)
    {
        player.MovementSpeed += speedIncrease;
    }
}
