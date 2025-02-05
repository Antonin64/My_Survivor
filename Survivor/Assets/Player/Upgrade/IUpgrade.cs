using UnityEngine;

public interface IUpgrade
{
    void Apply(PlayerController player);
    Sprite CardSprite { get; }
    float DropChance { get; }
}