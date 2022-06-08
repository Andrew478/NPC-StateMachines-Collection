using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorWalk : IPlayerBehavior
{
    public float MaxDistance = 5f;

    Vector3 randomPosition;

    public bool IsInitialized { get; set; }
    public bool IsFinished { get; set; }
    public Ex02_Character character { get; set; }
    

    public void Enter()
    {
        Vector3 randomed = new Vector3(Random.Range(-MaxDistance, MaxDistance), 0f, Random.Range(-MaxDistance, MaxDistance));
        randomPosition = character.transform.position + randomed;
        
        IsInitialized = true;
        IsFinished = false; // если в Enter() не обозначать явно каждый раз false, то NPC багуется будто переменная не сбрасывается. Интерфейсы?
    }

    public void Update()
    {
        float distance = (randomPosition - character.transform.position).magnitude;
        if (distance > 0.5f) character.MoveTo(randomPosition);
        else IsFinished = true;

        // если это состояние закончило выполняться, выходим из этого состояния
        if (IsFinished) Exit();
    }

    public void Exit()
    {
        if (character.Eat <= 0.4f) character.SetBehavior(character.GetBehavior<PlayerBehaviorEat>());
        else if (character.Energy <= 0.4f) character.SetBehavior(character.GetBehavior<PlayerBehaviorSleep>());
        else character.SetBehavior(character.GetBehavior<PlayerBehaviorWalk>());
    }
}
