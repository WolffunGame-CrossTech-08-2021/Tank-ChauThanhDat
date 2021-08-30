using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMovingShell : ShellBase
{
    [SerializeField] float minStartForce;
    [SerializeField] float maxStartForce;

    public override void BackToPool()
    {
        ShellPoolManager.instance.CollectShell(this);
    }

    public override void EnemyFind(GameObject enemy)
    {
        return;
    }

    public override void Fire(Transform fireTransform, float forceAmount, GameObject player)
    {
        transform.position = fireTransform.position;
        transform.rotation = fireTransform.rotation;
        float force = Mathf.Lerp(minStartForce, maxStartForce, forceAmount);
        shellRigit.velocity = force * fireTransform.forward;
    }
}
