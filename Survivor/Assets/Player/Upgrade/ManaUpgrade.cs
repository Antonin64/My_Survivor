using UnityEngine;

public class ManaUpgrade : MonoBehaviour, IUpgrade
{
    public float manaIncrease = 30f;
    public Sprite cardDesign;
    public float dropChance = 30f;

    public Sprite CardSprite => cardDesign;

    public void Apply(PlayerController player)
    {
        player.MaxMana += manaIncrease;
    }
}
