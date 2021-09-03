using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Repeat Shooting Style", menuName = "Shooting Style/Repeat Style")]
public class RepeatShootingStyle : BaseShootingStyle
{
    [SerializeField] int shellPerTurn;
    [SerializeField] float interval;
    string fireButton;
    bool isFire = false;
    int shellCount = 0;
    Transform curFirePoint;
    float curforceAmount;
    GameObject curPlayer;
    ShellPoolManager.ShellType curShelltype;
    float timeCounter;

    public override void SetUp(string fireName)
    {
        fireButton = fireName;
        isFire = false;
    }

    public override void Shooting(Transform fireTransform, float forceAmount, GameObject player, ShellPoolManager.ShellType shellType)
    {
        if (!isFire)
        {
            curFirePoint = fireTransform;
            curforceAmount = forceAmount;
            curPlayer = player;
            curShelltype = shellType;
            ShellBase aShell = ShellPoolManager.instance.GetShell(shellType);
            aShell.gameObject.SetActive(true);
            aShell.Fire(fireTransform, forceAmount, player);
            shellCount = 1;
            timeCounter = interval;
            isFire = true;
        }
    }

    public override void UpdateFunc()
    {
        if (!Input.GetButton(fireButton))
        {
            isFire = false;
        }
        if (isFire)
        {
            Debug.LogError("update");
            //todo:
            if (shellCount >= shellPerTurn)
            {
                isFire = false;
            }
            else
            {
                timeCounter -= Time.deltaTime;
                if (timeCounter <= 0)
                {
                    ShellBase aShell = ShellPoolManager.instance.GetShell(curShelltype);
                    aShell.gameObject.SetActive(true);
                    aShell.Fire(curFirePoint, curforceAmount, curPlayer);
                    shellCount += 1;
                    timeCounter = interval;
                }
            }
        }
    }

    //IEnumerator UpdateFunc()
    //{
    //    while (true)
    //    {
    //        Debug.LogError("Update");
    //        if (!Input.GetButton(fireButton))
    //        {
    //            isFire = false;
    //        }
    //        if (isFire)
    //        {
    //            //todo:
    //            if (shellCount > shellPerTurn)
    //            {
    //                isFire = false;
    //            }
    //            else
    //            {
    //                timeCounter -= Time.deltaTime;
    //                if (timeCounter <= 0)
    //                {
    //                    ShellBase aShell = ShellPoolManager.instance.GetShell(curShelltype);
    //                    aShell.gameObject.SetActive(true);
    //                    aShell.Fire(curFirePoint, curforceAmount, curPlayer);
    //                    shellCount += 1;
    //                    timeCounter = interval;
    //                } 
    //            }
    //        }
    //        yield return null;
    //    }
    //}
}
