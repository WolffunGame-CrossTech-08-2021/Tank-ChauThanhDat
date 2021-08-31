using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFindingZone : MonoBehaviour
{
    [SerializeField] SphereCollider findZone;
    [SerializeField] ShellBase shell;
    private GameObject player;

    public void SetUp(float findZoneRadius, GameObject player)
    {
        findZone.radius = findZoneRadius;
        this.player = player;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != player)
        {
            shell.EnemyFind(other.gameObject);
            gameObject.SetActive(false);
        }
    }
}
