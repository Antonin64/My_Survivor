using UnityEngine;

public class CourageUpgrade : MonoBehaviour, IUpgrade
{
    public float speedPenalty = -1f;
    public float enemyFleeChance = 10f;
    public float courageIncrease = 5f;
    public float attackSpeedIncrease = 0.2f;
    public Sprite cardDesign;
    public float dropChance = 30f;

    public Sprite CardSprite => cardDesign;

    public void Apply(PlayerController player)
    {
        player.MovementSpeed += speedPenalty;
        player.Courage += courageIncrease;
        player.EnemyFleeChance += enemyFleeChance;
        player.AttackSpeed += attackSpeedIncrease;
    }
}
