using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConeShoot", menuName = "Cone Shoot")]
public class TankConeShooting : TankShooting
{
    public int m_NumberOfShellPerShoot = 3;
    public float m_AnglePerShell = 0.2f;

    public override void Fire(Transform t)
    {
        m_Fired = true;

        m_FireTransform = t;

        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

        Debug.Log(m_FireTransform.forward);

        Rigidbody shellInstance1 = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
        Vector3 temp1 = m_FireTransform.forward;
        temp1.x += 0.2f;
        temp1.z += -0.2f;
        shellInstance1.velocity = m_CurrentLaunchForce * temp1;

        Rigidbody shellInstance2 = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
        Vector3 temp2 = m_FireTransform.forward;
        temp2.x += -0.2f;
        temp2.z += 0.2f;
        shellInstance2.velocity = m_CurrentLaunchForce * temp2;

        //m_ShootingAudio.clip = m_FireClip;
        //m_ShootingAudio.Play();

        m_CurrentLaunchForce = m_MinLaunchForce;
    }
}
