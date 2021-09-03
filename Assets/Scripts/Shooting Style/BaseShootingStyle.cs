using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseShootingStyle : ScriptableObject
{
    public abstract void Shooting(Transform fireTransform, float forceAmount, GameObject player, ShellPoolManager.ShellType shellType);
    public abstract void SetUp(string fireButton);

    public abstract void UpdateFunc();
}
