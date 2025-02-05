using UnityEngine;

public class ProjectileUpgrade : MonoBehaviour, IUpgrade
{
    public int extraProjectiles = 1;
    public Sprite cardDesign;
    public float dropChance = 30f;

    public Sprite CardSprite => cardDesign;

    public void Apply(PlayerController player)
    {
        player.ProjectileCount += extraProjectiles;
    }
}
