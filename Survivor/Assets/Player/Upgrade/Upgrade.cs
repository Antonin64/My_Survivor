using UnityEngine;

public class HealthUpgrade : MonoBehaviour, IUpgrade
{
    public float maxHealthIncrease = 20f;
    public Sprite cardDesign;

    public Sprite CardSprite { get; }

    public void Apply(PlayerController player)
    {
        player.MaxHealth += maxHealthIncrease;
    }
}

public class SpeedUpgrade : MonoBehaviour, IUpgrade
{
    public float speedIncrease = 2f;
    public Sprite cardDesign;

    public Sprite CardSprite { get; }

    public void Apply(PlayerController player)
    {
        player.MovementSpeed += speedIncrease;
    }
}
