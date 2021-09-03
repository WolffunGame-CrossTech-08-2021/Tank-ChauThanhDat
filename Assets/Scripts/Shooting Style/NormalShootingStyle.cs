using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Normal Shooting Style", menuName = "Shooting Style/Normal Style")]
public class NormalShootingStyle : BaseShootingStyle
{
    public override void SetUp(string fireButton)
    {
        return;
    }

    public override void Shooting(Transform fireTransform, float forceAmount, GameObject player, ShellPoolManager.ShellType shellType)
    {
        ShellBase aShell = ShellPoolManager.instance.GetShell(shellType);
        aShell.gameObject.SetActive(true);
        aShell.Fire(fireTransform, forceAmount, player);
    }

    public override void UpdateFunc()
    {
        return;
    }
}
