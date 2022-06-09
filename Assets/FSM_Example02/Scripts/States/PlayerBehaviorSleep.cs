using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorSleep : IPlayerBehavior
{
    public bool IsInitialized { get; set; }
    public bool IsFinished { get; set; }
    public Ex02_Character character { get; set; }

    Transform targetBed;
    Vector3 lastCharPos;

    bool isSleepStarted;
    float sleepTimeLeft;

    public void Enter()
    {
        Debug.Log("Enter state Sleep");
        targetBed = GameObject.FindGameObjectWithTag("Bed").transform;
        IsInitialized = true;
        IsFinished = false;

        isSleepStarted = false;
        sleepTimeLeft = 7f;
    }

    public void Update()
    {
        Debug.Log("Update state Sleep");
        if (IsFinished) { Exit(); return; }
        else
        {
            if (!isSleepStarted) MoveTobed();
            else DoSleep();
        }
    }

    public void Exit()
    {
        Debug.Log("Exit state Sleep");
        if (character.Eat <= 0.4f) character.SetBehavior(character.GetBehavior<PlayerBehaviorEat>());
        else if (character.Energy <= 0.4f) character.SetBehavior(character.GetBehavior<PlayerBehaviorSleep>());
        else character.SetBehavior(character.GetBehavior<PlayerBehaviorWalk>());
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
