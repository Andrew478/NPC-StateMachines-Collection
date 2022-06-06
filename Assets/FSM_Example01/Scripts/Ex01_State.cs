using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ex01_State : ScriptableObject
{
    public bool IsFinished { get; protected set; }
    [HideInInspector] public Ex01_Character character;

    public virtual void Init() { }
    public abstract void Run();
}
