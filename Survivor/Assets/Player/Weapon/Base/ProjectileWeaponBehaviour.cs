using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public WeaponScriptable weaponData;
    protected Vector3 direction;
    public float destroyAfterSeconds;

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionCheck(Vector3 dir)
    {
        direction = dir;
    }
}
