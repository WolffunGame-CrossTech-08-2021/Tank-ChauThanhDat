using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewNormalShoot", menuName = "Normal Shoot")]
public class TankShooting : ScriptableObject
{
    public int m_PlayerNumber;
    public Rigidbody m_Shell;
    public Transform m_FireTransform;
    public Slider m_AimSlider;
    //public AudioSource m_ShootingAudio;  
    public AudioClip m_ChargingClip;
    public AudioClip m_FireClip;
    public float m_MinLaunchForce = 15f;
    public float m_MaxLaunchForce = 30f;
    public float m_MaxChargeTime = 0.75f;
    
    protected string m_FireButton;
    public float m_CurrentLaunchForce;
    protected float m_ChargeSpeed;
    public bool m_Fired;

    public void OnEnable()
    {
        m_FireButton = "Fire" + m_PlayerNumber;

        m_CurrentLaunchForce = m_MinLaunchForce;
        m_AimSlider.value = m_MinLaunchForce / 100;
    }


    public void Start()
    {
        m_FireButton = "Fire" + m_PlayerNumber;

        Debug.Log(m_FireButton);

        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    }

    public void onUpdate(Transform t)
    {
        m_AimSlider.value = m_MinLaunchForce / 100;

        if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired)
        {
            // at max charge, not yet fired
            m_CurrentLaunchForce = m_MaxLaunchForce;
            Fire(t);
        }
        else if(Input.GetButtonDown(m_FireButton))
        {
            // have we pressed fire for the first time?
            m_Fired = false;
            m_CurrentLaunchForce = m_MinLaunchForce;

            //m_ShootingAudio.clip = m_ChargingClip;
            //m_ShootingAudio.Play();
        }
        else if(Input.GetButton(m_FireButton) && !m_Fired)
        {
            // holding the fire button, not yet fired
            m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;

            m_AimSlider.value = m_CurrentLaunchForce / 100;
        }
        else if(Input.GetButtonUp(m_FireButton) && !m_Fired)
        {
            // we released the button, having not fired yet
            Fire(t);
        }
    }

    public virtual void Fire(Transform t)
    {
        Debug.Log("Fire " + m_PlayerNumber);

        // Instantiate and launch the shell.
        m_Fired = true;

        m_FireTransform = t;

        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

        //m_ShootingAudio.clip = m_FireClip;
        //m_ShootingAudio.Play();

        m_CurrentLaunchForce = m_MinLaunchForce;
    }
}