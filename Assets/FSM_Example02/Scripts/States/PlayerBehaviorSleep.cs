using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorSleep : IPlayerBehavior
{
    public bool IsInitialized { get; set; }
    public bool IsFinished { get; set; }
    public Ex02_Character character { get; set; }

    public void Enter()
    {
        Debug.Log("Enter state Sleep");
    }

    public void Update()
    {
        Debug.Log("Update state Sleep");
    }

    public void Exit()
    {
        Debug.Log("Exit state Sleep");
    }
}
