using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ex01_FSM/SleepState")]
public class Ex01_State_Sleep : Ex01_State
{
    Transform targetBed;
    Vector3 lastCharPos;

    bool isSleepStarted = false;
    float sleepTimeLeft = 7f;

    public override void Init()
    {
        targetBed = GameObject.FindGameObjectWithTag("Bed").transform;
    }

    public override void Run()
    {
        if (IsFinished) return;
        else
        {
            if (!isSleepStarted) MoveTobed();
            else DoSleep();
        }
    }

    void MoveTobed()
    {
        float distance = (targetBed.position - character.transform.position).magnitude;

        if (distance > 1f) character.MoveTo(targetBed.position);
        else
        {
            lastCharPos = character.transform.position;
            character.transform.position = targetBed.position;

            isSleepStarted = true;
        }
    }

    void DoSleep()
    {
        sleepTimeLeft -= Time.deltaTime;
        if (sleepTimeLeft > 0) return;
        character.transform.position = lastCharPos;
        character.Energy = 1f;
        IsFinished = true;
    }
}
