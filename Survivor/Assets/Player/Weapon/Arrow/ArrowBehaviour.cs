using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : ProjectileWeaponBehaviour
{

    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        transform.position += direction * weaponData.speed * Time.deltaTime;
    }
}