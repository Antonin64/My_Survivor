using UnityEngine;

public class HealthUpgrade : MonoBehaviour, IUpgrade
{
    public float maxHealthIncrease = 20f;
    public Sprite cardDesign;

    public Sprite CardSprite => cardDesign;

    public void Apply(PlayerController player)
    {
        player.MaxHealth += maxHealthIncrease;
    }
}
