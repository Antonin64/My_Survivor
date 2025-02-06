using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "ScriptableObjects/Weapon")]
public class WeaponScriptable : ScriptableObject
{

    public GameObject weaponPrefab;
    [Header("Weapon Damage")]
    public float damage; //not elemental damage
    public float fireDamage; //NOT IMPLEMENTED
    public float iceDamage; //NOT IMPLEMENTED
    public float poisonDamage; //NOT IMPLEMENTED
    public float electricDamage; //NOT IMPLEMENTED
    [Header("Weapon Stats")]
    public float speed;
    public float attackSpeed;
    public float range;
    public float projectilePierce; //how much enemies the projectile can pierce
    public float critChance; //NOT IMPLEMENTED
    public float critMulti; //NOT IMPLEMENTED
    public int count;

}
