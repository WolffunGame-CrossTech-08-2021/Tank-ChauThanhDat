using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRapidShoot", menuName = "Rapid Shoot")]
public class TankRapidShooting : ShootingStyle
{
    public int m_NumberOfShellPerShoot = 3;
    public float m_TineStepPerShell = 0.2f;

    public override void Fire(Transform t)
    {
        Debug.Log("Rapid Fire");

        //m_Fired = true;

        //for (int i = 0; i < m_NumberOfShellPerShoot; i++)
        //{
        //    m_FireTransform = t;

        //    Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        //    shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

        //    //m_ShootingAudio.clip = m_FireClip;
        //    //m_ShootingAudio.Play();

        //    m_CurrentLaunchForce = m_MinLaunchForce;
        //}

        //m_Fired = false;
    }
}
