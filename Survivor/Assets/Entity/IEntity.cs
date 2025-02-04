using UnityEngine;

public interface IEntity
{
    float Health { get; set; }
    float MaxHealth { get; set; }
    float Damage { get; set; }
    float MovementSpeed { get; set; }
    void TakeDamage(float amount);
}