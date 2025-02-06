using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{

    [Header("Weapon Stats")]
    public WeaponScriptable weaponStats;

    float currentCooldown;

    public PlayerController pc;

    protected virtual void Start()
    {
        currentCooldown = weaponStats.attackSpeed * pc.AttackSpeed;
    }

    void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown < 0f) {
            StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        for (int i = 0; i < weaponStats.count + pc.ProjectileCount; i++) // start each of the attack with 0.1s interval
        {
            Attack();
            yield return new WaitForSeconds(0.1f);
        }
        currentCooldown = weaponStats.attackSpeed * pc.AttackSpeed;
    }

     protected virtual void Attack()
    {
        currentCooldown = weaponStats.attackSpeed * pc.AttackSpeed;
        

    }

}
