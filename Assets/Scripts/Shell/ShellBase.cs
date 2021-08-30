using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShellBase : MonoBehaviour
{
    // Basic damage when hit enemy tank directly
    [SerializeField] protected float basicDamage;
    [SerializeField] protected Rigidbody shellRigit;
    [SerializeField] protected ShellExplosion explosion;
    public ShellPoolManager.ShellType type;
    public abstract void Fire(Transform fireTransform, float forceAmount, GameObject player);

    public abstract void EnemyFind(GameObject enemy);

    public abstract void BackToPool();

    public abstract void Deactive();
}
