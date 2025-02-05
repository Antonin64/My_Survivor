# How to Add a New Weapon

Weapons in the game consist of **four main elements:**  

1. **Prefab** (Defines visuals & hitbox)  
2. **Behaviour** (Handles collision & damage)  
3. **Controller** (Defines attack logic)  
4. **Scriptable Object** (Stores weapon stats)  

---

## 1. The Prefab  
- The prefab represents the **visual model** of the weapon.  
- It must include a **2D Collider** with **Trigger enabled**.  
- You must attach a **Behaviour script** to the prefab.  

> **Example:** Check `Assets/Player/Weapon/Prefab/` for existing weapon prefabs.  

---

## 2. The Behaviour  
This script is attached to the **prefab** and determines how the weapon interacts with enemies.  
- It should **inherit from** either:  
  - `MeleeWeaponBehaviour` (for melee weapons)  
  - `ProjectileWeaponBehaviour` (for projectiles)  

### **ProjectileWeaponBehaviour Special Features:**  
- Access **`DirectionCheck()`** to determine projectile direction.  
- Automatically destroys itself on collision.  
- Can override `OnTriggerEnter2D()` for custom collision logic.  

---

## 3. The Controller  
- Defines what the weapon does when attacking.  
- Override the `void Attack()` method to customize attack behavior.  

### **Useful Variables:**  
- `weaponStats` → The weapon’s scriptable object.  
- `pc` → The **PlayerController**, giving access to:  
  - `(Vector2) lastMoveDir` → Last movement direction.  
  - `(Vector3) nearestEnemyPos` → Nearest enemy position (`Vector3.zero` if none).  
  - Player stats: `MaxHealth`, `Damage`, `Health`, `MovementSpeed`.  

---

## 4. The Scriptable Object  
- Stores the weapon's **damage, speed, range, and other stats**.  
- You can create a new weapon scriptable object inside **Unity**:  
  - Right-click in the Project window → `Create → Weapon Stats`.  
- Example files can be found in:  
  ```plaintext
  Assets/Player/Weapon/Prefab/
