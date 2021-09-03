using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovingShell : ShellBase
{
    [SerializeField] float minLifeTime;
    [SerializeField] float maxLifeTime;
    [SerializeField] float movingSpeed;
    [SerializeField] float findingZoneRadius;
    [SerializeField] EnemyFindingZone findingZone;
    private bool isActive = false;
    private float lifeTime;
    public override void Fire(Transform fireTransform, float forceAmount, GameObject player)
    {
        transform.position = fireTransform.position;
        //transform.rotation = new Quaternion(0, fireTransform.rotation.y, 0, fireTransform.rotation.w);
        Vector3 aVec = fireTransform.forward;
        aVec.y = 0;
        transform.forward = aVec;
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
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0)
            {
                BackToPool();
            }
            transform.position = transform.position + transform.forward * movingSpeed * Time.deltaTime;
        }
    }

    public override void EnemyFind(GameObject enemy)
    {
        explosion.Explose();
    }

    public override void BackToPool()
    {
        ShellPoolManager.instance.CollectShell(this);
    }

    public override void Deactive()
    {
        isActive = false;
    }
}
