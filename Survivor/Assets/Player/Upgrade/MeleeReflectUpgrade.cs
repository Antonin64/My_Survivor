using UnityEngine;

public class MeleeReflectUpgrade : MonoBehaviour, IUpgrade
{
    public Sprite cardDesign;
    public float dropChance = 30f;

    public Sprite CardSprite => cardDesign;

    public void Apply(PlayerController player)
    {
        player.EnableMeleeReflect();
    }
}
