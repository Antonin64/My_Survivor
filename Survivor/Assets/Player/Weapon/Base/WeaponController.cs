using UnityEngine;

public class WeaponController : MonoBehaviour
{

    [Header("Weapon Stats")]
    public WeaponScriptable weaponStats;

    float currentCooldown;

    public PlayerController pc;

    protected virtual void Start()
    {
        currentCooldown = weaponStats.attackSpeed;
    }

    void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown < 0f)
            Attack();
    }

     protected virtual void Attack()
    {
        currentCooldown = weaponStats.attackSpeed;
        

    }

}
