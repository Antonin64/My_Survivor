using UnityEngine;

public class HealthUpgrade : MonoBehaviour, IUpgrade
{
    public float maxHealthIncrease = 20f;

    public void Apply(PlayerController player)
    {
        player.MaxHealth += maxHealthIncrease;
    }
}

public class SpeedUpgrade : MonoBehaviour, IUpgrade
{
    public float speedIncrease = 2f;

    public void Apply(PlayerController player)
    {
        player.MovementSpeed += speedIncrease;
    }
}
