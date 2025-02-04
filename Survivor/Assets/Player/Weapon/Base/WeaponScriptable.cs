using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "ScriptableObjects/Weapon")]
public class WeaponScriptable : ScriptableObject
{

    public GameObject weaponPrefab;
    [Header("Weapon Stats")]
    public float damage;
    public float speed;
    public float attackSpeed;
    public float range;


}
