using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public WeaponScriptable weaponData;
    protected Vector3 direction;
    public float destroyAfterSeconds;

    protected PlayerController pc;

    protected float curDmg;
    protected float curFireDmg;
    protected float curIceDmg;
    protected float curPoisonDmg;
    protected float curElectricDmg;
    protected float curSpeed;
    protected float curAttSpeed;
    protected float curCount;
    protected float curPierce;

    public void applyPlayerController(PlayerController pc)
    {
        this.pc = pc;

        curDmg = weaponData.damage * pc.Damage;
        curFireDmg = (weaponData.fireDamage + pc.FireDamage) * pc.Damage;
        curIceDmg = (weaponData.iceDamage + pc.IceDamage) * pc.Damage;
        curPoisonDmg = (weaponData.poisonDamage + pc.PoisonDamage) * pc.Damage;
        curElectricDmg = (weaponData.electricDamage + pc.ElectricDamage) * pc.Damage;
        curAttSpeed = weaponData.attackSpeed * pc.AttackSpeed;
        curCount = weaponData.count + pc.ProjectileCount;
    }
    
    void Awake()
    {
        curDmg = weaponData.damage;
        curSpeed = weaponData.speed;
        curAttSpeed = weaponData.attackSpeed;
        curCount = weaponData.count;
        curFireDmg = weaponData.fireDamage;
        curIceDmg = weaponData.iceDamage;
        curPoisonDmg = weaponData.poisonDamage;
        curElectricDmg = weaponData.electricDamage;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionCheck(Vector3 dir)
    {
        direction = dir;


        //rotation fix
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Apply the rotation to the transform
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
         if (col.CompareTag("Mobs"))
        {
            IEntity entity = col.GetComponent<IEntity>();
            if (entity != null) {
                entity.TakeDamage(curDmg);
                curPierce++;
                if (curPierce >= weaponData.projectilePierce)
                    Destroy(gameObject);
            }
        }
    }
}
