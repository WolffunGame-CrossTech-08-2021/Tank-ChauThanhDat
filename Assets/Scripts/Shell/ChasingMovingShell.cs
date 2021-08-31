using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingMovingShell : ShellBase
{
    [SerializeField] float minLifeTime;
    [SerializeField] float maxLifeTime;
    [SerializeField] float movingSpeed;
    [SerializeField] float findingZoneRadius;
    [SerializeField] EnemyFindingZone findingZone;
    private bool isActive = false;
    private bool isChasing = false;
    private GameObject target = null;
    private float lifeTime;

    public override void BackToPool()
    {
        ShellPoolManager.instance.CollectShell(this);
    }

    public override void Deactive()
    {
        target = null;
        isActive = false;
        isChasing = false;
    }

    public override void EnemyFind(GameObject enemy)
    {
        target = enemy;
        isChasing = true;
    }

    public override void Fire(Transform fireTransform, float forceAmount, GameObject player)
    {
        transform.rotation = new Quaternion(0, fireTransform.rotation.y, 0, fireTransform.rotation.w);
        transform.position = fireTransform.position;
        explosion.player = player;
        findingZone.gameObject.SetActive(true);
        findingZone.SetUp(findingZoneRadius, player);
        lifeTime = Mathf.Lerp(minLifeTime, maxLifeTime, forceAmount);
        isActive = true;
    }

    private void Update()
    {
        if (isActive)
        {
            if (isChasing)
            {
                Vector3 targetPos = target.transform.position;
                targetPos.y = transform.position.y;
                Vector3 newDirect = targetPos - transform.position;
                transform.forward = newDirect.normalized;
                transform.position = Vector3.MoveTowards(transform.position, targetPos, movingSpeed * Time.deltaTime);
            }
            else
            {
                lifeTime -= Time.deltaTime;
                if (lifeTime <= 0)
                {
                    BackToPool();
                }
                transform.position = transform.position + transform.forward * movingSpeed * Time.deltaTime;
            }
        }
    }
}
