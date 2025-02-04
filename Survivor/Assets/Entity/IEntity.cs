using UnityEngine;

public interface IEntity
{
    float Health { get; set; }
    void TakeDamage(float amount);
}