using UnityEngine;

public class ArrowController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        if (pc.nearestEnemyPos == Vector3.zero)
            return;
        GameObject arrow = Instantiate(weaponStats.weaponPrefab);
        arrow.transform.position = transform.position;
        Vector2 attackDir = (pc.nearestEnemyPos - transform.position).normalized;
        arrow.GetComponent<ProjectileWeaponBehaviour>().DirectionCheck(attackDir);
        arrow.GetComponent<ProjectileWeaponBehaviour>().applyPlayerController(pc);
    }
}
