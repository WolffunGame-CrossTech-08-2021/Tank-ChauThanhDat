using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankBehaviour : MonoBehaviour
{
    public int m_PlayerNumber;
    public Slider m_AimSlider;
    public Transform m_FireTransform;

    [SerializeField]
    public TankShooting TankShooting;

    private void OnEnable()
    {
        TankShooting.m_FireTransform = m_FireTransform;
        TankShooting.m_AimSlider = m_AimSlider;
        TankShooting.m_PlayerNumber = m_PlayerNumber;
        //TankShooting.Fire

        Debug.Log(m_PlayerNumber);

        TankShooting.OnEnable();
    }

    // Start is called before the first frame update
    void Start()
    {
        TankShooting.Start();
    }

    // Update is called once per frame
    void Update()
    {
        TankShooting.onUpdate(m_FireTransform);
    }
}
