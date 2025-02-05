using UnityEngine;

public class ElementalSwapUpgrade : MonoBehaviour, IUpgrade
{
    public Sprite cardDesign;
    public float swapTime = 3f;
    public float dropChance = 30f;

    public Sprite CardSprite => cardDesign;

    public void Apply(PlayerController player)
    {
        player.StartElementSwap(swapTime);
    }
}
