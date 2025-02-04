using UnityEngine;

public class SwordController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        if (pc.lastMoveDir == Vector2.zero)
            return;
        Vector3 spawnPos = transform.position + (Vector3)pc.lastMoveDir;
        GameObject spawnedSword = Instantiate(weaponStats.weaponPrefab); //get the prefab from the ScriptableObject
        spawnedSword.transform.position = spawnPos; //Assign the position to be the same as this object which is parented to the player
        spawnedSword.transform.parent = transform; //Parent the sword to the player

        float angle = Mathf.Atan2(pc.lastMoveDir.y, pc.lastMoveDir.x) * Mathf.Rad2Deg;
        spawnedSword.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}