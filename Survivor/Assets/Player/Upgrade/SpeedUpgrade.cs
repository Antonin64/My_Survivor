using UnityEngine;

public class SpeedUpgrade : MonoBehaviour, IUpgrade
{
    public float speedIncrease = 2f;
    public Sprite cardDesign;

    public Sprite CardSprite => cardDesign;

    public void Apply(PlayerController player)
    {
        player.MovementSpeed += speedIncrease;
    }
}
