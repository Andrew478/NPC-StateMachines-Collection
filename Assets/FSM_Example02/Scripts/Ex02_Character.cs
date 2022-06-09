using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex02_Character : MonoBehaviour
{
    [Header("Initial parameters")]
    public float Eat = 1f;
    public float Energy = 1f;

    float eatEndTime = 15f;
    float energyEndTime = 25f;

    Dictionary<Type, IPlayerBehavior> behaviorsMap;
    IPlayerBehavior currentBehavior;

    void Start()
    {
        InitBehaviors();
        SetBehaviorByDefault();
    }

    void Update()
    {
        Eat -= Time.deltaTime / eatEndTime;
        Energy -= Time.deltaTime / energyEndTime;

        if (currentBehavior != null && currentBehavior.IsInitialized) currentBehavior.Update();
    }





    void InitBehaviors()
    {
        behaviorsMap = new Dictionary<Type, IPlayerBehavior>();

        behaviorsMap[typeof(PlayerBehaviorEat)] = new PlayerBehaviorEat();
        behaviorsMap[typeof(PlayerBehaviorSleep)] = new PlayerBehaviorSleep();
        behaviorsMap[typeof(PlayerBehaviorWalk)] = new PlayerBehaviorWalk();
    }

    public void SetBehavior(IPlayerBehavior newBehavior)
    {
        //if (currentBehavior != null) currentBehavior.Exit(); // закомментил т.к. переключение состояний происходит не в этом скрипте, а в самих состояниях.
        currentBehavior = newBehavior;
        currentBehavior.character = this;
        currentBehavior.Enter();
    }

    public IPlayerBehavior GetBehavior<T>() where T : IPlayerBehavior
    {
        var type = typeof(T);
        return behaviorsMap[type];
    }

    void SetBehaviorByDefault()
    {
        var behaviorByDefault = GetBehavior<PlayerBehaviorWalk>();
        SetBehavior(behaviorByDefault);
    }




    public void MoveTo(Vector3 position)
    {
        position.y = transform.position.y;

        transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * 1.5f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(position - transform.position), Time.deltaTime * 200);
    }
}
