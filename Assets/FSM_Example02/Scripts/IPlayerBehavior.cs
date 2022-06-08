using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerBehavior 
{
    bool IsInitialized { get; set; }
    bool IsFinished { get; set; }
    Ex02_Character character { get; set; }

    void Enter();
    void Update();
    void Exit();
}
