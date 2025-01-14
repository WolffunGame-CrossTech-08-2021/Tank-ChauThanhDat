﻿using System.Collections;
using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public LayerMask m_TankMask;
    public ParticleSystem m_ExplosionParticles;       
    public AudioSource m_ExplosionAudio;              
    public float m_MaxDamage = 100f;                  
    public float m_ExplosionForce = 1000f;            
    public float m_MaxLifeTime = 2f;                  
    public float m_ExplosionRadius = 5f;
    public ShellBase parentShell;
    [HideInInspector] public GameObject player;


    //private void Start()
    //{
    //    //Destroy(gameObject, m_MaxLifeTime);
    //}


    private void OnTriggerEnter(Collider other)
    {
        if(player!=null && other.gameObject == player)
        {
            return;
        }
        // Find all the tanks in an area around the shell and damage them.
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();

            if (!targetHealth)
                continue;

            float damage = CalculateDamage(targetRigidbody.position);

            targetHealth.TakeDamage(damage);
        }

        //m_ExplosionParticles.transform.parent = null;
        parentShell.Deactive();
        StartCoroutine(WaitEffectOffToBack());
        m_ExplosionParticles.Play();
        m_ExplosionAudio.Play();

        //Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);
        //Destroy(gameObject);
        
    }

    public void Explose()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();

            if (!targetHealth)
                continue;

            float damage = CalculateDamage(targetRigidbody.position);

            targetHealth.TakeDamage(damage);
        }

        //m_ExplosionParticles.transform.parent = null;
        m_ExplosionParticles.Play();

        m_ExplosionAudio.Play();

        //Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);
        //Destroy(gameObject);
        parentShell.Deactive();
        StartCoroutine(WaitEffectOffToBack());
    }

    IEnumerator WaitEffectOffToBack()
    {
        yield return new WaitForSeconds(m_ExplosionParticles.main.duration - 1f);
        parentShell.BackToPool();
    }


    private float CalculateDamage(Vector3 targetPosition)
    {
        // Calculate the amount of damage a target should take based on it's position.
        Vector3 explosionToTarget = targetPosition - transform.position;

        float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

        float damage = relativeDistance * m_MaxDamage;

        damage = Mathf.Max(0f, damage);

        return damage;
    }
}