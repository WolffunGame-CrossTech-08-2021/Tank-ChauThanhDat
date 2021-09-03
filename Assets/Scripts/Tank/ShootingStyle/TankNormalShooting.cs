using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNormalShoot", menuName = "Normal Shoot")]
public class TankNormalShooting : ShootingStyle
{
    public override void Fire(Transform t)
    {
        base.Fire(t);
    }
}
