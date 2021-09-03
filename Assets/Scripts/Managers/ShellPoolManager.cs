using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellPoolManager : MonoBehaviour
{
    public enum ShellType
    {
        Normal_Moving = 0,
        Chasing_Moving = 1,
        Straight_Moving = 2,
        Twist_Moving = 3
    }
    public static ShellPoolManager instance;
    public ShellBase[] shellPrefab;
    public int shellPerPool;
    List<Queue<ShellBase>> shellPool = new List<Queue<ShellBase>>();

    private void Awake()
    {
        instance = this;
        for(int i = 0; i < 4; i++)
        {
            shellPool.Add(new Queue<ShellBase>());
        }
    }

    public void CreatePool(ShellType type)
    {
        if (shellPool[type.GetHashCode()].Count > 0)
        {
            return;
        }
        else
        {
            for(int i = 0; i < shellPerPool; i++)
            {
                ShellBase temp = Instantiate(shellPrefab[type.GetHashCode()]);
                temp.gameObject.SetActive(false);
                shellPool[type.GetHashCode()].Enqueue(temp);
            }
        }
    }

    public ShellBase GetShell(ShellType type)
    {
        if (shellPool[type.GetHashCode()].Count == 0)
        {
            //tao shell moi
            ShellBase res = Instantiate(shellPrefab[type.GetHashCode()]);
            res.gameObject.SetActive(false);
            return res;
        }
        else
        {
            return shellPool[type.GetHashCode()].Dequeue();
        }
    }

    public void CollectShell(ShellBase obj)
    {
        obj.gameObject.SetActive(false);
        shellPool[obj.type.GetHashCode()].Enqueue(obj);
    }
}
