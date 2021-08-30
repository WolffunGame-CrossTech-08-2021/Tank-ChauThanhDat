using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwistMovingShell : ShellBase
{
    [SerializeField] float minLifeTime;
    [SerializeField] float maxLifeTime;
    [SerializeField] float movingSpeed;
    [SerializeField] float twistSpeed;
    [SerializeField] float twistRadius;
    [SerializeField] Transform shell;
    private float lifeTime;
    private Vector3 centerPoint;
    private Vector3 movingOffset = Vector3.zero;
    private float timeCounter = 0;
    private Vector3 basicVector;
    private bool isActive = false;
    private Vector3 forwardDirec;

    public override void BackToPool()
    {
        ShellPoolManager.instance.CollectShell(this);
    }

    public override void Deactive()
    {
        isActive = false;
    }

    public override void EnemyFind(GameObject enemy)
    {
        return;
    }

    public override void Fire(Transform fireTransform, float forceAmount, GameObject player)
    {
        lifeTime = Mathf.Lerp(minLifeTime, maxLifeTime, forceAmount);
        transform.rotation = new Quaternion(0, fireTransform.rotation.y, 0, fireTransform.rotation.w);
        shell.rotation = new Quaternion(0, fireTransform.rotation.y, 0, fireTransform.rotation.w);
        forwardDirec = fireTransform.forward;
        forwardDirec.y = 0;
        transform.position = fireTransform.position;
        timeCounter = 0;
        isActive = true;
    }

    private void Update()
    {
        if (isActive)
        {
            timeCounter += Time.deltaTime;
            if (timeCounter >= lifeTime)
            {
                BackToPool();
                return;
            }
            transform.position = transform.position + forwardDirec * movingSpeed * Time.deltaTime;
            //transform.RotateAround(transform.forward, twistSpeed * Time.deltaTime);
            //transform.Rotate(forwardDirec * Time.deltaTime * twistSpeed);
            transform.RotateAround(transform.position, forwardDirec, twistSpeed * Time.deltaTime);
        }
    }
}
