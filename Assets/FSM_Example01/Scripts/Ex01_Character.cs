using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex01_Character : MonoBehaviour
{
    [Header("Initial parameters")]
    public float Eat = 1f;
    public float Energy = 1f;


    public Ex01_State StartState;
    public Ex01_State EatState;
    public Ex01_State SleepState;
    public Ex01_State WalkState;

    [Header("Actual state")]
    public Ex01_State CurrentState;

    float eatEndTime = 15f;
    float energyEndTime = 25f;

    void Start()
    {
        SetState(StartState);
    }

    void Update()
    {
        Eat -= Time.deltaTime / eatEndTime;
        Energy -= Time.deltaTime / energyEndTime;

        if (!CurrentState.IsFinished) CurrentState.Run();
        else
        {
            if (Eat <= 0.4f) SetState(EatState);
            else if (Energy <= 0.4f) SetState(SleepState);
            else SetState(WalkState);
        }
    }

    public void SetState(Ex01_State state)
    {
        CurrentState = Instantiate(state);
        CurrentState.character = this;
        CurrentState.Init();
    }

    public void MoveTo(Vector3 position)
    {
        position.y = transform.position.y;

        transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(position - transform.position), Time.deltaTime * 120);
    }
}
