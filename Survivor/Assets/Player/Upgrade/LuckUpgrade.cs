using UnityEngine;

public class LuckUpgrade : MonoBehaviour, IUpgrade
{
    public float luckIncrease = 5f;
    public Sprite cardDesign;
    public float dropChance = 30f;

    public Sprite CardSprite => cardDesign;

    public void Apply(PlayerController player)
    {
        player.Luck += luckIncrease;
    }
}
