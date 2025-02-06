using UnityEngine;
using System.Collections;

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

        // Spawn the sword above the player's head
        Vector3 spawnPos = transform.position + new Vector3(0, 3f, 0);
        GameObject spawnedSword = Instantiate(weaponStats.weaponPrefab, spawnPos, Quaternion.identity); // Get the prefab from the ScriptableObject
        spawnedSword.transform.parent = transform; // Parent the sword to the player

        // Rotate the sword to face the direction of the last movement
        float angle = Mathf.Atan2(pc.lastMoveDir.y, pc.lastMoveDir.x) * Mathf.Rad2Deg;
        spawnedSword.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        spawnedSword.GetComponent<MeleeWeaponBehaviour>().applyPlayerController(pc); // Apply the player's stats to the sword

        // Start the slashing coroutine
        StartCoroutine(Slash(spawnedSword, pc.lastMoveDir.x));
    }

    private IEnumerator Slash(GameObject sword, float directionX)
    {
        float duration = weaponStats.speed; // Duration of the slash
        float elapsed = 0f;
        float startAngle = directionX > 0 ? 90f : -270f; // Start angle (above the player's head)
        float endAngle = -90f; // End angle (below the player's feet)
        float radius = 0.6f; // Distance from the player

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            float angle = Mathf.Lerp(startAngle, endAngle, t);
            float radian = angle * Mathf.Deg2Rad;
            Vector3 offset = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0) * radius;
            sword.transform.position = transform.position + offset;
            sword.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
            yield return null;
        }

        // Destroy the sword after the slash
        Destroy(sword);
    }
}