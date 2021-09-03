using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Cone Shooting Style",menuName ="Shooting Style/Cone Style")]
public class ConeShootingStyle : BaseShootingStyle
{
    [SerializeField] int shellNum;
    [SerializeField] float angleBetweenShell;

    public override void SetUp(string fireButton)
    {
        return;
    }

    public override void Shooting(Transform fireTransform, float forceAmount, GameObject player, ShellPoolManager.ShellType shellType)
    {
        int temp = shellNum / 2;
        float beginAngle = -(angleBetweenShell * temp);
        fireTransform.Rotate(new Vector3(0f, beginAngle, 0f));
        float backAngle = beginAngle;
        for(int i = 0; i < shellNum; i++)
        {
            //Transform aTrans = fireTransform;
            //if (beginAngle < 0)
            //{
            //    aTrans.Rotate(new Vector3(0f, beginAngle, 0f));
            //}
            //else
            //{
            //    aTrans.Rotate(new Vector3(0f, beginAngle + 360 - beginAngle, 0f));
            //}
            //aTrans.RotateAround(aTrans.position, Vector3.up, beginAngle);
            //beginAngle += angleBetweenShell;
            ShellBase aShell = ShellPoolManager.instance.GetShell(shellType);
            aShell.gameObject.SetActive(true);
            aShell.Fire(fireTransform, forceAmount, player);
            fireTransform.Rotate(new Vector3(0f, angleBetweenShell, 0f));
            backAngle += angleBetweenShell;
        }
        fireTransform.Rotate(new Vector3(0f, -backAngle, 0f));
    }

    public override void UpdateFunc()
    {
        return;
    }
}
