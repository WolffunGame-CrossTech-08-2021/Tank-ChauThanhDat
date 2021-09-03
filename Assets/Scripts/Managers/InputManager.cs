using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    private List<string> movementAxisName = new List<string>();
    private List<string> turnAxisName = new List<string>();
    private List<float> movementAxisValue = new List<float>();
    private List<float> turnAxisValue = new List<float>();
    private int tankCount;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        tankCount = GameManager.instance.m_Tanks.Length;
        for (int i = 0; i < tankCount; i++)
        {
            movementAxisName.Add("Vertical" + (i + 1));
            turnAxisName.Add("Horizontal" + (i + 1));
            movementAxisValue.Add(0);
            turnAxisValue.Add(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < tankCount; i++)
        {
            movementAxisValue[i] = Input.GetAxis(movementAxisName[i]);
            turnAxisValue[i] = Input.GetAxis(turnAxisName[i]);
        }
    }

    public float GetMovementValue(int tankIndex)
    {
        return movementAxisValue[tankIndex - 1];
    }

    public float GetTurnValue(int tankIndex)
    {
        return turnAxisValue[tankIndex - 1];
    }
}
